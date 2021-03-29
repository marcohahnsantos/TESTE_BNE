using BNE_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BNE_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaPedidoController : Controller
    {
        TarefaPedidosRepositorio Tarefa = new TarefaPedidosRepositorio();
        private IPedidos service;


        // GET: api/<TarefaPedidoController>
        [HttpGet]
        public List<Pedidos> Get(string id_usuario,int? totalregistro)
        {
            List<Pedidos> pedidos = Tarefa.GetAll(id_usuario,totalregistro);
            return pedidos;
        }

        // GET api/<TarefaPedidoController>/5
        [HttpGet("{id}")]
        public Pedidos Get(int id)
        {
            var Pedidos = Tarefa.Find(id);
            return Pedidos;
        }

        // POST api/<TarefaPedidoController>
        [HttpPost]
        public Pedidos Post(int id, 
                        int id_produto,
                        int id_usuario,
                        int quantidade,
                        int? email)
        {
            Pedidos ped = new Pedidos();
            if (id == 0)
            {
                ped.id_produto = id_produto;
                ped.id_usuario = id_usuario;
                ped.quantidade = quantidade;
                if (email == 0)
                    ped.email_enviado = "NAO";
                else
                    ped.email_enviado = "SIM";
                Tarefa.Add(ped);
            }
            else 
            {
                ped.id = id;
                ped.id_produto = id_produto;
                ped.id_usuario = id_usuario;
                ped.quantidade = quantidade;
                if(email==0)
                    ped.email_enviado = "NAO";
                else
                    ped.email_enviado = "SIM";
                Tarefa.Update(ped);
            }
            return ped;
        }
        // DELETE api/<TarefaProdutoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Tarefa.Remove(id);
        }
        [Route("ativa")]
        [HttpPost]
        public void ativa(int id)
        {
            Tarefa.Ativa(long.Parse(id.ToString()));
        }
        [Route("desativa")]
        [HttpPost]
        public void desativa(int id)
        {
            Tarefa.Desativa(long.Parse(id.ToString()));
        }
    }
}
