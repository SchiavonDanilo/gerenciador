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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //MÉTODO PARA O BOTÃO CADASTRAR
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            //DECLARANDO OBJETO CADASTRAR
            WinCadastrar cadastrar = new WinCadastrar();
            //ESCONDENDO TELA ATUAL
            this.Hide();
            //MOSTRANDO NOVA JANELA
            cadastrar.ShowDialog();
        }

        //MÉTODO PARA O BOTÃO LOGAR
        private void btnListar_Click(object sender, EventArgs e)
        {
            //DECLARANDO FUNÇÃO IF CASO O CAMPO EMAIL NÃO SEJA PREENCHIDO
            if (txtEmail.Text == "")
            {
                //DEMONSTRANDO MENSAGEM DE ERRO
                MessageBox.Show("Insira o e-mail");
            }
            //DECLARANDO FUNÇÃO ELSE IF CASO O CAMPO SENHA NÃO SEJA PREENCHIDO
            else if (txtSenha.Text == "")
            {
                //DEMONSTRANDO MENSAGEM DE ERRO
                MessageBox.Show("Insira a senha");
            }
            //DECLARANDO FUNÇÃO ELSE CASO NÃO SEJA ENCONTRADO NENHUM ERRO
            else {
                WinListar listar = new WinListar();
                this.Hide();
                listar.ShowDialog();
            }

            


        }
    }
}
