using LojaSuplemento.Objetos;
using LojaSuplemento.Recomendador;
using LojaSuplemento.Helpers;
using System;

namespace LojaSuplemento
{
    class Program
    {
        static void Main(string[] args)
        {
            Cliente cliente1 = new Cliente("teste1", 1);
            Cliente cliente2 = new Cliente("teste2", 2);
            BancoDadosClientes bancoDadosClientes = new BancoDadosClientes();
            
            RecomendarPorUsuario recomendarPorUsuario = new RecomendarPorUsuario();
            bancoDadosClientes.AllClientes.Add(cliente1);
            bancoDadosClientes.AllClientes.Add(cliente2);

            Carrinho teste = new Carrinho();
            Carrinho teste1 = new Carrinho();
            Produto produtoteste = new Produto("teste1", 1, "tetsetse", 1, 100);
            Produto produtoteste2= new Produto("teste2", 2, "tetsetse", 1, 100);
            Produto produtoteste3 = new Produto("teste3", 3, "tetsetse", 1, 100);
            Produto produtoteste4 = new Produto("teste4", 4, "tetsetse", 1, 100);
            Produto produtoteste5 = new Produto("teste5", 5, "tetsetse", 1, 100);
            Produto produtoteste6 = new Produto("teste6", 6, "tetsetse", 1, 100);
            Produto produtoteste7 = new Produto("teste7", 7, "tetsetse", 1, 100);
            Produto produtoteste8 = new Produto("teste8", 8, "tetsetse", 1, 100);
            Produto produtoteste9 = new Produto("teste9", 9, "tetsetse", 1, 100);
            Produto produtoteste10 = new Produto("teste10", 10, "tetsetse", 1, 100);


            teste.CarrinhoCliente.Add(produtoteste);
            teste.CarrinhoCliente.Add(produtoteste2);
            teste.CarrinhoCliente.Add(produtoteste3);
            teste.CarrinhoCliente.Add(produtoteste4);
            teste.CarrinhoCliente.Add(produtoteste5);


            teste1.CarrinhoCliente.Add(produtoteste);
            teste1.CarrinhoCliente.Add(produtoteste2);
            teste1.CarrinhoCliente.Add(produtoteste3);
            teste1.CarrinhoCliente.Add(produtoteste4);
            teste1.CarrinhoCliente.Add(produtoteste5);
            teste1.CarrinhoCliente.Add(produtoteste7);
            teste1.CarrinhoCliente.Add(produtoteste9);
            teste1.CarrinhoCliente.Add(produtoteste6);

            cliente1.AtualizaHistoico(teste.CarrinhoCliente);
            cliente2.AtualizaHistoico(teste1.CarrinhoCliente);

            var testando = recomendarPorUsuario.ComparaClientes(cliente1);

            Console.WriteLine(testando);


            

        }
    }
}
