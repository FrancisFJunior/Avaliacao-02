using System;
using System.Collections.Generic;
using System.Text;

namespace LojaSuplemento.Objetos
{
    class SimilaridadeCliente : Cliente
    {
        double comparacaoCliente;
        List<SimilaridadeCliente> clientesComparados;

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
