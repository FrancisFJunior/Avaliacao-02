using System;
using System.Collections.Generic;
using System.Text;

namespace LojaSuplemento.Objetos
{
    abstract class Cliente
    {
        protected string nome;
        protected int idCliente;

        protected Cliente(string nome, int idCliente)
        {
            this.nome = nome;
            this.idCliente = idCliente;
        }
    }
}
