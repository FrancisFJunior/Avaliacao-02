using LojaSuplemento.Objetos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LojaSuplemento.Helpers
{
    class HelperManipulaDadosCliente
    {
        BancoDadosClientes bancoDadosClientes;

        public static List<Produto> getHistoricoCliente(Cliente cliente)
        {
            var historicoComprasCliente = cliente.HistoricoCompras;
            return historicoComprasCliente;
       }
    }
}
