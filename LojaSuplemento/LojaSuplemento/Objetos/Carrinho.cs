using LojaSuplemento.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaSuplemento.Objetos
{
    public class Carrinho : IManipulaProduto
    {
        Produto produtosLoja = new Produto();
        List<Produto> carrinhoCliente = new List<Produto>();
        public Carrinho()
        {
           carrinhoCliente = new List<Produto>();
        }
        
        public void AdicionarProduto(int idProduto)
        {
            
            foreach (var item in produtosLoja.Produtos)
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

        public void RemoverProduto(int idProduto)
        {
            foreach (var item in produtosLoja.Produtos)
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

        public void AtualizarProduto(int idProduto)
        {
            throw new NotImplementedException();
        }

        public List<Produto> CarrinhoCliente
        {
            get { return carrinhoCliente; }
            set { carrinhoCliente = value; }
        }
        
    }
}
