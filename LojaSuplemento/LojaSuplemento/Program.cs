using System;
using LojaSuplemento.Fluxo;
using LojaSuplemento.Dados;

namespace LojaSuplemento
{
    class Program
    {
        static void Main(string[] args)
        {
            
            FluxoLoja fluxoLoja = new FluxoLoja();
            DadosIniciais indados = new DadosIniciais();
            indados.iniciaDados();
            fluxoLoja.TelaPrincipal();
            

        }

    }
}
