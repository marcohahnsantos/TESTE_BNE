using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BNE_API.Models
{
    public interface IPedidos
    {
        void Add(Pedidos item);
        List<Pedidos> GetAll(string id_usuario,int? totalregistro);
        Pedidos Find(long key);
        void Remove(long key);
        void Update(Pedidos item);
        void Ativa(long key);
        void Desativa(long key);
       

    }
}
