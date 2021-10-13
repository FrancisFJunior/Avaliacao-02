using LojaSuplemento.Objetos;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaSuplemento.Interface
{
    interface IManipulaProduto
    {
        public void AdicionarProduto(int idProduto);

        public void RemoverProduto(int idProduto);

        public void AtualizarProduto(int idProduto, int qtd);


    }
}
