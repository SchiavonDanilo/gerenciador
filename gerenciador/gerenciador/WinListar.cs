using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;



namespace gerenciador
{
    public partial class WinListar : Form
    {
        int idUser = 0;
        public WinListar()
        {
            InitializeComponent();
        }

        public void atualizardados() {
            dataGridView1.DataSource = db.UsuarioDAO.listar();
        }

        private void WinListar_Load(object sender, EventArgs e)
        {
            atualizardados();
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
           
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Form1 inicio = new Form1();
            this.Hide();
            inicio.ShowDialog();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
         
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            var dgv = (DataGridView)sender;
            int contlinhas = dgv.SelectedRows.Count;
            if (contlinhas > 0) {
                DataTable dt = new DataTable();
                idUser = int.Parse(dgv.SelectedRows[0].Cells[0].Value.ToString());
                dt = db.UsuarioDAO.buscarusuario(idUser);
                var linha = dt.Rows[0];
                txtNomeEditar.Text = linha.Field<string>("Nome").ToString();
                txtEmailEditar.Text = linha.Field<string>("Email").ToString();
                txtSenhaEditar.Text = linha.Field<string>("Senha").ToString();
                txtDataEditar.Text= linha.Field<decimal>("Data").ToString();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Usuario user = new Usuario();
            user.Nome = txtNomeEditar.Text;
            user.Email = txtEmailEditar.Text;
            user.Senha = txtSenhaEditar.Text;
            user.Data = txtDataEditar.Text;

           var resultado = db.UsuarioDAO.Editar(user, idUser);

            if (resultado == true)
            {
                MessageBox.Show("Usuario modificado com sucesso!");
                txtNomeEditar.Clear();
                txtEmailEditar.Clear();
                txtSenhaEditar.Clear();
                txtDataEditar.Clear();
                atualizardados();
            }
            else {
                MessageBox.Show("Erro");
            }

          
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
           var resultado = db.UsuarioDAO.Excluir(idUser);
            if (resultado == true)
            {
                MessageBox.Show("Informações deletadas");
                atualizardados();
            }
            else {
                MessageBox.Show("Erro");
            
            }


        }
    }
}
