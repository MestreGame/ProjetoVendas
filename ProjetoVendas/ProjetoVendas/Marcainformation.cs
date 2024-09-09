using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoVendas
{
    public class Marcainformation
    {
		private int codigo;

		public int Codigo
		{
			get { return codigo; }
			set { codigo = value; }
		}

		private string nome;

		public string Nome
		{
			get { return nome; }
			set { nome = value; }
		}

		private string descricao;

		public string Descricao
		{
			get { return descricao; }
			set { descricao = value; }
		}



	}
}
