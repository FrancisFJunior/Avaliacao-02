using System;
using System.Collections.Generic;
using System.Text;

namespace LojaSuplemento.Objetos
{
    class SimilaridadeCliente
    {
        double comparacaoCliente;
        int idClienteComparado;
        List<SimilaridadeCliente> clientesComparados;

        public SimilaridadeCliente()
        {
            clientesComparados = new List<SimilaridadeCliente>();
        }
        public SimilaridadeCliente(double comparacaoCliente, int idClienteComparado)
        {
            this.idClienteComparado = idClienteComparado;
            this.comparacaoCliente = comparacaoCliente;
        }

        public List<SimilaridadeCliente>  ClienteComparados
        {
            get { return clientesComparados; }
        }
        public double ComparacaoCliente
        {
            get { return comparacaoCliente; }
        }


    }
}
