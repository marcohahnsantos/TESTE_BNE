using BNE_API.Controllers;
using BNE_API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace BNEAPITEST
{
    public class ProdutoControllerTest
    {
        TarefaProdutoController _controller;
        IProdutos _service;
        Produtos produtos;
        public ProdutoControllerTest()
        {
            _service = new ProdutosFake();
            _controller = new TarefaProdutoController(_service);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            var okResult = _controller.GetAll(0);
            // Assert
            Assert.NotEmpty(okResult);
        }
        [Fact]
        public void Get_WhenAdd_Result()
        {
            int idt = 0;
            string nomet ="CAMISETA GREMIO TREINO Mm";
            decimal valort = 250;
 
            Produtos okResultado = _controller.Post(idt,nomet,valort);
            // Assert
            Assert.NotEmpty(okResultado.ToString());
        }
        [Fact]
        public void Get_WhenAlt_Result()
        {
            int idt = 12;
            string nomet = "CAMISETA GREMIO TREINO MMM";
            decimal valort = 250;

            Produtos okResultado = _controller.Post(idt, nomet, valort);
            // Assert
            Assert.NotEmpty(okResultado.ToString());
        }
    }
}
