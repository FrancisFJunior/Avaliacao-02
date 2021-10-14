﻿using LojaSuplemento.Objetos;
using LojaSuplemento.Recomendador;
using LojaSuplemento.Helpers;
using System;
using LojaSuplemento.Leitor;

namespace LojaSuplemento
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            FluxoLoja fluxoLoja = new FluxoLoja();
            fluxoLoja.iniciaDados();
            fluxoLoja.TelaPrincipal();
            */



            Cliente cliente1 = new PessoaFisica(1234,"teste1", 1);
            Cliente cliente2 = new PessoaFisica(1234,"teste2", 2);
            BancoDadosClientes bancoDadosClientes = new BancoDadosClientes();

            RecomendarPorUsuario recomendarPorUsuario = new RecomendarPorUsuario();
            bancoDadosClientes.AllClientes.Add(cliente1);
            bancoDadosClientes.AllClientes.Add(cliente2);

            Carrinho teste = new Carrinho();
            Carrinho teste1 = new Carrinho();
            Produto produtoteste = new Produto(1,"teste1", "tetsetse", 1, 100);
            Produto produtoteste2 = new Produto(2,"teste2","tetsetse", 1, 100);
            Produto produtoteste3 = new Produto(3,"teste3", "tetsetse", 1, 100);
            Produto produtoteste4 = new Produto(4,"teste4",  "tetsetse", 1, 100);
            Produto produtoteste5 = new Produto(5, "teste5",  "tetsetse", 1, 100);
            Produto produtoteste6 = new Produto(6, "teste6",  "tetsetse", 1, 100);
            Produto produtoteste7 = new Produto(7, "teste7",  "tetsetse", 1, 100);
            Produto produtoteste8 = new Produto(8, "teste8",  "tetsetse", 1, 100);
            Produto produtoteste9 = new Produto(9, "teste9",  "tetsetse", 1, 100);
            Produto produtoteste10 = new Produto(10, "teste10",  "tetsetse", 1, 100);

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

            var testando = recomendarPorUsuario.ComparaClientes(cliente1, bancoDadosClientes);
            var testando2 = recomendarPorUsuario.getHistoricoClienteMaiorAfinidade(testando, bancoDadosClientes);
            var testando3 = recomendarPorUsuario.RecomendarProduto(cliente1, testando2);

            Console.WriteLine(testando);


            

        }

    }
}
