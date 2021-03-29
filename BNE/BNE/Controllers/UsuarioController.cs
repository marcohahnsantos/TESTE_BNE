using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using BNE.Util;
using BNE.Models;

namespace BNE.Controllers
{
    public class UsuarioController : Controller
    {
        


        [HttpGet]
        public IActionResult Login(int? id)
        {
            if(id!=null)
            {
                if (id==0)
                {
                    HttpContext.Session.SetString("IdNomeUsuarioLogado", string.Empty);
                    HttpContext.Session.SetString("NomeUsuarioLogado", string.Empty);
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult ValidarLogin(UsuarioModel usuario)
        {
           
            bool login = usuario.ValidarLogin();
            if (login)
            {
                
                HttpContext.Session.SetString("NomeUsuarioLogado", usuario.Nome.ToString());
                HttpContext.Session.SetString("IdNomeUsuarioLogado", usuario.Id.ToString());
                HttpContext.Session.SetString("EmailUsuarioLogado", usuario.Email);
                return RedirectToAction("Menu", "Home"); 
            }
            else
            {
                TempData["MensagemLoginInvalido"] = "Dados de login invalidos!";
                return RedirectToAction("Login");
            }

        }
        [HttpPost]
        public IActionResult Registrar(UsuarioModel usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.RegistrarUsuario();
                return RedirectToAction("Sucesso");
            }

            return View();
        }
        [HttpGet]
        public IActionResult Registrar()
        {


            return View();
        }

        public IActionResult Sucesso()
        {
            return View();
        }
    }
}