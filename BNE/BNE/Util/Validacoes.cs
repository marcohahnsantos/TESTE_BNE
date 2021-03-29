using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BNE.Models; 


namespace BNE.Util
{
    public class Validacoes
    {

        protected static List<ProdutosModel> dadosProdutos;
        public static List<ProdutosModel> DadosProdutos
        {
            get { return dadosProdutos; }
            set { dadosProdutos = value; }
        }
        protected static ProdutosModel dadosProdutos1;
        public static ProdutosModel DadosProdutos1
        {
            get { return dadosProdutos1; }
            set { dadosProdutos1 = value; }
        }
        protected static PedidosModel dadosPedidos1;
        public static PedidosModel DadosPedidos1
        {
            get { return dadosPedidos1; }
            set { dadosPedidos1 = value; }
        }
        protected static List<PedidosModel> totaldadosPedidos;
        public static List<PedidosModel> TotalDadosPedidos
        {
            get { return totaldadosPedidos; }
            set { totaldadosPedidos = value; }
        }
        protected static List<PedidosModel> dadosPedidos;
        public static List<PedidosModel> DadosPedidos
        {
            get { return dadosPedidos; }
            set { dadosPedidos = value; }
        }
        protected static List<ProdutosModel> dadosProdutosEdit;
        public static List<ProdutosModel> DadosProdutosEdit
        {
            get { return dadosProdutosEdit; }
            set { dadosProdutosEdit = value; }
        }
        protected static string emailEnviado;
        public static string EmailEnviado
        {
            get { return emailEnviado; }
            set { emailEnviado = value; }
        }

        protected static string id_Usuario;
        public static string Id_Usuario
        {
            get { return id_Usuario; }
            set { id_Usuario = value; }
        }

        protected static string stringConexao;
        public static string StringConexao
        {
            get { return stringConexao; }
            set { stringConexao = value; }
        }
        protected static string id;
        public static string Id
        {
            get { return id; }
            set { id = value; }
        }


        protected static string sqlErro;
        public static string SqlErro
        {
            get { return sqlErro; }
            set { sqlErro = value; }
        }

        protected static string data_InicioPesquisa;
        public static string Data_InicioPesquisa
        {
            get { return data_InicioPesquisa; }
            set { data_InicioPesquisa = value; }
        }

        protected static string data_FimPesquisa;
        public static string Data_FimPesquisa
        {
            get { return data_FimPesquisa; }
            set { data_FimPesquisa = value; }
        }

        protected static string excliur_Transacao;
        public static string Excliur_Transacao
        {
            get { return excliur_Transacao; }
            set { excliur_Transacao = value; }
        }

        protected static string tipo_bancoDados;
        public static string Tipo_BancoDados
        {
            get { return tipo_bancoDados; }
            set { tipo_bancoDados = value; }
        }

        protected static string start_insert;
        public static string Start_insert
        {
            get { return start_insert; }
            set { start_insert = value; }
        }


        protected static string valorDespesaGeral;
        public static string ValorDespesaGeral
        {
            get { return valorDespesaGeral; }
            set { valorDespesaGeral = value; }
        }

        protected static string valorReceitaGeral;
        public static string ValorReceitaGeral
        {
            get { return valorReceitaGeral; }
            set { valorReceitaGeral = value; }
        }
        protected static string nome_servidor;
        public static string Nome_Servidor
        {
            get { return nome_servidor; }
            set { nome_servidor = value; }
        }

        protected static string nome_bancoDados;
        public static string Nome_BancoDados
        {
            get { return nome_bancoDados; }
            set { nome_bancoDados = value; }
        }


        protected static DateTime data_Ini;
        public static DateTime Data_Ini
        {
            get { return data_Ini; }
            set { data_Ini = value; }
        }
        protected static DateTime data_Fim;
        public static DateTime Data_Fim
        {
            get { return data_Fim; }
            set { data_Fim = value; }
        }
        protected static string tipo_RD;
        public static string Tipo_RD
        {
            get { return tipo_RD; }
            set { tipo_RD = value; }
        }
        protected static int id_Conta;
        public static int Id_Conta
        {
            get { return id_Conta; }
            set { id_Conta = value; }
        }
        protected static int id_Plano_Conta;
        public static int Id_Plano_Conta
        {
            get { return id_Plano_Conta; }
            set { id_Plano_Conta = value; }
        }
        protected static int id_Forma_Pagto;
        public static int Id_Forma_Pagto
        {
            get { return id_Forma_Pagto; }
            set { id_Forma_Pagto = value; }
        }

        protected static string pesquisar;
        public static string Pesquisar
        {
            get { return pesquisar; }
            set { pesquisar = value; }
        }
        protected static int page;
        public static int Page
        {
            get { return page; }
            set { page = value; }
        }
        
        protected static string erroPagina;
        public static string ErroPagina
        {
            get { return erroPagina; }
            set { erroPagina = value; }
        }
        protected static string urlProdutos;
        public static string UrlProdutos
        {
            get { return urlProdutos; }
            set { urlProdutos = value; }
        }
        protected static string urlPedidos;
        public static string UrlPedidos
        {
            get { return urlPedidos; }
            set { urlPedidos = value; }
        }
       


    }

}
