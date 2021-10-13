using System;
using System.Collections.Generic;
using System.Text;

namespace LojaSuplemento.Objetos
{
    public class Carrinho 
    {
        List<Produto> carrinhoCliente = new List<Produto>();
        public Carrinho()
        {
           carrinhoCliente = new List<Produto>();
        }
        
        public void AdicionarProduto(int idProduto, List<Produto> produtosLoja)
        {
            foreach (var item in produtosLoja)
            {
                if( item.IDProduto == idProduto)
                {
                    carrinhoCliente.Add(item);
                }
                else
                {
                    Console.WriteLine("Não existe esse produto na loja!");
                }
                    
            }
                
        }

        public void RemoverProduto(int idProduto, List<Produto> produtosLoja)
        {
            foreach (var item in produtosLoja)
            {
                if (item.IDProduto == idProduto)
                {
                    carrinhoCliente.Remove(item);
                }
                else
                {
                    Console.WriteLine("Não existe esse produto na loja!");
                }

            }

        }

        public List<Produto> CarrinhoCliente
        {
            get { return carrinhoCliente; }
            set { carrinhoCliente = value; }
        }
        
    }
}
