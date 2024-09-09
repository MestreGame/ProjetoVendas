using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;//em todas telas

namespace ProjetoVendas
{
    public partial class FrmCliente : Form
    {
        public FrmCliente()
        {
            InitializeComponent();

            //configurar lblData
            lblData.Text = DateTime.Now.ToLongDateString();
            // vai atualizar o dgCliente
            atualizaGrud();
        }
        //Criar instancia global da conexão
        SqlConnection conn = new SqlConnection(Dados.Conexao);

        public void atualizaGrud()//criação da função
        {
            try
            {
                dgCliente.DataSource = listarClientes();

                //criar a estrutura de cabeçalho dos campos
                dgCliente.Columns[0].HeaderText = "Cod.";
                dgCliente.Columns[1].HeaderText = "Nome.";
                dgCliente.Columns[2].HeaderText = "CPF.";
                dgCliente.Columns[3].HeaderText = "RUA.";
                dgCliente.Columns[4].HeaderText = "N.";
                dgCliente.Columns[5].HeaderText = "CEP.";
                dgCliente.Columns[6].HeaderText = "Telefone.";
                dgCliente.Columns[7].HeaderText = "CIDADE.";
                dgCliente.Columns[8].HeaderText = "UF.";

                //LARGURA DAS COLUNAS

                dgCliente.Columns[0].Width = 50;
                dgCliente.Columns[1].Width = 150;
                dgCliente.Columns[2].Width = 100;
                dgCliente.Columns[3].Width = 150;
                dgCliente.Columns[4].Width = 50;
                dgCliente.Columns[5].Width = 80;
                dgCliente.Columns[6].Width = 80;
                dgCliente.Columns[7].Width = 150;
                dgCliente.Columns[8].Width = 50;

                //PERMISSÕES E RESTRIÇÃO DO USUARIO
                dgCliente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgCliente.AllowUserToAddRows = false;
                dgCliente.AllowUserToDeleteRows = false;
                dgCliente.ReadOnly = true;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao listar clientes - " + erro);
            }
        }
        public static DataTable listarClientes()
        {
            try
            {
                SqlConnection con = new SqlConnection(Dados.Conexao);
                con.Open();
                string sqlListar = "Seletect * from cliente";
                //vamos utilizar uma classe adapatdor para receber os
                //dados da tabela cliente
                SqlDataAdapter da = new SqlDataAdapter(sqlListar, con);
                //estamos chamando uma classe do tipo Tabela
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                return dt;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao  listar clientes! - " + erro.Message);
                return null;

            }

            private void timer1_Tick(object sender, EventArgs e)
            {
                //configurar a lblHora
                lblHora.Text = DateTime.Now.ToLongTimeString();
            }

            private void btnConexão_Click(object sender, EventArgs e)
            {
                //efetuar o teste de conexão
                //importar bibliotecas SQL
                conn.Open();
                MessageBox.Show("Conexão ok!");
                conn.Close();
            }

            private void txtCPF_TextChanged(object sender, EventArgs e)
            {
                if (ValidaCPF.IsCpf(txtCPF.Text))
                {
                    lblCPF.Text = "CPF Válido !";
                }
                else
                {
                    lblCPF.Text = "CPF Inválido !";
                }
            }


            public void Limpar()
            {
                txtCep.Clear();
                txtCPF.Clear();
                txtCodigo.Clear();
                txtCPFp.Clear();
                txtCidade.Clear();
                txtNome.Clear();
                txtNomeP.Clear();
                txtNumero.Clear();
                txtRua.Clear();
                txtTelefone.Clear();
                lblCPF.Text = "";
                cbStatus.SelectedIndex = 0;
                cbUF.SelectedIndex = -1;
                txtCPF.Focus();
            }
            private void btnImprimir_Click(object sender, EventArgs e)
            {
                Limpar();
            }
        }
    }
}
