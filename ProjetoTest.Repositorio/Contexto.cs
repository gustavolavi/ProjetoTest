using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTest.Repositorio
{
    public class Contexto:IDisposable
    {
        private readonly SqlConnection _minhaConexao;

        public Contexto()
        {
            _minhaConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnect"].ConnectionString);
            _minhaConexao.Open();
        }

        public void Gravacao(string strQuery)
        {
            var cmdCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = _minhaConexao,
                CommandText = strQuery
            };
            cmdCommand.ExecuteNonQuery();
        }

        public SqlDataReader Leitura(string strQuery)
        {
            var cmdCommand = new SqlCommand(strQuery, _minhaConexao);
            return cmdCommand.ExecuteReader();
        }

        public void Dispose()
        {
           if (_minhaConexao.State == ConnectionState.Open)
                _minhaConexao.Close();
        }
    }
}
