using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BNE.Util;
using Microsoft.AspNetCore.Http;

namespace BNE_API.Models
{
    public class TarefaPedidosRepositorio : IPedidos
    {

        string sql;
        public TarefaPedidosRepositorio()
        {

        }

        public void Add(Pedidos item)
        {
            sql = $"INSERT INTO PEDIDOS (ID_PRODUTO,ID_USUARIO,QUANTIDADE,EMAIL_ENVIADO) " +
                 $"VALUES ({item.id_produto.ToString().ToUpper()}," +
                 $"{item.id_usuario.ToString()}," +
                 $"{item.quantidade.ToString()}," +
                 $"'{item.email_enviado.ToString()}')";
            DAL objDAL = new DAL();
            objDAL.ExecutarComandoSQL(sql);
            objDAL.FechaComandoSQL();
        }

        public Pedidos Find(long ID)
        {
            Pedidos item = new Pedidos();
            string sql = $"SELECT " +
                         "T1.ID,"+
                         "ID_PRODUTO,"+
                         "T2.NOME AS NOME,"+
                         "T1.ID_USUARIO AS ID_USUARIO,"+
                         "VALOR,"+
                         "QUANTIDADE,"+
                         "T1.DATA_CAD AS DATA_CADASTRO "+
                         $"FROM PEDIDOS T1 " +
                         $"LEFT JOIN PRODUTOS T2 ON " +
                         $"T1.ID_PRODUTO=T2.ID " +
                         $"WHERE T1.ID={ID} ORDER BY ID DESC";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);
            item.id = int.Parse(dt.Rows[0]["ID"].ToString());
            item.id_produto = int.Parse(dt.Rows[0]["ID_PRODUTO"].ToString());
            item.nome_produto = dt.Rows[0]["NOME"].ToString();
            item.id_usuario = int.Parse(dt.Rows[0]["ID_USUARIO"].ToString());
            item.valor = decimal.Parse(dt.Rows[0]["VALOR"].ToString());
            item.quantidade = int.Parse(dt.Rows[0]["QUANTIDADE"].ToString());
            item.data = Convert.ToDateTime(dt.Rows[0]["DATA_CADASTRO"].ToString());
            objDAL.FechaComandoSQL();
            return item;
        }

        public List<Pedidos> GetAll(string Id_usuario,int? TotalRegistro)
        {
            List<Pedidos> lista = new List<Pedidos>();
            Pedidos item = new Pedidos();
            string sql = "";
            if (TotalRegistro != 0)
            {
                if (TotalRegistro > 4)
                {
                    int Limite = (int)(TotalRegistro - 4);
                    string filtro = $"  AND NOT T1.ID IN("+
                                    $" SELECT TOP {Limite} T1.ID "+
                                    "FROM PEDIDOS T1 LEFT JOIN PRODUTOS T2 ON "+
                                    "T1.ID_PRODUTO = T2.ID "+
                                    "WHERE ID_USUARIO = 2 AND T1.DELETED='NAO' ORDER BY ID DESC) ";
                    sql = $"SELECT DISTINCT TOP 4 T1.ID," +
                                $"ID_PRODUTO," +
                                $"T2.NOME [NOMEPRODUTO]," +
                                $"ID_USUARIO," +
                                $"VALOR," +
                                $"QUANTIDADE," +
                                $"T1.DATA_CAD AS DATA_CADASTRO, " +
                                $"T1.ATIVO AS ATIVO " +
                                $"FROM PEDIDOS T1 " +
                                $"LEFT JOIN PRODUTOS T2 ON " +
                                $"T1.ID_PRODUTO=T2.ID " +
                                $"WHERE  " +
                                $"T1.ID_USUARIO={Id_usuario} {filtro}" +
                                $" AND T1.DELETED = 'NAO'  " +
                                $"ORDER BY T1.ID DESC";
                }
                else
                {
                    sql = $"SELECT TOP 4 " +
                           "T1.ID," +
                           "ID_PRODUTO," +
                           "T2.NOME[NOMEPRODUTO]," +
                           "ID_USUARIO," +
                           "VALOR,QUANTIDADE," +
                           "T1.DATA_CAD AS DATA_CADASTRO, " +
                           "T1.ATIVO AS ATIVO " +
                           "FROM PEDIDOS T1 " +
                           "LEFT JOIN PRODUTOS T2 ON T1.ID_PRODUTO = T2.ID " +
                           $"WHERE T1.ID_USUARIO ={Id_usuario}  " +
                           $"AND T1.DELETED = 'NAO'  " +
                           $" ORDER BY T1.ID DESC";
      ;
                }
            }
            else
            {
                sql = $"SELECT T1.ID "+
                            $"FROM PEDIDOS T1 " +
                            $"WHERE T1.DELETED='NAO' " +
                            $"AND T1.ID_USUARIO={Id_usuario}";

            }

            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);


            if (TotalRegistro !=0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    item = new Pedidos();
                    item.id = int.Parse(dt.Rows[i]["ID"].ToString());
                    item.id_produto = int.Parse(dt.Rows[i]["ID_PRODUTO"].ToString());
                    item.nome_produto = dt.Rows[i]["NOMEPRODUTO"].ToString();
                    item.valor = decimal.Parse(dt.Rows[i]["VALOR"].ToString());
                    item.quantidade = int.Parse(dt.Rows[i]["QUANTIDADE"].ToString());
                    item.data = Convert.ToDateTime(dt.Rows[i]["DATA_CADASTRO"].ToString());
                    item.ativo = dt.Rows[i]["ATIVO"].ToString();
                    lista.Add(item);
                }
            }
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    item = new Pedidos();
                    item.id = int.Parse(dt.Rows[i]["ID"].ToString());
                    lista.Add(item);
                }
            }
            objDAL.FechaComandoSQL();
            return lista;
        }

        public void Remove(long ID)
        {
            sql = $"UPDATE PEDIDOS  SET DELETED='SIM' WHERE  ID={ID}";
            DAL objDAL = new DAL();
            objDAL.ExecutarComandoSQL(sql);
            objDAL.FechaComandoSQL();
        }

        public void Update(Pedidos item)
        {
            sql = $"UPDATE Pedidos " +
                  $"SET ID_PRODUTO={item.id_produto.ToString().ToUpper()}," +
                  $"ID_USUARIO={item.id_usuario.ToString().Replace(",", ".")}," +
                  $"QUANTIDADE={item.quantidade.ToString().Replace(",", ".")},"+
                  $"EMAIL_ENVIADO='{item.email_enviado.ToString().Replace(",", ".")}' WHERE  ID={item.id}";
            DAL objDAL = new DAL();
            objDAL.ExecutarComandoSQL(sql);
            objDAL.FechaComandoSQL();
        }
        public void Ativa(long ID)
        {
            sql = $"UPDATE PEDIDOS SET ATIVO='SIM' WHERE  ID={ID}";
            DAL objDAL = new DAL();
            objDAL.ExecutarComandoSQL(sql);
            objDAL.FechaComandoSQL();
        }
        public void Desativa(long ID)
        {
            sql = $"UPDATE PEDIDOS SET ATIVO='NAO' WHERE  ID={ID}";
            DAL objDAL = new DAL();
            objDAL.ExecutarComandoSQL(sql);
            objDAL.FechaComandoSQL();
        }

    }
}
