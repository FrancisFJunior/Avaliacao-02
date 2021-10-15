using System;
using LojaSuplemento.Fluxo;

namespace LojaSuplemento
{
    class Program
    {
        static void Main(string[] args)
        {
            
            FluxoLoja fluxoLoja = new FluxoLoja();
            fluxoLoja.iniciaDados();
            fluxoLoja.TelaPrincipal();
            

        }

    }
}
