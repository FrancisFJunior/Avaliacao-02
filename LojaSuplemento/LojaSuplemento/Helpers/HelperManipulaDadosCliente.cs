using LojaSuplemento.Objetos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LojaSuplemento.Helpers
{
    class HelperManipulaDadosCliente
    {
        static List<Cliente> bancoDadosClientes;

        public static void RecebeCliente(List<Cliente> clientes)
        {
            bancoDadosClientes = clientes;
        }

        public static List<Produto> getHistoricoCliente(Cliente cliente)
        {
            var historicoComprasCliente = cliente.HistoricoCompras;
            return historicoComprasCliente;
       }

        public static Cliente BuscaCliente(int idCliente)
        {
            var clienteLogado = bancoDadosClientes.FirstOrDefault(x => x.IDCliente == idCliente);
            return clienteLogado;
        }
    }
}
