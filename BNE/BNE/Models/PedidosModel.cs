using Microsoft.AspNetCore.Http;
using BNE.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BNE.Models
{
    public class PedidosModel
    {
        public int id { get; set; }
        public int id_produto { get; set; }
        public string nome_produto { get; set; }
        public int id_usuario { get; set; }
        public string nome_usuario { get; set; }
        public double valor { get; set; }
        public int quantidade { get; set; }
        public DateTime data { get; set; }
        public String ativo { get; set; }
        public IHttpContextAccessor HttpContextAccessor { get; set; }

      
        

    }
}
