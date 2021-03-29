using System.Data;
using System.Data.SqlClient;

namespace BNE.Util
{

    public class DAL
    {



        //=========================================//
        //              VARIAVEIS                  // 
        //=========================================//
        private static string server = "SERVER_DETECT";
        private static string database = "BNE";
        private static string user = "USER_PRINCIPAL";
        private static string password = "mhs491624";
        private static string porta = "3306";
        private static string tipobanco = "SQLSERVER";
       

        //=========================================//
        //            CONEXAO SQLSERVER            //
        //=========================================//
        public static string connectionstringSqlServer = $"Data Source={server}; Initial Catalog={database};PWD={password};Persist Security Info=True;User ID={user};Pooling=False";
        private SqlConnection connetionSql;
        

        public DAL()
        {
            if (tipobanco == "SQLSERVER")
            {
                try
                {
                    connetionSql = new SqlConnection(connectionstringSqlServer);
                    connetionSql.Open();
                }
               catch
                {
                    connetionSql.Close();
                }
            }
      
        }

        //Executa SELECTS
        public DataTable RetDataTable(string sql)
        {
            DataTable dataTable = new DataTable();
          
            if (tipobanco == "SQLSERVER")
            {
                SqlCommand commandSql = new SqlCommand(sql, connetionSql);
                SqlDataAdapter da = new SqlDataAdapter(commandSql);
                da.Fill(dataTable);
            }
            return dataTable;
        }

        //EXECUTA INSERTS / UPDATES / DELETES
        public void FechaComandoSQL()
        {
            connetionSql = new SqlConnection(connectionstringSqlServer);
            connetionSql.Dispose();
        }
        public void ExecutarComandoSQL(string sql)
        {
           
            if (tipobanco == "SQLSERVER")
            {
                SqlCommand commandSql = new SqlCommand(sql, connetionSql);
                commandSql.ExecuteNonQuery();
            }
        }
        public string StringConexao()
        {
            return connectionstringSqlServer;
        }
    }
}
    