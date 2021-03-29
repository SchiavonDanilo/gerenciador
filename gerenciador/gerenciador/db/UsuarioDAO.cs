using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace gerenciador.db
{
    class UsuarioDAO
    {

        public static DataTable listar() {

            db.Banco objBanco = new db.Banco();
            DataTable tabela = new DataTable();
            objBanco.conectar();
            var cmd = objBanco.conexão.CreateCommand();
            cmd.CommandText = "SELECT * FROM Usuarios";
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd.CommandText, objBanco.conexão);
            da.Fill(tabela);
            objBanco.desconectar();
            return tabela;

        }
        public static bool cadastrar(Usuario user)
        {

            Banco Banco = new Banco();
            Banco.conectar();
            var cmd = Banco.conexão.CreateCommand();
            string novoCHA = EasyEncryption.SHA.ComputeSHA256Hash(user.Senha);
            cmd.CommandText = "INSERT INTO Usuarios(Nome , Email, Senha, Data)VALUES(@Nome, @Email, @Senha, @Data)";
            cmd.Parameters.AddWithValue("@Nome", user.Nome );
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@Senha", novoCHA);
            cmd.Parameters.AddWithValue("@Data", user.Data );

            cmd.ExecuteNonQuery();

            Banco.desconectar();

            return true;          

        }

        public static DataTable buscarusuario (int id)
        {
            Banco objBanco = new Banco();
            DataTable tabela = new DataTable();
            objBanco.conectar();
            var cmd = objBanco.conexão.CreateCommand();
            cmd.CommandText = "SELECT * FROM Usuarios WHERE id = " + id;
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd.CommandText, objBanco.conexão);
            da.Fill(tabela);
            objBanco.desconectar();

            return tabela;


        }

        public static bool Excluir(int id)
        {
            Banco banco = new Banco();
            banco.conectar();
            var cmd = banco.conexão.CreateCommand();


            cmd.CommandText = "DELETE  FROM Usuarios WHERE id=@idUser";

            cmd.Parameters.AddWithValue("@idUser", id);
            cmd.ExecuteNonQuery();


            banco.desconectar();

            return true;

        }

        public static bool Editar(Usuario user, int id)
        {
            Banco banco = new Banco();

            banco.conectar();

            var cmd = banco.conexão.CreateCommand();
            
           cmd.CommandText = "UPDATE Usuarios SET Nome= @Nome, Email = @Email, Senha = @Senha, Data = @Data WHERE id= @idUser ";
            string novoCHA = EasyEncryption.SHA.ComputeSHA256Hash(user.Senha);
            cmd.Parameters.AddWithValue("@Nome", user.Nome);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@Senha", novoCHA);
            cmd.Parameters.AddWithValue("@Data", user.Data);
            cmd.Parameters.AddWithValue("@idUser", id);
            cmd.ExecuteNonQuery();
            
            banco.desconectar();


            return true;
        }

    }
}
