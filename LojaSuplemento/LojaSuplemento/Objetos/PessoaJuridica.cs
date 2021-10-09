using System;
using System.Collections.Generic;
using System.Text;

namespace LojaSuplemento.Objetos
{
    class PessoaJuridica : Cliente
    {
        int CNPJ;

        public PessoaJuridica(int CNPJ, string nome, int idCliente): base(nome, idCliente)
        {
            this.CNPJ = CNPJ;
        }
    }
}
