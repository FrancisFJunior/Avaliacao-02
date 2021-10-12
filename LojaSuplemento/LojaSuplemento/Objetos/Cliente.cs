using System;
using System.Collections.Generic;
using System.Text;

namespace LojaSuplemento.Objetos
{
    public class Cliente
    {
        protected string nome;
        protected int idCliente;
        protected List<Produto> historicoCompras;
        public Cliente()
        {

        }

        public Cliente(string nome, int idCliente)
        {
            this.nome = nome;
            this.idCliente = idCliente;
            historicoCompras = new List<Produto>();
        }
        public void AtualizaHistoico(List<Produto> ultimaCompra)
        {
            historicoCompras = ultimaCompra;
        }
        public int IDCliente
        {
            get { return idCliente; }
        }
        public List<Produto> HistoricoCompras
        {
            get { return historicoCompras; }
        }
    }
}
