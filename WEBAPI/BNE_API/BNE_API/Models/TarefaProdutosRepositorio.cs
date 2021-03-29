using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BNE.Util;
using Microsoft.AspNetCore.Http;

namespace BNE_API.Models
{
    public class TarefaProdutosRepositorio : IProdutos
    {
        string sql;
        public TarefaProdutosRepositorio()
        {
     
        }

        public void Add(Produtos item)
        {
            sql= $"INSERT INTO PRODUTOS (NOME,VALOR) VALUES ('{item.nome.ToString().ToUpper()}','{item.valor.ToString().Replace(",", ".")}')";
            DAL objDAL = new DAL();
            objDAL.ExecutarComandoSQL(sql);
            objDAL.FechaComandoSQL();
        
        }

        public Produtos Find(long ID)
        {
            Produtos item = new Produtos();
            string sql = $"SELECT ID,NOME,VALOR,DATA_CAD FROM PRODUTOS WHERE ID={ID}";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);
          
            item.id = int.Parse(dt.Rows[0]["ID"].ToString());
            item.nome = dt.Rows[0]["NOME"].ToString();
            item.valor = decimal.Parse(dt.Rows[0]["VALOR"].ToString());
            item.data = Convert.ToDateTime(dt.Rows[0]["DATA_CAD"].ToString());
            objDAL.FechaComandoSQL();
            return item;
          
        }

        public List<Produtos> GetAll(int FiltroAtivo)
        {
            List<Produtos> lista = new List<Produtos>();
            Produtos item = new Produtos();
            string sql="";
            if (FiltroAtivo == 0)
            {
                    sql = $"SELECT ID," +
                             $"NOME," +
                             $"VALOR," +
                             $"DATA_CAD," +
                             $"ATIVO " +
                             $"FROM PRODUTOS WHERE DELETED='NAO'";
            }
            if (FiltroAtivo == 1)
            {
                    sql = $"SELECT ID," +
                             $"NOME," +
                             $"VALOR," +
                             $"DATA_CAD," +
                             $"ATIVO " +
                             $"FROM PRODUTOS " +
                             $"WHERE DELETED='NAO' " +
                             $" AND ATIVO='SIM'";
            }
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new Produtos();
                item.id = int.Parse(dt.Rows[i]["ID"].ToString());
                item.nome = dt.Rows[i]["NOME"].ToString();
                item.valor = decimal.Parse(dt.Rows[i]["VALOR"].ToString());
                item.data = Convert.ToDateTime(dt.Rows[i]["DATA_CAD"].ToString());
                item.ativo = dt.Rows[i]["ATIVO"].ToString();
                lista.Add(item);
            }
            objDAL.FechaComandoSQL();
            return lista;
        }

        public void Remove(long ID)
        {
            sql = $"UPDATE PRODUTOS SET DELETED='SIM' WHERE  ID={ID}";
            DAL objDAL = new DAL();
            objDAL.ExecutarComandoSQL(sql);
            objDAL.FechaComandoSQL();
        }
        public void Ativa(long ID)
        {
            sql = $"UPDATE PRODUTOS SET ATIVO='SIM' WHERE  ID={ID}";
            DAL objDAL = new DAL();
            objDAL.ExecutarComandoSQL(sql);
            objDAL.FechaComandoSQL();
        }
        public void Desativa(long ID)
        {
            sql = $"UPDATE PRODUTOS SET ATIVO='NAO' WHERE  ID={ID}";
            DAL objDAL = new DAL();
            objDAL.ExecutarComandoSQL(sql);
            objDAL.FechaComandoSQL();
        }
        public void Update(Produtos item)
        {
            sql = $"UPDATE PRODUTOS SET NOME='{item.nome.ToString().ToUpper()}'," +
                 $"VALOR='{item.valor.ToString().Replace(",", ".")}' WHERE ID={item.id}";
            DAL objDAL = new DAL();
            objDAL.ExecutarComandoSQL(sql);
            objDAL.FechaComandoSQL();

        }
    }
}
