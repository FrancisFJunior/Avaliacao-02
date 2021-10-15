using LojaSuplemento.Objetos;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaSuplemento.Recomendador
{
    abstract class BaseRecomendador
    {
        public abstract List<SimilaridadeCliente> ComparaClientes(Cliente thisUser, BancoDadosClientes bancoDadosClientes);

        public abstract List<Produto> getHistoricoClienteMaiorAfinidade(List<SimilaridadeCliente> clientesParecidos, BancoDadosClientes bancoDadosClientes);

        public abstract List<Produto> ListaProdutosRecomendados(Cliente cliente, List<Produto> historicoClienteMaiorAfinidade);
    }
}
