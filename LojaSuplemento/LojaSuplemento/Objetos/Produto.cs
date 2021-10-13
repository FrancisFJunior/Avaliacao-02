using LojaSuplemento.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaSuplemento.Objetos
{
    public class Produto : IManipulaProduto
    {
        private List<Produto> produto;
        protected string nome;
        protected int idProduto;
        protected string descricao;
        protected int qtd;
        protected double valor;
        public Produto()
        { }
        public Produto(int idProduto, string nome, string descricao, int qtd, double valor)
        {
            produto = new List<Produto>();
            this.nome = nome;
            this.idProduto = idProduto;
            this.descricao = descricao;
            this.qtd = qtd;
            this.valor = valor;
        }
       

        public void AdicionarProduto(int idProduto)
        {
            foreach (var item in produto)
            {
                if (item.IDProduto != idProduto)
                {
                    produto.Add(item);
                }
                else
                {
                    Console.WriteLine("Não existe esse produto na loja!");
                }

            }
        }

        public void RemoverProduto(int idProduto)
        {
            
            foreach (var item in produto)
            {
                if (item.IDProduto == idProduto)
                {
                    produto.Remove(item);
                }
                else
                {
                    Console.WriteLine("Não existe esse produto na loja!");
                }

            }
        }

        public void AtualizarProduto(int idProduto)
        {
            throw new NotImplementedException();
        }

        public string Nome
        {
            get { return nome; }
        }
        public int IDProduto
        {
            get { return idProduto; }
        }
        public string Descricao
        {
            get { return descricao; }
        }
        public int Quantidade
        {
            get { return qtd; }
        }
        public double Valor
        {
            get { return valor; }
        }
        public List<Produto> Produtos
        {
            get { return produto; }
        }
    }
}

