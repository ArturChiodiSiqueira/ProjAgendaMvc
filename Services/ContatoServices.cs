using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Services
{
    public class ContatoServices
    {
        static string Conexao = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\artur\source\repos\ProjAgendaMvc\Services\Banco\Agenda.mdf;Integrated Security=True;Connect Timeout=3";

        SqlConnection conexaoBD = new SqlConnection(Conexao);
        public Contato InserirContato(Contato contato)
        {
            conexaoBD.Open();

            SqlCommand dataInsert = new SqlCommand();

            dataInsert.CommandText = "INSERT into Contatos (Nome, Telefone) VALUES (@Nome, @Telefone);";
            //dataInsert.CommandText = $"INSERT into Contatos (Nome, Telefone) VALUES ('{contato.Nome}','{contato.Telefone}')";

            dataInsert.Parameters.Add(new SqlParameter("@Nome", contato.Nome));
            dataInsert.Parameters.Add(new SqlParameter("@Telefone", contato.Telefone));

            dataInsert.Connection = conexaoBD;
            dataInsert.ExecuteNonQuery();

            conexaoBD.Close();
            return contato;
        }

        public List<Contato> ConsultaTodos()
        {
            conexaoBD.Open();

            SqlCommand dataSelect = new SqlCommand();

            dataSelect.CommandText = "Select * from Contatos";
            dataSelect.Connection = conexaoBD;

            List<Contato> agenda = new List<Contato>();

            SqlDataReader dataReader = dataSelect.ExecuteReader();

            while (dataReader.Read())
            {
                Contato c = new();
                c.Id = dataReader.GetInt32(0);
                c.Nome = dataReader.GetString(1);
                c.Telefone = dataReader.GetString(2);
                agenda.Add(c);
            }

            conexaoBD.Close();
            return agenda;
        }
    }
}
