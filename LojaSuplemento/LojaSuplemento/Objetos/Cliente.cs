using System;
using System.Collections.Generic;
using System.Text;

namespace LojaSuplemento.Objetos
{
    public class Cliente
    {
        protected string nome;
        protected int idCliente;
<<<<<<< HEAD
=======
        protected List<Cliente> clientes;
>>>>>>> 826099fe1e5bba602aa6e8ecbae294e1fecacad3
        protected List<Produto> historicoCompras;
        public Cliente()
        {

        }

        public Cliente(string nome, int idCliente)
        {
            this.nome = nome;
            this.idCliente = idCliente;
<<<<<<< HEAD
            historicoCompras = new List<Produto>();
=======
            this.historicoCompras = new List<Produto>();
>>>>>>> 826099fe1e5bba602aa6e8ecbae294e1fecacad3
        }
        public void AtualizaHistoico(List<Produto> ultimaCompra)
        {
            historicoCompras = ultimaCompra;
        }
        public int IDCliente
        {
            get { return idCliente; }
        }
<<<<<<< HEAD
=======
        public List<Cliente> Clientes
        {
            get { return clientes; }
        }
>>>>>>> 826099fe1e5bba602aa6e8ecbae294e1fecacad3
        public List<Produto> HistoricoCompras
        {
            get { return historicoCompras; }
        }
    }
}
