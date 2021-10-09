using LojaSuplemento.Objetos;
using System;

namespace LojaSuplemento
{
    class Program
    {
        static void Main(string[] args)
        {
            Carrinho teste = new Carrinho();
            Produto produtoteste = new Produto("teste", 1, "tetsetse", 1, 100);

            teste.CarrinhoCliente.Add(produtoteste);

            foreach(var item in teste.CarrinhoCliente)
            {
                Console.WriteLine(item.Nome);
            }

        }
    }
}
