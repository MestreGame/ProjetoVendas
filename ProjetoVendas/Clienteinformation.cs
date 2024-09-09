using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoVendas
{
    public class Clienteinformation
    {
        //Encapsulamento das propriedades
        //atalho: propfull + tab

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

        private string cpf;

        public string Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }

        private string rua;

        public string Rua
        {
            get { return rua; }
            set { rua = value; }
        }

        private int numero;

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        private string cep;

        public string Cep
        {
            get { return cep; }
            set { cep = value; }
        }

        private string telefone;

        public string Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }

        private string cidade;

        public string Cidade
        {
            get { return cidade; }
            set { cidade = value; }
        }

        private string uf;

        public string Uf
        {
            get { return uf; }
            set { uf = value; }
        }




    }
}
