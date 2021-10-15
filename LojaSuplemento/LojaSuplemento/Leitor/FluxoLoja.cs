using LojaSuplemento.Helpers;
using LojaSuplemento.Objetos;
using LojaSuplemento.Recomendador;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LojaSuplemento.Leitor
{
    class FluxoLoja
    {
        //StreamWriter produtos = new StreamWriter("produtos.txt");
        //StreamWriter clientes = new StreamWriter("clientes.txt");
        //StreamWriter histotico = new StreamWriter("produtos.txt");
        BancoDadosClientes bancoDadosClientes = new BancoDadosClientes();
        RecomendarPorUsuario recomendarPorUsuario = new RecomendarPorUsuario();
        Produto listaProdutos = new Produto();
        Carrinho carrinho1 = new Carrinho();

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
                

                Console.WriteLine("|Escolha o numero do produto que deseja compra ou DIGITE -1 PARA SAIR:");
                int opcao = int.Parse(Console.ReadLine());
                if (opcao != -1)
                {
                    var produtoEscolhido = HelperManipulaProduto.VerificaProduto(opcao);
                    Console.WriteLine("Descrição do Produto: {0}", produtoEscolhido.Descricao);
                    Console.WriteLine("|PRESSIONE 1 para efetuar a compra ou DIGITE 0 para CANCELAR A COMPRA:\n");
                    int cont = int.Parse(Console.ReadLine());
                    if(cont != 0)
                    {
                        produtoEscolhido.Quantidade -= 1;
                        carrinho1.CarrinhoCliente.Add(produtoEscolhido);

                    }
                }
                
                //loop = false;
                //.CarrinhoCliente.Add(produtoteste);

            }

            HelperManipulaProduto.RecebeEstoque(listaProdutos.Produtos);
            

        }

        public List<Produto> Recomendar(int idCliente)
        {
            var cliente = HelperManipulaDadosCliente.BuscaCliente(idCliente);
            var listaClientesSimilares = recomendarPorUsuario.ComparaClientes(cliente, bancoDadosClientes);
            var historicoMaisSimilar = recomendarPorUsuario.getHistoricoClienteMaiorAfinidade(listaClientesSimilares, bancoDadosClientes);
            var listaSugestoes = recomendarPorUsuario.RecomendarProduto(cliente, historicoMaisSimilar);

            return listaSugestoes;
        }

        public void iniciaDados()
        {
            Produto produto0 = new Produto(0, "NATURAL VEGAN", "Formulada por duas proteínas vegetais: proteína dos grãos de arroz e da ervilha.",
                24, 169.99);
            Produto produto1 = new Produto(1, "CARNIBOL DARKNESS", "Base de proteína miofibrilar hidrolisada de carne bovina, importante para a " +
                "contração muscular.", 63, 169.99);
            Produto produto2 = new Produto(2, "ISOFORT", "Contém alta concentração de proteína, nutriente que ajuda na formação dos músculos " +
                "e ossos.", 46, 299.99);
            Produto produto3 = new Produto(3, "PASTA DE AMENDOIM INTEGRAL CROCANTE", "A Pasta de Amendoim Integral fornece energia duradoura para " +
                "atletas em variados níveis. É fonte de proteínas, rica em gordura saudável e antioxidantes, e tem baixo teor de carboidratos.", 56, 29.99);
            Produto produto4 = new Produto(4, "PASTA DE AMENDOIM INTEGRAL ORIGINAL", "A Pasta de Amendoim Integral fornece energia duradoura para " +
                "atletas em variados níveis. É fonte de proteínas, rica em gordura saudável e antioxidantes, e tem baixo teor de carboidratos.", 82, 29.99);
            Produto produto5 = new Produto(5, "PASTA DE AMENDOIM INTEGRAL COOKIES & CREAM", "A Pasta de Amendoim Integral fornece energia " +
                "duradoura para atletas em variados níveis. É fonte de proteínas, rica em gordura saudável e antioxidantes, e tem baixo teor de " +
                "carboidratos.", 15, 59.99);
            Produto produto6 = new Produto(6, "PASTA DE AMENDOIM INTEGRAL PRESS CREAM", "A Pasta de Amendoim Integral fornece energia " +
                "duradoura para atletas em variados níveis. É fonte de proteínas, rica em gordura saudável e antioxidantes, e tem baixo teor " +
                "de carboidratos.", 24, 59.99);
            Produto produto7 = new Produto(7, "ALBUMINA PURA", "A proteína albumina tem alto valor biológico, e possui altos teores de " +
                "aminoácidos, como os BCAA´s e o ácido glutâmico, que são importantes para o desenvolvimento e recuperação da massa muscular. " +
                "Obtida da clara do ovo pasteurizada e desidratada. Não contém lactose, e é digerida facilmente no organismo.", 34, 49.99);
            Produto produto8 = new Produto(8, "BCAA 3:1:1 3VS NUTRITION", "BCAA 3:1:1 é feito à base de aminoácidos de cadeia ramificada," +
                " e sua suplementação auxilia na síntese proteica, na recuperação muscular e ajuda na proteção contra o catabolismo. Este suplemento " +
                "possui concentração de 3 partes de leucina para 1 parte de isoleucina e 1 parte de valina. Também conta com uma pequena quantidade" +
                " de waxy maize, que auxilia no fornecimento de energia.", 72, 49.99);
            Produto produto9 = new Produto(9, "BCAA 10:1:1 3VS NUTRITION", "BCAA 10:1:1 da 3VS Nutrition é um suplemento alimentar que possui " +
                "fórmula exclusiva dos BCAA's (aminoácidos de cadeia ramificada): L-isoleucina, L-leucina e L-valina. Esses aminoácidos são absorvidos" +
                " rapidamente no corpo, e são importantes para a realização da síntese proteica. Porém não são produzidos pelo organismo, sendo " +
                "necessário sua suplementação na dieta.", 73, 70.00);
            Produto produto10 = new Produto(10, "GLUTAMINE NATURAL", "A glutamina é o aminoácido livre mais abundante no organismo. Com " +
                "exercícios intensos ou de longa duração, o consumo da glutamina do corpo excede a sua produção, e vários tecidos são afetados," +
                " como o músculo esquelético, pulmões, fígado e também o cérebro. Portanto é essencial que haja constante reposição de glutamina" +
                " nestes tecidos, e no organismo de forma geral, para assegurar o funcionamento de algumas funções vitais, como as do sistema " +
                "nervoso central, imunológicas, renais, entre outras.", 46, 90.00);
            Produto produto11 = new Produto(11, "BCAA FIX 4500", "BCAA FIX possui em sua fórmula alta concentração de aminoácidos de cadeia " +
                "ramificada (l-valina, l-leucina e l-isoleucina). Os BCAA (sigla para Branched-Chain Amino Acids, em inglês) não são produzidos " +
                "naturalmente pelo organismo, portanto, precisam ser ingeridos por meio de alimentação ou suplementação.", 52, 109.99);
            Produto produto12 = new Produto(12, "PHOENIX BCAA 1500", "Phoenix BCAA 1500 garante a dose necessária para a construção de um corpo " +
                "forte, definido e saudável. São 1.500 mg de aminoácidos combinados à praticidade de poder levar os comprimidos com você a qualquer " +
                "lugar.", 38, 49.99);
            Produto produto13 = new Produto(13, "BCAA'S HYDRO", "BCAA Hydro tem como base aminoácidos de cadeia ramificada, e sua suplementação " +
                "auxilia na síntese proteica, recuperação muscular e ajuda na proteção contra o catabolismo. Também conta com uma pequena dose de " +
                "waxy maize que  colabora para  o fornecimento de energia.", 73, 89.99);
            Produto produto14 = new Produto(14, "WHEY PROTEIN ISOLADO", "O whey protein isolado é produzido a partir do soro do leite, um subproduto" +
                " resultante da proporção aquosa do leite - erada durante o processo de fabricação do queijo.", 21, 144.00);
            Produto produto15 = new Produto(15, "BASIC WHEY PROTEIN", "Este é um produto obtido através da remoção de nutrientes não proteicos do soro" +
                " do leite. O produto é confeccionado com proteínas do soro do leite e fornece proteínas de alto valor biológico e de rápida absorção," +
                " promove a oferta de aminoácidos essenciais e de cadeia ramificada auxiliando na recuperação das fibras musculares auxiliando na " +
                "obtenção dos seus objetivos.", 91, 37.80);
            Produto produto16 = new Produto(16, "MEDIUM WHEY PROTEIN", "O Whey Medium é 100% Whey Protein! Isso significa que 100 % da proteína presente" +
                " no produto é derivada do soro do leite.Grande concentração de proteínas, ferro e cálcio, como todo derivado de leite.", 76, 56.61);
            Produto produto17 = new Produto(17, "BEST WHEY ISO", "Best Whey Iso da Atlhetica Nutrition é formulado com Proteína Isolada e Hidrolisada " +
                "do Soro do Leite, possui alta concentração proteica e baixo sódio.Disponível em deliciosos sabores desenvolvidos com 20 g de proteína" +
                " por porção, Sabor morango .", 20, 239.40);
            Produto produto18 = new Produto(18, "WHEY SUPREME", "O Whey Supreme da 3VS Nutrition é uma rica fonte proteica que conta com 3 formas de " +
                "Whey Protein: concentrado (WPC), hidrolisado (WPH) e isolado (WPI). Essa combinação de proteínas proporciona mais energia para treinar" +
                ", promove maior retenção de nitrogênio que é um dos fatores principais do crescimento muscular, além de ter ação antioxidante " +
                "fortalecendo o sistema imunológico.", 38, 107.91);
            Produto produto19 = new Produto(19, "SUPER WHEY 100% PURE", "Whey 100% Pure da Integralmédica é um suplemento proteico com média velocidade" +
                " de metabolização que contribui para prolongar o balanço nitrogenado positivo do organismo. O whey protein (proteína do soro de leite)" +
                " é um tipo de proteína de alto valor biológico, ou seja, que possui elevados índices de aminoácidos essenciais. ", 57, 89.10);
            Produto produto20 = new Produto(20, "COMBO WHEY ISOLATE + BCAPS + PALATINOSE ", "Ideal para pessoas que praticam atividades físicas e buscam " +
                "um melhor desempenho e eficácia na recuperação após o treino.", 52, 173.10);
            Produto produto21 = new Produto(21, "REFIL WHEY 3 HD", "O Whey 3 HD Caveira Preta Series® é mais uma novidade da Black Skull USA™. Com a " +
                "união perfeita dos três tipos de Whey Protein: Concentrado, Isolado e Hidrolisado, Whey 3 HD® é o suplemento ideal para sua dieta com " +
                "foco na síntese proteÍca, pois entrega 32g de proteínas e 6,6g de BCAAs por dose, transformando seu objetivo em resultados.", 15, 95.56);
            Produto produto22 = new Produto(22, "WHEY PROTEIN ULTRA PURE ISOLATE", "Formulado apenas com soro do leito isolado que foi purificado " +
                "através de um processo de trocaiônica para maximizar a pureza e o valor biológicoFornece 25g de proteína mais pura com zerogramas de " +
                "açucar e gordura. O Isolado mais puro disponível com menos carboidratos,colesterol e lactose que qualquer outra proteína no mercado. " +
                "Contém 5, 8g de BCAAs para melhor recuperação e crescimento muscular. Oferece 3g de leucina, mais que a concorrência", 55, 269.91);
            Produto produto23 = new Produto(23, "100% WHEY PROTEIN", "Whey GAS apresenta uma combinação de proteínas de alta qualidade e de rápida " +
                "absorção. É produzido com matéria prima importada rica em aminoácidos de cadeia ramificada (BCAA), complexo de minerais e proteínas de" +
                " alto valor biológico.", 16, 71.91);
            Produto produto24 = new Produto(24, "WHEY FLAVOUR", "Whey Flavour da Atlhetica Nutrition é um suplemento alimentar formulado com Whey " +
                "Protein Concentrado (WPC), proteína concentrada do soro do leite, de alto valor biológico e perfil de aminoácidos. Fornece 20 g de " +
                "proteínas por porção e disponível em 9 deliciosos sabores, para diversificar seu plano alimentar.", 22, 80.10);
            Produto produto25 = new Produto(25, "WHEY ZERO LACTOSE", "Whey Zero da 3VS Nutrition é um suplemento formulado com a proteína de soro do " +
                "leite (sem lactose). Whey Protein Zero lactose passa por um processo de quebra da lactose em glicose e galactose, que são açúcares que" +
                " não causam intolerância. Whey Zero tem alto valor biológico e possui baixas quantidades de gorduras e carboidratos, além de fornecer" +
                " todos os aminoácidos necessários para o organismo, inclusive os BCAAs e glutamina.É uma proteína de fácil digestibilidade e ótima " +
                "absorção.", 59, 107.10);
            Produto produto26 = new Produto(26, "TOP WHEY 3W MAIS SABOR", "Top Whey 3W Mais Sabor da Max Titanium contém três tipos de proteínas do " +
                "soro do leite: concentrada (WPC), isolada (WPI) e hidrolisada (WPH), matérias-primas com alta concentração de aminoácidos, " +
                "principalmente BCAA. Essas características dessa fórmula exclusiva da Max Titanium, torna um produto extraordinário que auxilia na " +
                "formação dos músculos e na recuperação muscular pós - treino.", 96, 119.70);
            Produto produto27 = new Produto(27, "TOP WHEY 3W MAIS NATURAL", "Top Whey 3W Mais Natural da Max Titanium contém três tipos de proteínas " +
                "do soro do leite: concentrada (WPC), isolada (WPI) e hidrolisada (WPH), matérias-primas com alta concentração de aminoácidos, " +
                "principalmente BCAA.", 69, 119.70);
            Produto produto28 = new Produto(28, "BEST WHEY ISO (DOSE ÚNICA)", "Versão em dose única (sachê) do Best Whey Iso da Atlhetica Nutrition. " +
                "BEST WHEY ISO da Atlhetica Nutrition é formulado com Proteína Isolada e Hidrolisada do Soro do Leite(WPI + WPH), possui alta " +
                "concentração proteica e baixo sódio. Disponível em deliciosos sabores desenvolvidos com 20g de proteína por porção.", 27, 9.90);
            Produto produto29 = new Produto(29, "WHEY ISOLATE BLACK SERIES", "Quem pratica exercícios físicos regularmente, principalmente musculação" +
                " e esportes de alto desempenho, tem como objetivo, geralmente, reduzir gordura corporal e aumentar massa magra para fins de definição." +
                " Nesses casos, consumir Whey Protein junto a uma dieta balanceada é extremamente benéfico para potencializar os resultados.", 39, 125.10);
            Produto produto30 = new Produto(30, "BEST WHEY (DOSE ÚNICA)", "Versão em dose única (sachê) do Best Whey da Atlhetica Nutrition. " +
                "BEST WHEY Blend de Proteínas WPC, WPI e WPH, que oferece em cada porção 25 g de proteínas de alto valor biológico em deliciosos " +
                "sabores e perfeita cremosidade.", 41, 10.26);

            listaProdutos.Produtos.Add(produto0);
            listaProdutos.Produtos.Add(produto1);
            listaProdutos.Produtos.Add(produto2);
            listaProdutos.Produtos.Add(produto3);
            listaProdutos.Produtos.Add(produto4);
            listaProdutos.Produtos.Add(produto5);
            listaProdutos.Produtos.Add(produto6);
            listaProdutos.Produtos.Add(produto7);
            listaProdutos.Produtos.Add(produto8);
            listaProdutos.Produtos.Add(produto9);
            listaProdutos.Produtos.Add(produto10);
            listaProdutos.Produtos.Add(produto11);
            listaProdutos.Produtos.Add(produto12);
            listaProdutos.Produtos.Add(produto13);
            listaProdutos.Produtos.Add(produto14);
            listaProdutos.Produtos.Add(produto15);
            listaProdutos.Produtos.Add(produto16);
            listaProdutos.Produtos.Add(produto17);
            listaProdutos.Produtos.Add(produto18);
            listaProdutos.Produtos.Add(produto19);
            listaProdutos.Produtos.Add(produto20);
            listaProdutos.Produtos.Add(produto21);
            listaProdutos.Produtos.Add(produto22);
            listaProdutos.Produtos.Add(produto23);
            listaProdutos.Produtos.Add(produto24);
            listaProdutos.Produtos.Add(produto25);
            listaProdutos.Produtos.Add(produto26);
            listaProdutos.Produtos.Add(produto27);
            listaProdutos.Produtos.Add(produto28);
            listaProdutos.Produtos.Add(produto29);
            listaProdutos.Produtos.Add(produto30);            

            HelperManipulaProduto.RecebeEstoque(listaProdutos.Produtos);

            Cliente cliente1 = new PessoaFisica(11111111111, "Carlos", 1);
            Cliente cliente2 = new PessoaFisica(22222222222, "Maria", 2);
            Cliente cliente3 = new PessoaFisica(33333333333, "Luiz", 3);
            Cliente cliente4 = new PessoaFisica(44444444444, "Neila", 4);

            bancoDadosClientes.AllClientes.Add(cliente1);
            bancoDadosClientes.AllClientes.Add(cliente2);
            bancoDadosClientes.AllClientes.Add(cliente3);
            bancoDadosClientes.AllClientes.Add(cliente4);
            HelperManipulaDadosCliente.RecebeCliente(bancoDadosClientes.AllClientes);

            
            carrinho1.CarrinhoCliente.Add(produto30);
            carrinho1.CarrinhoCliente.Add(produto20);
            carrinho1.CarrinhoCliente.Add(produto3);
            carrinho1.CarrinhoCliente.Add(produto0);
            carrinho1.CarrinhoCliente.Add(produto8);

            Carrinho carrinho2 = new Carrinho();
            carrinho2.CarrinhoCliente.Add(produto30);
            carrinho2.CarrinhoCliente.Add(produto20);
            carrinho2.CarrinhoCliente.Add(produto3);
            carrinho2.CarrinhoCliente.Add(produto0);
            carrinho2.CarrinhoCliente.Add(produto10);
            carrinho2.CarrinhoCliente.Add(produto9);
            carrinho2.CarrinhoCliente.Add(produto13);

            Carrinho carrinho3 = new Carrinho();
            carrinho3.CarrinhoCliente.Add(produto30);
            carrinho3.CarrinhoCliente.Add(produto20);
            carrinho3.CarrinhoCliente.Add(produto3);
            carrinho3.CarrinhoCliente.Add(produto0);
            carrinho3.CarrinhoCliente.Add(produto10);
            carrinho3.CarrinhoCliente.Add(produto11);
            carrinho3.CarrinhoCliente.Add(produto14);

            Carrinho carrinho4 = new Carrinho();
            carrinho4.CarrinhoCliente.Add(produto30);
            carrinho4.CarrinhoCliente.Add(produto20);
            carrinho4.CarrinhoCliente.Add(produto3);
            carrinho4.CarrinhoCliente.Add(produto0);
            carrinho4.CarrinhoCliente.Add(produto10);
            carrinho4.CarrinhoCliente.Add(produto12);
            carrinho4.CarrinhoCliente.Add(produto15);

            cliente1.AtualizaHistoico(carrinho1.CarrinhoCliente);
            cliente2.AtualizaHistoico(carrinho2.CarrinhoCliente);
            cliente3.AtualizaHistoico(carrinho3.CarrinhoCliente);
            cliente4.AtualizaHistoico(carrinho4.CarrinhoCliente);

        }

        public void iniciarHistoricoUsuario()
        {
            
        }

    }
}
