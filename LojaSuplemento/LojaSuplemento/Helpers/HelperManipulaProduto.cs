using LojaSuplemento.Objetos;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaSuplemento.Helpers
{
    class HelperManipulaProduto
    {
        public static void AdicionarNovoProduto()
        {
            Console.Write("Digite o ID do produto: ");
            int idproduto = int.Parse(Console.ReadLine());

            Console.Write("Digite o NOME do produto: ");
            string nomeproduto = Console.ReadLine();

            Console.Write("Digite o DESCRIÇÃO do produto: ");
            string descricaoproduto = Console.ReadLine();

            Console.Write("Digite o QUANTIDADE do produto: ");
            int qtdproduto = int.Parse(Console.ReadLine());

            Console.Write("Digite o VALOR do produto: ");
            double valorproduto =double.Parse(Console.ReadLine());

            Produto produto = new Produto(nomeproduto, idproduto, descricaoproduto,qtdproduto, valorproduto);

            produto.AdicionarProduto(idproduto, produto);
        }

        public static void EditarProduto(Produto item)
        {
            
            Console.Write("---------EditarProduto---------");
            Console.Write("1 para atualizar o ID: ");
            Console.Write("2 para atualizar o Nome: ");
            Console.Write("3 para atualizar o Descrição: ");
            Console.Write("4 para atualizar o Quantidade: ");
            Console.Write("5 para atualizar o Valor: ");
            Console.Write("0 para SAIR: ");
            Console.WriteLine("-------------------------------");
            
            bool loop= true;
            while (loop)
            {
                Console.Write("Digite sua opção: ");
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.Write("Digite o ID do produto: ");
                        int idproduto = int.Parse(Console.ReadLine());
                        item.IDProduto = idproduto;
                        break;

                    case 2:
                        Console.Write("Digite o NOME do produto: ");
                        string nomeproduto = Console.ReadLine();
                        item.Nome = nomeproduto;
                        break;

                    case 3:
                        Console.Write("Digite o DESCRIÇÃO do produto: ");
                        string descricaoproduto = Console.ReadLine();
                        item.Descricao = descricaoproduto;
                        break;

                    case 4:
                        Console.Write("Digite o QUANTIDADE do produto: ");
                        int qtdproduto = int.Parse(Console.ReadLine());
                        item.Quantidade = qtdproduto;
                        break;

                    case 5:
                        Console.Write("Digite o VALOR do produto: ");
                        double valorproduto = double.Parse(Console.ReadLine());
                        item.Valor = valorproduto;
                        break;

                    case 0:
                        loop = false;
                        break;
                }
            }
            
        }
    }
}
