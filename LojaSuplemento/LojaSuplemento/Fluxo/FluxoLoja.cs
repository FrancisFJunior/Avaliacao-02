using LojaSuplemento.Helpers;
using LojaSuplemento.Objetos;
using LojaSuplemento.Recomendador;
using System;
using System.Collections.Generic;

namespace LojaSuplemento.Fluxo
{
    class FluxoLoja
    {
        
        RecomendarPorUsuario recomendarPorUsuario = new RecomendarPorUsuario();
        Produto listaProdutos;
        Carrinho carrinho1;
        Cliente cliente1;

        public void TelaPrincipal()
        {
            bool loop = true;
            while (loop)
            {
                Console.Clear();
                Console.WriteLine("|----------------------|Loja de Suplementos|----------------------|");
                 Console.WriteLine("| {0,2}| {1,-42} |{2} | {3,-9} |", "Nº","Nome","Qtd","Valor");

                foreach (var item in listaProdutos.Produtos)
                {
                    string print = String.Format("| {0,2}| {1,-42} | {2} | {3,-9:C} |", item.IDProduto, item.Nome, item.Quantidade, item.Valor);
                    //string print = String.Format("| {0,2}| {1,-42} | {2,-95} | {3} | {4,-9:C}|", item.IDProduto, item.Nome, item.Descricao, item.Quantidade, item.Valor);
                    Console.WriteLine(print);

                }

                var recomendar = Recomendar(1);
                Console.WriteLine("|--------------------------|RECOMENDADOS|-------------------------|");

                foreach (var item in recomendar)
                {
                    string print = String.Format("| {0,2}| {1,-42} | {2} | {3,-9:C} |", item.IDProduto, item.Nome, item.Quantidade, item.Valor);
                    Console.WriteLine(print);
                }

                Console.WriteLine("|-----------------------------------------------------------------|\n\n");
                

                Console.WriteLine("|Escolha o numero do produto que deseja compra ou DIGITE -1 PARA FECHAR A COMPRA:");
                int opcao = int.Parse(Console.ReadLine());
                if (opcao != -1)
                {
                    var produtoEscolhido = HelperManipulaProduto.VerificaProduto(opcao);

                    Console.WriteLine("|Nome do Produto: {0}", produtoEscolhido.Nome);
                    Console.WriteLine("|Descrição do Produto: {0}\n\n", produtoEscolhido.Descricao);
                    Console.WriteLine("|PRESSIONE 1 para efetuar a compra ou DIGITE 0 para CANCELAR A COMPRA:");

                    int cont = int.Parse(Console.ReadLine());
                    if(cont == 1)
                    {
                        produtoEscolhido.Quantidade -= 1;
                        carrinho1.CarrinhoCliente.Add(produtoEscolhido);
                        cliente1.AtualizaHistoico(carrinho1.CarrinhoCliente);

                    }
                    else if (cont == 0)
                    {
                        TelaPrincipal();
                    }
                }
                else
                {
                    NotaFiscal();
                }
            }

            HelperManipulaProduto.RecebeEstoque(listaProdutos.Produtos);
            

        }

        private void NotaFiscal()
        {
            double valorTotal = 0;
            Console.Clear();
            Console.WriteLine("\n\n|----------------------|Loja de Suplementos|----------------------|");
            Console.WriteLine("|---------------------------|NOTA FISCAL|-------------------------|");

            foreach (var item in carrinho1.CarrinhoCliente)
            {
                string print = String.Format("| {0,2}| {1,-42} | {2} | {3,-9:C} |", item.IDProduto, item.Nome, item.Quantidade,
                    item.Valor);
                Console.WriteLine(print);
                valorTotal += item.Valor;
            }

            Console.WriteLine("|-----------------------------------------------------------------|");
            Console.WriteLine("|{0,-53}| {1:C} |", "TOTAL A PAGAR", valorTotal);
            Console.WriteLine("|-----------------------------------------------------------------|\n\n");


            Console.WriteLine("|PRESSIONE 0 para efetuar o pagamento ou 1 PARA VOLTAR as compras |\n\n");
            int opcao = int.Parse(Console.ReadLine());
            if (opcao == 1)
            {
                TelaPrincipal();
            }
            else if (opcao == 0)
            {
                Console.Clear();
                Console.WriteLine("\n\n\n\n\n\n|----------------------|Loja de Suplementos|----------------------|");
                Console.WriteLine("|-----------------------------------------------------------------|");
                Console.WriteLine("|------------|OBRIGADO PELA PREFERÊNCIA VOLTE SEMPRE|-------------|");
                Console.WriteLine("|-----------------------------------------------------------------|\n\n");
            }
        }

        public List<Produto> Recomendar(int idCliente)
        {
            var cliente = HelperManipulaDadosCliente.BuscaCliente(idCliente);
            var listaClientesSimilares = recomendarPorUsuario.ComparaClientes(cliente, bancoDadosClientes);
            var historicoMaisSimilar = recomendarPorUsuario.getHistoricoClienteMaiorAfinidade(listaClientesSimilares, bancoDadosClientes);
            var listaSugestoes = recomendarPorUsuario.RecomendarProduto(cliente, historicoMaisSimilar);

            return listaSugestoes;
        }

    }
}
