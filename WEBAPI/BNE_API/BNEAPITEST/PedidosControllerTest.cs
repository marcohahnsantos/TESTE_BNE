using BNE_API.Controllers;
using BNE_API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace BNEAPITEST
{
    public class PedidosControllerTest
    {
        TarefaPedidoController _controllerpedido;
        IPedidos _service;
        Pedidos pedidos;
        public PedidosControllerTest()
        {
            _service = new PedidosFake();
            _controllerpedido = new TarefaPedidosController(_service);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            string id_usuario = "2";
            int? totalregistro = 0;
            var okResult = _controllerpedido.Get(id_usuario, totalregistro);
            // Assert
            Assert.NotEmpty(okResult);
        }
        [Fact]
        public void Get_WhenAdd_Result()
        {
            int idt = 0;
            int id_produto = 3;
            int id_usuario = 2;
            int quantidade = 3;
            int email = 0;

            Pedidos okResultado = _controllerpedido.Post(idt,
                                                          id_produto, 
                                                          id_usuario,
                                                          quantidade,email);
           
            Assert.NotEmpty(okResultado.ToString());
        }
        [Fact]
        public void Get_WhenAlt_Result()
        {
            int idt = 5;
            int id_produto = 3;
            int id_usuario = 2;
            int quantidade = 3;
            int email = 0;
            Pedidos okResultado = _controllerpedido.Post(idt,
                                                                     id_produto,
                                                                     id_usuario,
                                                                     quantidade, email);
            // Assert
            Assert.NotEmpty(okResultado.ToString());
        }
    }
}
