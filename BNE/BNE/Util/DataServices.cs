using System;
using System.Collections.Generic;
using System.Linq;
using Formatting = Newtonsoft.Json.Formatting;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BNE.Models;
using RestSharp;
using Newtonsoft.Json;

namespace BNE.Util
{
    
    public class DataServices
    {
        HttpClient client = new HttpClient();
        
        private string urlPrincipalProduto = "https://localhost:44393/api/TarefaProduto";
        private string urlPrincipalPedido = "https://localhost:44393/api/TarefaPedido";
        public async Task<ProdutosModel> PostAlteraDadosAsync(int id,
                                                                    string Nome,
                                                                    string Valor)
        {
            string url = "";
            url = urlPrincipalProduto+"?id="+id+"&nome="+Nome+"&valor="+Valor;
            var data = new
            {
            };
            var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            var response = await client.PostAsJsonAsync("", data);
            string responseBody = await response.Content.ReadAsStringAsync();
            return Validacoes.DadosProdutos1 = JsonConvert.DeserializeObject<ProdutosModel>(responseBody);
        }
        public async Task<PedidosModel> PostAlteraDadosPedidosAsync(int id,
                                                                   int id_produto,
                                                                   int id_usuario,
                                                                   int Quantidade)
        {
            string url = "";
            url = urlPrincipalPedido+"? id=" + id + "" +
                                                            "&id_produto="+ id_produto +
                                                            "&id_usuario="+id_usuario +
                                                            "&Quantidade="+Quantidade;
            var data = new
            {
            };
            var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            var response = await client.PostAsJsonAsync("", data);
            string responseBody = await response.Content.ReadAsStringAsync();
            return Validacoes.DadosPedidos1 = JsonConvert.DeserializeObject<PedidosModel>(responseBody);
        }

        public async Task<List<ProdutosModel>> PostDadosAsync(int ativo)
        {
            
                string url = "";    
                url = urlPrincipalProduto+"?ativo="+ativo;
                var client = new HttpClient();
                client.BaseAddress = new Uri(url);
                var response = await client.GetAsync(url);
                string responseBody = await response.Content.ReadAsStringAsync();
                return Validacoes.DadosProdutos = JsonConvert.DeserializeObject<List<ProdutosModel>>(responseBody);
        }
        
        public async Task<ProdutosModel> PostDadosEditAsync(int id)
        {
            string url = "";
            url = urlPrincipalProduto+"/"+id.ToString();
            var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            var response = await client.GetAsync(url);
            string responseBody = await response.Content.ReadAsStringAsync();
            var Produto = JsonConvert.DeserializeObject<ProdutosModel>(responseBody);
            return Produto;
        }
        public async Task<PedidosModel> PostDadosEditPedidoAsync(int id)
        {
            string url = "";
            url = urlPrincipalPedido +"/ " + id.ToString();
            var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            var response = await client.GetAsync(url);
            string responseBody = await response.Content.ReadAsStringAsync();
            var Pedido = JsonConvert.DeserializeObject<PedidosModel>(responseBody);
            return Pedido;
        }

        public async Task<string> PostExcluiDadosAsync(string id)
        {
            string url = urlPrincipalProduto+"/"+id;
            var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            var response = await client.DeleteAsync(url);
            string responseBody = await response.Content.ReadAsStringAsync();
            return "ok";
        }
        public async Task<string> PostExcluiDadoPedidosAsync(string id)
        {
            string url = urlPrincipalPedido + "/" + id;
            var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            var response = await client.DeleteAsync(url);
            string responseBody = await response.Content.ReadAsStringAsync();
            return "ok";
        }

        public async Task<string> PostAtivarDadosProdutosAsync(string id)
        {
            string url = urlPrincipalProduto+"/ativa?id="+ id;
            var data = new
            {
            };
            var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            var response = await client.PostAsJsonAsync("", data);
            string responseBody = await response.Content.ReadAsStringAsync();
            return "ok";
        }
        public async Task<string> PostAtivarDadosPedidosAsync(string id)
        {
            string url = urlPrincipalPedido+"/ativa?id=" + id;
            var data = new
            {
            };
            var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            var response = await client.PostAsJsonAsync("", data);
            string responseBody = await response.Content.ReadAsStringAsync();
            return "ok";
        }
        public async Task<string> PostDesativarDadosProdutosAsync(int id)
        {
            string url = urlPrincipalProduto+"/desativa?id=" + id;
            var data = new
            {
            };
            var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            var response = await client.PostAsJsonAsync("", data);
            string responseBody = await response.Content.ReadAsStringAsync();
            return "ok";
        }
        public async Task<string> PostDesativarDadosPedidosAsync(int id)
        {
            string url = urlPrincipalPedido+"/desativa?id=" + id;
            var data = new
            {
            };
            var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            var response = await client.PostAsJsonAsync("", data);
            string responseBody = await response.Content.ReadAsStringAsync();
            return "ok";
        }
        public async Task<string> PostExcluiDadosPedidosAsync(string id)
        {
            string url = urlPrincipalPedido +"/ " + id;
            var client = new HttpClient();
            var response = await client.DeleteAsync(url);
            string responseBody = await response.Content.ReadAsStringAsync();
            return "ok";
        }
        public async Task<PedidosModel> PostDadosAtualizaEmailPedidosAsync(int id)
        {
            string url = "";
            url = urlPrincipalPedido +"/"+id.ToString();
            var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            var response = await client.GetAsync(url);
            string responseBody = await response.Content.ReadAsStringAsync();
            var Pedidos = JsonConvert.DeserializeObject<PedidosModel>(responseBody);
            return Pedidos;
        }
        public async Task<List<PedidosModel>> PostDadosPedidosAsync(string id_usuario,int TotalRegistro)
        {
            string url = "";
            url = urlPrincipalPedido +"?id_usuario=" + id_usuario+"&totalregistro="+TotalRegistro;
            var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            var response = await client.GetAsync(url);
            string responseBody = await response.Content.ReadAsStringAsync();
            return Validacoes.DadosPedidos = JsonConvert.DeserializeObject<List<PedidosModel>>(responseBody);
        }

        public async Task<List<PedidosModel>> PostTotalDadosPedidosAsync(string id_usuario,int? TotalRegistro)
        {
            string url = "";
            url = urlPrincipalPedido+"?id_usuario=" + id_usuario + "&totalregistro=" + TotalRegistro;
            var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            var response = await client.GetAsync(url);
            string responseBody = await response.Content.ReadAsStringAsync();
            return Validacoes.TotalDadosPedidos = JsonConvert.DeserializeObject<List<PedidosModel>>(responseBody);
        }

        public async Task<PedidosModel> PostInsereDadosPedidosAsync(
                                                                int id,
                                                                int id_produto,
                                                                int id_usuario,
                                                                int quantidade,
                                                                int? email )
        {
            string url = "";
            url = urlPrincipalPedido +"?id="+id+"&id_produto="+id_produto+"&id_usuario="+id_usuario+"" +
                   "&quantidade="+quantidade+"&email="+email;
            var data = new
            {
            };
            var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            var response = await client.PostAsJsonAsync("", data);
            string responseBody = await response.Content.ReadAsStringAsync();
            return Validacoes.DadosPedidos1 = JsonConvert.DeserializeObject<PedidosModel>(responseBody);
        }
    }
}
