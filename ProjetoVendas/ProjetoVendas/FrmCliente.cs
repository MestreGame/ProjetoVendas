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
            lblData.Text= DateTime.Now.ToLongDateString();
            //Vai atualizar o dgCliente
            atualizaGrid();//chamada da função
        }
        //Criar instancia global da conexão
        SqlConnection conn = new SqlConnection(Dados.Conexao);

        public void atualizaGrid()
        {
            atualizaGrid(dgCliente);
        }

        public void atualizaGrid(DataGridView dgCliente)//criação da função
        {
            try
            {
                dgCliente.DataSource = listarCliente();
                dgCliente.Columns[0].HeaderText = "Cód.";
                dgCliente.Columns[1].HeaderText = "Nome";
                dgCliente.Columns[2].HeaderText = "Cpf";
                dgCliente.Columns[3].HeaderText = "Rua";
                dgCliente.Columns[4].HeaderText = "Numero";
                dgCliente.Columns[5].HeaderText = "Cep";
                dgCliente.Columns[6].HeaderText = "Telefone";
                dgCliente.Columns[7].HeaderText = "Cidade";
                dgCliente.Columns[8].HeaderText = "UF";

                //largura das colunas
                dgCliente.Columns[0].Width = 50;
                dgCliente.Columns[1].Width = 150;
                dgCliente.Columns[2].Width = 100;
                dgCliente.Columns[3].Width = 150;
                dgCliente.Columns[4].Width = 50;
                dgCliente.Columns[5].Width = 80;
                dgCliente.Columns[6].Width = 80;
                dgCliente.Columns[7].Width = 150;
                dgCliente.Columns[8].Width = 50;

                //permissão e restrições do usuario
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
        public static DataTable listarCliente()
        {
            try
            {
                SqlConnection conn = new SqlConnection(Dados.Conexao);
                conn.Open();
                string sqlListar = "Select * from cliente";
                //vamos utilizar uma classe adaptador para receber os dados da tabela cliente
                SqlDataAdapter da=new SqlDataAdapter(sqlListar, conn);
                //estamos chamando uma classe do tipo Tabela
                DataTable dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                return dt;

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao listar clientes! - ", erro.Message);
                return null;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

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

        private void btnInserir_Click(object sender, EventArgs e)
        {
            //trabalhar com tratamento de erros
            //atalho: try+tab
            try
            {
                //validar campos obrigatorios
                if(txtCep.Text==""||txtCidade.Text==""||txtCPF.Text==""||txtNome.Text==""||txtNumero.Text==""||txtRua.Text==""||txtTelefone.Text==""||cbUF.Text=="")
                {
                    MessageBox.Show("Preencha os campos", "Sistema de vendas", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
                else
                {
                    //abrir conexão
                    conn.Open();
                    //o sistema vai capturar os dados dos txtbox's
                    //para enviar ao banco de dados
    
                    string sql = "Insert into cliente(nome,cpf,rua,numero,cep,telefone,cidade,uf)values(@nome,@cpf,@rua,@numero,@cep,@telefone,@cidade,@uf)";
                    //a classe SqlCommand vai tratar a var sql com a instrução
                    //do banco, utilizando a conexão
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = txtNome.Text;
                    cmd.Parameters.Add("@cpf", SqlDbType.VarChar).Value = txtCPF.Text;
                    cmd.Parameters.Add("@rua", SqlDbType.VarChar).Value = txtRua.Text;
                    cmd.Parameters.Add("@numero", SqlDbType.Int).Value = Convert.ToInt32( txtNumero.Text);
                    cmd.Parameters.Add("@cep", SqlDbType.VarChar).Value = txtCep.Text;
                    cmd.Parameters.Add("@telefone", SqlDbType.VarChar).Value = txtTelefone.Text;
                    cmd.Parameters.Add("@cidade", SqlDbType.VarChar).Value = txtCidade.Text;
                    cmd.Parameters.Add("@uf", SqlDbType.VarChar).Value = cbUF.Text;

                    //se tudo estiver ok,vai rxecutar a query
                    cmd.ExecuteNonQuery();
                    
                    conn.Close();
                    MessageBox.Show("Cliente inserido com sucesso!","Cadastro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    atualizaGrid();
                }  
                    
                   
            }
            catch (SqlException erro)
            {
                MessageBox.Show("Erro ao cadastrar cliente: " + erro);

            }

        }
    }
}
