using System;
using System.Collections.Generic;
using System.Text;

namespace LojaSuplemento.Objetos
{
    abstract class Cliente
    {
        protected string nome;
        protected int idCliente;
        protected List<Cliente> clientes;
        protected List<Produto> historicoCompras;
        public Cliente()
        {

        }

        public Cliente(string nome, int idCliente)
        {
            this.nome = nome;
            this.idCliente = idCliente;
            this.historicoCompras = new List<Produto>();
        }
        public void AtualizaHistoico(List<Produto> ultimaCompra)
        {
            historicoCompras = ultimaCompra;
        }
        public int IDCliente
        {
            get { return idCliente; }
        }
        public List<Cliente> Clientes
        {
            get { return clientes; }
        }
        public List<Produto> HistoricoCompras
        {
            get { return historicoCompras; }
        }
    }
}
