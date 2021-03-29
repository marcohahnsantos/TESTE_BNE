using BNE_API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;



namespace BNE_API.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class TarefaProdutoController : ControllerBase
    {
        TarefaProdutosRepositorio Tarefa = new TarefaProdutosRepositorio();
        private IProdutos service;

        public TarefaProdutoController(IProdutos service)
        {
            this.service = service;
        }

        // GET: api/<TarefaProdutoController>
        [HttpGet]
        public List<Produtos> GetAll(int ativo)
        {
            var Produto = Tarefa.GetAll(ativo);
            return Produto;
        }

        // GET api/<TarefaProdutoController>/5
        [HttpGet("{id}")]
        public Produtos Get(int id)
        {
            var Produto = Tarefa.Find(id);
            return Produto;
        }

        //public Produtos Post(int id,string nome)
        //{
        //    ;
        //}

        // POST api/<TarefaProdutoController>
        [HttpPost]
        public Produtos Post(int? id, string nome, decimal valor)
        {
            Produtos prod = new Produtos();
            if (id == null || id == 0)
            {
                //Produtos prod = new Produtos();
                prod.nome = nome;
                prod.valor = valor;
                Tarefa.Add(prod);
            }
            else
            {
                //Produtos prod = new Produtos();
                prod.id = (int)id;
                prod.nome = nome;
                prod.valor = valor;
                Tarefa.Update(prod);
            }
            return prod;
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
