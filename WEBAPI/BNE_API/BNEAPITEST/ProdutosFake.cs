using System;
using System.Collections.Generic;
using System.Text;
using BNE_API.Models;
namespace BNEAPITEST
{
    class ProdutosFake : IProdutos
    {
        private readonly List<Produtos> _Produtos;
        public ProdutosFake()
        {
        //    _Produtos = new List<Produtos>()
        //    {
        //        new Produtos() { nome = "CAMISA TREINO GREMIO XG",
        //                         valor = 365.00M },

        //    };
        }

        public void Add(Produtos item)
        {
            _Produtos.Add(item);
            var resultado = item;
        }

        public List<Produtos> GetAll(int ativo)
        {
           return _Produtos;
        }

        public Produtos Find(long key)
        {
            throw new NotImplementedException();
        }

        public void Remove(long key)
        {
            throw new NotImplementedException();
        }

        public void Ativa(long key)
        {
            throw new NotImplementedException();
        }

        public void Desativa(long key)
        {
            throw new NotImplementedException();
        }

        public void Update(Produtos item)
        {
            throw new NotImplementedException();
        }

    }
    
}
