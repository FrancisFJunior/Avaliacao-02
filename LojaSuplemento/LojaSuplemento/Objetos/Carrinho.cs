using System;
using System.Collections.Generic;
using System.Text;

namespace LojaSuplemento.Objetos
{
    public class Carrinho : Produto
    {
        List<Produto> carrinhoCliente = new List<Produto>();
        public Carrinho()
        {
           carrinhoCliente = new List<Produto>();
        }

        public List<Produto> CarrinhoCliente
        {
            get { return carrinhoCliente; }
            set { carrinhoCliente = value; }
        }
        
    }
}
