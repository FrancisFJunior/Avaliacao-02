using System;
using System.Collections.Generic;
using System.Text;

namespace LojaSuplemento.Objetos
{
    class PessoaFisica : Cliente
    {
        int CPF;

        public PessoaFisica(int CPF, string nome, int idCliente) : base(nome, idCliente)
        {
            this.CPF = CPF;
        }
    }
}
