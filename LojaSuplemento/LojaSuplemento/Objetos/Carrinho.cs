using LojaSuplemento.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using LojaSuplemento.Helpers;

namespace LojaSuplemento.Objetos
{
    public class Carrinho : IManipulaProduto
    {
        List<Produto> carrinhoCliente;
        public Carrinho()
        {
           carrinhoCliente = new List<Produto>();
        }
        
        public void AdicionarProduto(int idProduto)
        {

            var item = HelperManipulaProduto.VerificaProduto(idProduto); 
            if ( item.IDProduto == idProduto)
            {
                carrinhoCliente.Add(item);

            }
            else
            {
                Console.WriteLine("Não existe esse produto na loja!");
            }
                
        }

        public void RemoverProduto(int idProduto)
        {
            var item = HelperManipulaProduto.VerificaProduto(idProduto);
            if (item.IDProduto == idProduto)
            {
                carrinhoCliente.Remove(item);
            }
            else
            {
                Console.WriteLine("Não existe esse produto na loja!");
            }

        }

        public void AtualizarProduto(int idProduto, int qtd)
        {
            var item = HelperManipulaProduto.VerificaProduto(idProduto);

            if (item.Quantidade >= qtd)
            {
                item.Quantidade -= qtd;

                foreach (var produtoCarrinho in carrinhoCliente)
                {
                    produtoCarrinho.Quantidade = qtd;
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
