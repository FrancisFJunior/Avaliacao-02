using System;
using System.Collections.Generic;
using System.Text;

namespace LojaSuplemento.Objetos
{
    class BancoDadosClientes
    {
        private List<Cliente> allClientes;

        public BancoDadosClientes()
        {
            allClientes = new List<Cliente>();
        }


        public List<Cliente> AllClientes
        {
            get { return allClientes; }
        }
    }
}
