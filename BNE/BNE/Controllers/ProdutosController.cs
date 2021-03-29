using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BNE.Util;
using BNE.Models;
using Serilog;
using Serilog.Events;

namespace BNE.Controllers
{
    public class ProdutosController : Controller
    {
       
        private readonly IHttpContextAccessor HttpContextAccessor;
    
        public ProdutosController(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
            ProdutosModel objProdutos = new ProdutosModel(HttpContextAccessor);
            Log.Information("Acesso a Produtos");
        }
        
        public async Task<IActionResult> IndexAsync()
        {
            DataServices dataService = new DataServices();
            ViewBag.ListaProdutos = await dataService.PostDadosAsync(0);
            Log.Information("Listando os Produtos");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CriarProdutosAsync(ProdutosModel formulario)
        {
            if(ModelState.IsValid)
            {
                formulario.HttpContextAccessor = HttpContextAccessor;
                var id=formulario.Id;
                var nome = formulario.Nome;
                var valor = formulario.Valor;
                DataServices dataService = new DataServices();
                ViewBag.ListaProdutos = await dataService.PostAlteraDadosAsync(id, nome, valor.ToString().Replace(",","."));
                Log.Information("Criando/Alterando Produtos usuario "+ @HttpContextAccessor.HttpContext.Session.GetString("IdNomeUsuarioLogado"));
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CriarProdutosAsync(int id)
        {
            if (id != 0)
            {
                DataServices dataService = new DataServices();
                ViewBag.Registro = await dataService.PostDadosEditAsync(id);
                ViewBag.Editar = "SIM";
            }
      
            return View();
        }



        [HttpGet]
        public IActionResult ExcluirProdutos(int? Id)
        {
            ProdutosModel objProdutos = new ProdutosModel(HttpContextAccessor);
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ExcluirAsync(int Id)
        {
            DataServices dataService = new DataServices();
            string retorno = await dataService.PostExcluiDadosAsync(Id.ToString());
            Log.Information("Excluido Produtos usuario" + @HttpContextAccessor.HttpContext.Session.GetString("IdNomeUsuarioLogado"));
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> AtivarAsync(int Id)
        {
            DataServices dataService = new DataServices();
            string retorno = await dataService.PostAtivarDadosProdutosAsync(Id.ToString());
            Log.Information("Ativando Produtos usuario" + @HttpContextAccessor.HttpContext.Session.GetString("IdNomeUsuarioLogado"));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> DesativarAsync(int Id)
        {
            DataServices dataService = new DataServices();
            string retorno = await dataService.PostDesativarDadosProdutosAsync(Id);
            Log.Information("Desativando Produtos usuario" + @HttpContextAccessor.HttpContext.Session.GetString("IdNomeUsuarioLogado"));
            return RedirectToAction("Index");
        }

    }
}