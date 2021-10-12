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
        public List<SimilaridadeCliente> ComparaClientes(Cliente thisUser, List<Cliente> listaDeClientes)
        {
            SimilaridadeCliente similaridadeCliente = new SimilaridadeCliente();
            List<double> thisUserComparacao = new List<double>();
            List<double> thatUserComparacao = new List<double>();
            var thisUserHistory = thisUser.HistoricoCompras.OrderBy(x => x.IDProduto).ToList();
            
            foreach (Cliente clientes in listaDeClientes)
            {
               
                if (clientes.IDCliente != thisUser.IDCliente)
                {
                    var thatUserHistory = clientes.HistoricoCompras.OrderBy(x => x.IDProduto).ToList();
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

                    similaridadeCliente.ClienteComparados.Add(new SimilaridadeCliente(ResultadoComparacao, clientes.IDCliente));
                    similaridadeCliente.ClienteComparados.Add(new SimilaridadeCliente(0.30, 4));
                    similaridadeCliente.ClienteComparados.Add(new SimilaridadeCliente(0.50, 1));

                }

            }
            var ordenacaoComparacaoCliente = similaridadeCliente.ClienteComparados.OrderByDescending(x => x.ComparacaoCliente).ToList();

         
            return ordenacaoComparacaoCliente;
        }
 
    }
    
}

