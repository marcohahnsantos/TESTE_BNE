using System;
using System.Collections.Generic;
using System.Text;
using BNE_API.Models;
namespace BNEAPITEST
{
    public class PedidosFake : IPedidos
    {
        private readonly List<Pedidos> _Pedidos;
        public PedidosFake()
        {
         
        }

        public void Add(Pedidos item)
        {
            _Pedidos.Add(item);
            var resultado = item;
        }

        public void Ativa(long key)
        {
            throw new NotImplementedException();
        }

        public void Desativa(long key)
        {
            throw new NotImplementedException();
        }

        public Pedidos Find(long key)
        {
            throw new NotImplementedException();
        }

        public List<Pedidos> GetAll(string id_usuario, int? totalregistro)
        {
            return _Pedidos;
        }

        public void Remove(long key)
        {
            throw new NotImplementedException();
        }

        public void Update(Pedidos item)
        {
            throw new NotImplementedException();
        }
    }

}

