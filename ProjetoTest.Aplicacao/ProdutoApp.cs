using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoTest.Dominio;
using ProjetoTest.Repositorio;

namespace ProjetoTest.Aplicacao
{
    public class ProdutoApp
    {
        private Contexto contexto;

        private void Inserir(Produto produto)
        {
            var strQuery = "";
            strQuery += "INSERT INTO Produto (Nome, Preco, Quantidade) ";
            strQuery += string.Format(" VALUES('{0}','{1}','{2}') ", produto.Nome, produto.Preco, produto.Quantidade);
            using (contexto = new Contexto())
            {
                contexto.Gravacao(strQuery);
            }
        }

        private void Alterar(Produto produto)
        {
            var strQuery = "";
            strQuery += "UPDATE Produto SET ";
            strQuery += string.Format(" Nome='{0}', Preco='{1}', Quantidade='{2}' ", produto.Nome, produto.Preco,
                produto.Quantidade);
            strQuery += string.Format("WHERE Id ='{0}' ", produto.Id);
            using (contexto = new Contexto())
            {
                contexto.Gravacao(strQuery);
            }
        }

        public void Salvar(Produto produto)
        {
            if (produto.Id > 0)
            {
                Alterar(produto);
            }
            else
            {
                Inserir(produto);
            }
        }

        public void Excluir(int id)
        {
            var strQuery = string.Format(" DELETE FROM Produto WHERE Id = {0}", id);
            using (contexto = new Contexto())
            {
             contexto.Gravacao(strQuery);
            }
        }

        public List<Produto> Lista()
        {
            using (contexto = new Contexto())
            {
                var strQuery = "SELECT * FROM Produto";
                var reader = contexto.Leitura(strQuery);
                return convertReader(reader);
            }
            
        }

        public Produto ListarId(int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format("SELECT * FROM Produto WHERE Id='{0}'", id);
                var reader = contexto.Leitura(strQuery);
                return convertReader(reader).FirstOrDefault();
            }
        } 

        private List<Produto> convertReader(SqlDataReader reader)
        {
            var usuarios = new List<Produto>();
            while (reader.Read())
            {
                var objeto = new Produto()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nome = reader["Nome"].ToString(),
                    Preco = double.Parse(reader["Preco"].ToString()),
                    Quantidade = int.Parse(reader["Quantidade"].ToString()),
                };
                usuarios.Add(objeto);
            }
            return usuarios;
        }
    }
}
