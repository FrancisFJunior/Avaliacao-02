using System;
using System.Collections.Generic;
using System.Text;

namespace LojaSuplemento.Objetos
{
    class PessoaFisica : Cliente
    {
        long CPF;


        public PessoaFisica(long CPF, string nome, int idCliente) : base(nome, idCliente)
        {
            this.CPF = CPF;
        }
    }
}
