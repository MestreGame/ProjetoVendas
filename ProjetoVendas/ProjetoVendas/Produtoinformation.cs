using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoVendas
{
    public class Produtoinformation
    {
		private int codigo;

		public int Codigo
		{
			get { return codigo; }
			set { codigo = value; }
		}

		private int fornecedor;

		public int Fornecedor
		{
			get { return fornecedor; }
			set { fornecedor = value; }
		}

		private int marca;

		public int Marca
		{
			get { return marca; }
			set { marca = value; }
		}

		private string nome;

		public string Nome
		{
			get { return nome; }
			set { nome = value; }
		}

		private int quantidade;

		public int Quantidade
		{
			get { return quantidade; }
			set { quantidade = value; }
		}

		private decimal valorunitario;

		public decimal Valorunitario
		{
			get { return valorunitario; }
			set { valorunitario = value; }
		}

		private string descricao;

		public string Descricao
		{
			get { return descricao; }
			set { descricao = value; }
		}


	}
}
