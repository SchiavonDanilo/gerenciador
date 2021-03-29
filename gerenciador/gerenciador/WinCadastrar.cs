using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gerenciador
{
    public partial class WinCadastrar : Form
    {
        public WinCadastrar()
        {
            InitializeComponent();
        }

        //MÉTODO DO BOTÃO CADASTRAR
        private void btnCadastrar2_Click(object sender, EventArgs e)
        {
            //CRIANDO NOVO OBJETO USER
            Usuario user = new Usuario();
            //USER.NOME RECEBE O NOME QUE O USUARIO DIGITAR
            user.Nome = txtNome.Text;
            //USER.EMAIL RECEBE O EMAIL QUE O USUARIO DIGITAR
            user.Email = txtEmailCadastro.Text;
            //USER.SENHA RECEBE A SENHA QUE O USUARIO DIGITAR
            user.Senha = txtSenhaCadastro.Text;
            //USER.DATA RECEBE A DATA DE NASCIMENTO QUE O USUARIO DIGITAR
            user.Data = txtData.Text;
            //DECLARANDO ATRIBUTO RESULTADO E ATRIBUINDO O SEU VALOR 
          var resultado =  db.UsuarioDAO.cadastrar(user);
            //DECLARANDO FUNÇÃO IF CASO RESULTADO SEJA IGUAL A TRUE
            if (resultado == true)
            {
                //MENSAGEM APRESENTADA CASO O CADASTRO SEJA EFETUADO COM SUCESSO
                MessageBox.Show("Usuario cadastrado com sucesso");
                //LIMPA CAMPO NOME
                txtNome.Clear();
                //LIMPA CAMPO EMAIL
                txtEmailCadastro.Clear();
                //LIMPA CAMPO CADASTRO
                txtSenhaCadastro.Clear();
                //LIMPA CAMPO DATA
                txtData.Clear();
            }
            //DECLARANDO FUNÇÃO ELSE CASO OS DADOS NÃO SEJAM CADASTRADOS COM SUCESSO
            else {
                //MENSAGEM DE ERRO A SER APRESENTADA
                MessageBox.Show("ERRO! Verifique os dados informados");
            }

           
        }
        //MÉTODO DO BOTÃO VOLTAR
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            //DECLARANDO NOVO OBJETO INICIO
            Form1 inicio = new Form1();
            //OCULTADO TELA ATUAL
            this.Hide();
            //DEMONSTRANDO TELA DE INCIO
            inicio.ShowDialog();
        }
    }
    
}
