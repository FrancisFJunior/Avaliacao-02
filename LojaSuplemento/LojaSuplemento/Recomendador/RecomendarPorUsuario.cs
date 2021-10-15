using LojaSuplemento.Objetos;
using LojaSuplemento.Comparador;
using LojaSuplemento.Helpers;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;


namespace LojaSuplemento.Recomendador
{
    class RecomendarPorUsuario
    {
        public List<SimilaridadeCliente> ComparaClientes(Cliente thisUser, BancoDadosClientes bancoDadosClientes)
        {
            SimilaridadeCliente similaridadeCliente = new SimilaridadeCliente();
            List<double> thisUserComparacao = new List<double>();
            List<double> thatUserComparacao = new List<double>();
            var thisUserHistory = thisUser.HistoricoCompras.OrderBy(x => x.IDProduto).ToList();

            foreach (Cliente clientes in bancoDadosClientes.AllClientes)
            {
                var thatUserHistory = clientes.HistoricoCompras.OrderBy(x => x.IDProduto).ToList();
                if (clientes.IDCliente != thisUser.IDCliente)
                {

                    for (int i = 0; i < thisUserHistory.Count(); i++)
                    {
                        if (thisUserHistory.Contains(thatUserHistory[i]))
                        {
                            thisUserComparacao.Add(1);
                            thatUserComparacao.Add(1);

                        }
                        else
                        {
                            thisUserComparacao.Add(1);
                            thatUserComparacao.Add(0);

                        }
                    }
                    double[] thisUserArray = thisUserComparacao.ToArray();
                    double[] thatUserArray = thatUserComparacao.ToArray();
                    double ResultadoComparacao = SimilaridadeCoseno.CompararVetores(thisUserArray, thatUserArray);
                    thisUserComparacao = new List<double>();
                    thatUserComparacao = new List<double>(); 
                        
                    similaridadeCliente.ClienteComparados.Add(new SimilaridadeCliente(ResultadoComparacao * 100, clientes.IDCliente));
                  
                }

            }
            var clientesParecidos = similaridadeCliente.ClienteComparados.OrderByDescending(x => x.ComparacaoCliente).ToList();

            return clientesParecidos;
        }

        public List<Produto> getHistoricoClienteMaiorAfinidade(List<SimilaridadeCliente> clientesParecidos, BancoDadosClientes bancoDadosClientes)
        {
            List<Produto> historicoClienteEscolhido = new List<Produto>();

            var cliente = clientesParecidos.FirstOrDefault(x => x.ComparacaoCliente > 60);
            foreach (var item in bancoDadosClientes.AllClientes)
            {
                if (cliente.IDClienteComparado == item.IDCliente)
                {
                    historicoClienteEscolhido = HelperManipulaDadosCliente.getHistoricoCliente(item);
                }
            }
            return historicoClienteEscolhido;
        }

        public List<Produto> RecomendarProduto(Cliente cliente, List<Produto> historicoClienteMaiorAfinidade)
        {
            List<Produto> produtosRecomendados = new List<Produto>();
            foreach(var produto in historicoClienteMaiorAfinidade)
            {
               var produtoEncontrado = HelperManipulaProduto.VerificaProduto(produto.IDProduto);
                if (!cliente.HistoricoCompras.Contains(produtoEncontrado))
                {
                    produtosRecomendados.Add(produto);
                }

            }
            return produtosRecomendados;
           
        }
    }
    
}

