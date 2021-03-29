using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BNE_API.Models
{
    public class Pedidos
    {
        public int id { get; set; }
        public int id_produto { get; set; }
        public string nome_produto { get; set; }
        public int id_usuario { get; set; }
        public string nome_usuario { get; set; }
        public decimal valor { get; set; }
        public int quantidade { get; set; }
        public string email_enviado { get; set; }
        public string ativo { get; set; }
        public DateTime data {get; set; }

    }
}
