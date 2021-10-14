using LojaSuplemento.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using LojaSuplemento.Helpers;

namespace LojaSuplemento.Objetos
{
    public class Produto : IManipulaProduto
    {
        private List<Produto> produto ;
        protected string nome;
        protected int idProduto;
        protected string descricao;
        protected int qtd;
        protected double valor;
        public Produto()
        {
            produto = new List<Produto>();
        }
        public Produto(int idProduto, string nome, string descricao, int qtd, double valor)
        {
            this.nome = nome;
            this.idProduto = idProduto;
            this.descricao = descricao;
            this.qtd = qtd;
            this.valor = valor;
        }
       

        public void AdicionarProduto(int idProduto){}

        public void RemoverProduto(int idProduto)
        {
            var item = HelperManipulaProduto.VerificaProduto(idProduto);
            if (item.IDProduto == idProduto)
                {
                    produto.Remove(item);
                }
                else
                {
                    Console.WriteLine("Não existe esse produto na loja!");
                }

        }

        public void AtualizarProduto(int idProduto, int qtd)
        {
            var item = HelperManipulaProduto.VerificaProduto(idProduto);
            if (item.IDProduto == idProduto)
            {
                    HelperManipulaProduto.EditarProduto(item);
            }
            
        }

        public void AdicionarProduto(int idProduto)
        {
            throw new NotImplementedException();
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public int IDProduto
        {
            get { return idProduto; }
            set { idProduto = value; }
        }
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }
        public int Quantidade
        {
            get { return qtd; }
            set { 
                if (value <= Quantidade)
                {
                    Console.WriteLine("Não possue essa quantidade no estoque");
                }
                else
                {
                    qtd = value;
                }
            }
        }
        public double Valor
        {
            get { return valor; }
            set { valor = value; }
        }
        public List<Produto> Produtos
        {
            get { return produto; }
            
        }
    }
}

