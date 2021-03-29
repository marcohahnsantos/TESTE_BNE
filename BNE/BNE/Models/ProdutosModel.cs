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
    public class ProdutosModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe o nome da conta")]
        public String Nome { get; set; }
        public String Data { get; set; }
        [Required(ErrorMessage = "Informe o saldo da conta")]
        public Decimal Valor { get; set; }
        public int Usuario_Id { get; set; }
        public string  Ativo { get; set; }
        public IHttpContextAccessor HttpContextAccessor { get; set; }



        public ProdutosModel()
        {

        }
        //Recebe Contexto para as variaveis de sessão
        public ProdutosModel(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }
        //    public List<ProdutosModel> ListaProdutos()
        //    {
        //        try
        //        {
        //            List<ProdutosModel> lista = new List<ProdutosModel>();
        //            ProdutosModel item;
        //            string id_usuario_logado = @HttpContextAccessor.HttpContext.Session.GetString("IdNomeUsuarioLogado");
        //            string sql = $"SELECT ID,NOME,SALDO,DATA_CAD FROM CONTA WHERE DELETED='N' ";
        //            DAL objDAL = new DAL();
        //            DataTable dt = objDAL.RetDataTable(sql);

        //            item = new ProdutosModel();
        //            item.Id = int.Parse("0");
        //            item.Nome = "Todas";
        //            item.Valor = Decimal.Parse("0");
        //            //    item.Usuario_Id = int.Parse(dt.Rows[i]["USUARIO_ID"].ToString());
        //            lista.Add(item);


        //            for (int i = 0; i < dt.Rows.Count; i++)
        //            {
        //                item = new ProdutosModel();
        //                item.Id = int.Parse(dt.Rows[i]["ID"].ToString());
        //                item.Nome = dt.Rows[i]["NOME"].ToString();
        //                item.Valor = Decimal.Parse(dt.Rows[i]["SALDO"].ToString());
        //                lista.Add(item);
        //            }
        //            objDAL.FechaComandoSQL();
        //            return lista;
        //        }
        //        catch
        //        {
        //            List<ProdutosModel> lista = new List<ProdutosModel>();
        //            return lista;
        //        }
        //    }

        //    public ProdutosModel CarregaRegistro(int? id)
        //    {
        //        try
        //        {
        //            ProdutosModel item = new ProdutosModel();
        //            string id_usuario_logado = @HttpContextAccessor.HttpContext.Session.GetString("IdNomeUsuarioLogado");
        //            string sql = $"SELECT ID,NOME,SALDO,DATA_CAD FROM CONTA WHERE ID={id}";
        //            DAL objDAL = new DAL();
        //            DataTable dt = objDAL.RetDataTable(sql);

        //            item.Id = int.Parse(dt.Rows[0]["ID"].ToString());
        //            item.Nome = dt.Rows[0]["NOME"].ToString();
        //            item.Valor = Decimal.Parse(dt.Rows[0]["SALDO"].ToString());
        //            item.Data = dt.Rows[0]["DATA_CAD"].ToString();
        //            //item.Usuario_Id = int.Parse(dt.Rows[0]["USUARIO_ID"].ToString());
        //            objDAL.FechaComandoSQL();
        //            return item;
        //        }
        //        catch
        //        {
        //            ProdutosModel item = new ProdutosModel();
        //            return item;
        //        }
        //    }


        //    public void Insert()
        //    {
        //        try
        //        {
        //            string id_usuario_logado = @HttpContextAccessor.HttpContext.Session.GetString("IdNomeUsuarioLogado");
        //            string sql = "";
        //            if (Id == 0)
        //            {
        //                sql = $"INSERT INTO CONTA (NOME,SALDO) VALUES ('{Nome.ToString().ToUpper()}','{Valor.ToString().Replace(",", ".")}')";
        //            }
        //            else
        //            {
        //                sql = $"UPDATE CONTA SET NOME='{Nome}',SALDO='{Valor.ToString().Replace(",", ".")}' WHERE ID='{Id}'";
        //            }
        //            DAL objDAL = new DAL();
        //            objDAL.ExecutarComandoSQL(sql);
        //            objDAL.FechaComandoSQL();
        //        }
        //        catch
        //        {

        //        }
        //    }
        //    public void Excluir(int id_conta)
        //    {
        //        try
        //        {
        //            new DAL().ExecutarComandoSQL("UPDATE CONTA SET DELETED='S' WHERE ID=" + id_conta);
        //            new DAL().FechaComandoSQL();
        //        }
        //        catch
        //        {

        //        }
        //    }

        //}
    }
}
