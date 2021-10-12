using LojaSuplemento.Objetos;
using LojaSuplemento.Comparador;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;


namespace LojaSuplemento.Recomendador
{
    class RecomendarPorUsuario
    {
        private Cliente cliente;
        public IEnumerable<SimilaridadeCliente> ComparaClientes(Cliente thisUser)
        {
            SimilaridadeCliente similaridadeCliente = new SimilaridadeCliente();
            List<double> thisUserCompras = new List<double>();
            List<double> thatUserCompras = new List<double>();
            
            foreach (Cliente clientes in cliente.Clientes)
            {
                foreach(Produto thisUserHistory in clientes.HistoricoCompras)
                {
                    foreach (Produto thatUserHistory in clientes.HistoricoCompras)
                    {                
                        if (thisUserHistory.IDProduto == thatUserHistory.IDProduto)
                        {
                            thisUserCompras.Add(1);
                            thatUserCompras.Add(1);

                        }
                        else 
                        {
                            thisUserCompras.Add(1);
                            thatUserCompras.Add(0);
                        }
                    }
                }
                double[] thisUserArray = thisUserCompras.ToArray();
                double[] thatUserArray = thisUserCompras.ToArray();
                double ResultadoComparacao = SimilaridadeCoseno.CompararVetores(thisUserArray, thatUserArray);

                similaridadeCliente.ClienteComparados.Add(new SimilaridadeCliente(ResultadoComparacao, clientes.IDCliente));                

            }
            var ordenacaoComparacaoCliente = similaridadeCliente.ClienteComparados.OrderByDescending(x => x.ComparacaoCliente);

            var clienteMaiorAfinidade = ordenacaoComparacaoCliente.First();
            
            return (IEnumerable<SimilaridadeCliente>)clienteMaiorAfinidade;
        }
    
    }
}
