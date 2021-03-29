using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BNE_API.Models
{
    public class Produtos
    {
        public int id { get; set; }
        public string nome { get; set; }
        public decimal valor { get; set; }
        public DateTime data { get; set; }
        public string ativo { get; set; }
    }
}
