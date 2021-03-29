using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BNE.Util;
using BNE.Models;
using Serilog;
using Confluent.Kafka;
namespace BNE.Controllers
{
    public class PedidosController : Controller
    {
        private readonly IEmailSender _emailSender;
        IHttpContextAccessor HttpContextAccessor;
        public PedidosController(IHttpContextAccessor httpContextAccessor, IEmailSender emailSender)
        {
            HttpContextAccessor = httpContextAccessor;
            _emailSender = emailSender;
        }

        public async Task<IActionResult> IndexAsync(int? page)
        {
            DataServices dataService = new DataServices();
            string id_usuario_logado = @HttpContextAccessor.HttpContext.Session.GetString("IdNomeUsuarioLogado");
            Validacoes.TotalDadosPedidos = await dataService.PostTotalDadosPedidosAsync(id_usuario_logado,0);
            int Limite = Validacoes.TotalDadosPedidos.Count;
            if (page == null)
            {
                page = 1;
                Limite = 4;
            }
            else
            {
                Limite = Convert.ToInt32(page) * 4;
            }

            ViewBag.ListaProdutos = await dataService.PostDadosAsync(1);
            ViewBag.ListaTransacao = await dataService.PostDadosPedidosAsync(id_usuario_logado, Limite);
            ViewBag.ListaQuantidade = CapturaQuantidade();
            ViewBag.CurrentPage = page;
            ViewBag.TotalItems = Validacoes.TotalDadosPedidos.Count;
            Log.Information("Acesso a Produtos");
            return View();
        }

        public async Task<IActionResult> CriarPedidosAsync(PedidosModel formulario)
        {
            if (ModelState.IsValid)
            {
                string id_usuario_logado = @HttpContextAccessor.HttpContext.Session.GetString("IdNomeUsuarioLogado");
                string usuario_logado = @HttpContextAccessor.HttpContext.Session.GetString("NomeUsuarioLogado");
                string email_usuario_logado= @HttpContextAccessor.HttpContext.Session.GetString("EmailUsuarioLogado");
                Validacoes.EmailEnviado = "NAO";
                int email = 0;
                var id = formulario.id;
                var id_produto = formulario.id_produto;
                var nome = formulario.nome_produto;
                var valor = formulario.valor;
                var quantidade = formulario.quantidade;
                DataServices dataService = new DataServices();
                string Mensagem = $"{usuario_logado} Seu pedido foi realizado " +
                                $" de {nome} quantidade {quantidade}";
                
                //ROTINA DE ENVIO de email  VIA C#
                await _emailSender.SendEmailAsync(email_usuario_logado, "REALIZAÇÃO DE PEDIDO", Mensagem);
                //ROTINA DE ENVIO VIA KAFKA
                //try
                //{
                //    SendMessageByKafka("Teste de Envio");
                //}
                //catch
                //{

                //}

                if (Validacoes.EmailEnviado == "SIM")
                    email = 1;
                ViewBag.ListaPedidos = await dataService.PostInsereDadosPedidosAsync(id, id_produto, int.Parse(id_usuario_logado), quantidade, email);
                Log.Information("Criando Pedidos Usuario "+ id_usuario_logado);
                return RedirectToAction("Index");
            }


            return View();
        }
        public async Task<IActionResult> AlterarPedidoAsync(int id)
        {
                DataServices dataService = new DataServices();
                string id_usuario_logado = @HttpContextAccessor.HttpContext.Session.GetString("IdNomeUsuarioLogado");
                string usuario_logado = @HttpContextAccessor.HttpContext.Session.GetString("NomeUsuarioLogado");
                string email_usuario_logado = @HttpContextAccessor.HttpContext.Session.GetString("EmailUsuarioLogado");
                Validacoes.EmailEnviado = "NAO";
                var Pedido = await dataService.PostDadosEditPedidoAsync(id);
                ViewBag.IdPedido = Pedido.id;
                ViewBag.IdProduto = Pedido.id_produto;
                ViewBag.NomeProduto = Pedido.nome_produto;
                ViewBag.Quantidade = Pedido.quantidade;
                ViewBag.ListaProdutos = await dataService.PostDadosAsync(1);
                ViewBag.ListaQuantidade = CapturaQuantidade();
                Log.Information("Altera Pedidos Usuario " + id_usuario_logado);
                return View();
        }

        public async Task<IActionResult> AlterarRegistroPedidoAsync(PedidosModel formulario)
        {
            DataServices dataService = new DataServices();
            string id_usuario_logado = @HttpContextAccessor.HttpContext.Session.GetString("IdNomeUsuarioLogado");
            var Pedido = await dataService.PostAlteraDadosPedidosAsync(formulario.id, 
                                                                       formulario.id_produto, 
                                                                       int.Parse(id_usuario_logado),
                                                                       formulario.quantidade);

            Log.Information("Altera Pedidos Usuario " + id_usuario_logado);
            return RedirectToAction("Index");
        }


       
        [HttpGet]
        public async Task<IActionResult> ExcluirAsync(int Id)
        {
            DataServices dataService = new DataServices();
            string retorno = await dataService.PostExcluiDadosPedidosAsync(Id.ToString());
            Log.Information("Exclui Pedidos");
            return RedirectToAction("Index");

        }

        public List<string> CapturaQuantidade()
        {
            List<string> lista = new List<String>();
            for (int i = 1; i < 16; i++)
            {
                lista.Add(i.ToString());
            }
            return lista;
        }
        [HttpGet]
        public async Task<IActionResult> AtivarAsync(int Id)
        {
            DataServices dataService = new DataServices();
            string retorno = await dataService.PostAtivarDadosPedidosAsync(Id.ToString());
            Log.Information("Ativa Pedidos");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> DesativarAsync(int Id)
        {
            DataServices dataService = new DataServices();
            string retorno = await dataService.PostDesativarDadosPedidosAsync(Id);
            Log.Information("Desativa Pedidos");
            return RedirectToAction("Index");
        }

        private string SendMessageByKafka(string message)
        {
            var config = new ProducerConfig { BootstrapServers = "localhost:9092" };

            using (var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                try
                {
                    var sendResult = producer
                                        .ProduceAsync("fila_pedido", new Message<Null, string> { Value = message })
                                            .GetAwaiter()
                                                .GetResult();

                    return $"Mensagem '{sendResult.Value}' de '{sendResult.TopicPartitionOffset}'";
                }
                catch (ProduceException<Null, string> e)
                {
                    Console.WriteLine($"Delivery failed: {e.Error.Reason}");
                }
            }

            return string.Empty;
        }

    }

}

