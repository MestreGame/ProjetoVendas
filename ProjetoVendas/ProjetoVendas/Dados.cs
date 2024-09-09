using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoVendas
{
    public class Dados
    {
        public static string Conexao
        {
            get
            {
                return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\matheus.psouza13\source\repos\ProjetoVendas\ProjetoVendas\ProjetoVendas.mdf;Integrated Security=True;Connect Timeout=30";
            }
        }
    }
}
