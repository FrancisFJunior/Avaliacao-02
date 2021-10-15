using LojaSuplemento.Objetos;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaSuplemento.Helpers
{
    public class BancoDadosClientes 
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
