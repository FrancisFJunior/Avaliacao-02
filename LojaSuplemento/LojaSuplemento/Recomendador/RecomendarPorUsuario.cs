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
        public IEnumerable<SimilaridadeCliente> ComparaClientes(Cliente user)
        {
            SimilaridadeCliente similaridadeCliente = new SimilaridadeCliente();
            List<double> thisUserCompras = new List<double>();
            List<double> thatUserCompras = new List<double>();
            
            foreach (Cliente clientes in cliente.ListaCliente)
            {
                foreach(Cliente usuarioComparado in clientes.historicoCompras)
                {
                    if (user.historicoCompras.idProduto == usuarioComparado.ListaCliente.idProduto)
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
                double[] thisUserArray = thisUserCompras.ToArray();
                double[] thatUserArray = thisUserCompras.ToArray();
                double ResultadoComparacao = SimilaridadeCoseno.CompararVetores(thisUserArray, thatUserArray);

                similaridadeCliente.ClienteComparados.Add(ResultadoComparacao, clientes.ListaCliente.idCliente);                

            }
            var ordenacaoComparacaoCliente = similaridadeCliente.ClienteComparados.OrderByDescending(x => x.ComparacaoCliente);

            var clienteMaiorAfinidade = ordenacaoComparacaoCliente.First();
            
            return (IEnumerable<SimilaridadeCliente>)clienteMaiorAfinidade;
        }
    
    }
}
