using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BNE_API.Models
{
    public interface IProdutos
    {
        void Add(Produtos item);
        List<Produtos> GetAll(int ativo);
        Produtos Find(long key);
        void Remove(long key);
        void Ativa(long key);
        void Desativa(long key);
        void Update(Produtos item);
    }
}
