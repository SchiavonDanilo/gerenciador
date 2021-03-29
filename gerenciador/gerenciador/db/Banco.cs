using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Data;

namespace gerenciador.db
{
    class Banco
    {
        //Objeto de conexão
        public SQLiteConnection conexão;
        //Construtor de conexão
        public Banco()
        {
            //Apontar onde estará o arquivo do banco de dados
            conexão = new SQLiteConnection("Data Source = banco.sqlite2");
            //Verificar de banco.sqlite3 não existe
            if (!File.Exists("./banco.sqlite2"))
            {
                //Criar arquivo de banco de dados
                SQLiteConnection.CreateFile("banco.sqlite2");
            }
        }

        //Classe para conectar
        public void conectar()
        {
            //Verificar se a conexão não está aberta
            if (conexão.State != ConnectionState.Open)
            {
                //Abrir a conexão
                conexão.Open();
            }
        }


        //Classe para desconectar
        public void desconectar()
        {
            //Verificar se a conexão não está fechada
            if (conexão.State != ConnectionState.Closed)
            {
                //Fechar a conexão
                conexão.Close();
            }
        }
    }
}
