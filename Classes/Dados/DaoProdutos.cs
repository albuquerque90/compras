using Classes.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Dados
{
    public class DaoProdutos : Dao<Produto>
    {
        public override Produto Buscar(int Id)
        {
            Produto retorno = new Produto();

            using (cn = new SqlConnection(url))
            {
                using (cmd = new SqlCommand())
                {
                    cn.Open();
                    cmd.Connection = cn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "SELECT * FROM TBProdutos WHERE Id = @Id";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Id", Id);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Produto produto = new Produto()
                        {
                            Id = (int)reader["Id"],
                            Nome = reader["Nome"].ToString(),
                            Valor = Convert.ToDecimal(reader["Valor"], CultureInfo.InvariantCulture.NumberFormat),
                            Detalhe = reader["Detalhes"].ToString()

                        };

                        retorno = produto;
                    }
                }
            }
            return retorno;
        }

        public override void Incluir(Produto entidade)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Produto> Listar()
        {
            List<Produto> lista = new List<Produto>();
            using (cn = new SqlConnection(url))
            {
                using (cmd = new SqlCommand())
                {
                    cn.Open();
                    cmd.Connection = cn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "SELECT * FROM TBProdutos";
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Produto produto = new Produto()
                        {
                            Id = (int)reader["Id"],
                            Nome = reader["Nome"].ToString(),
                            Valor = Convert.ToDecimal(reader["Valor"], CultureInfo.InvariantCulture.NumberFormat),
                            Detalhe = reader["Detalhes"].ToString()

                        };
                        lista.Add(produto);
                    }
                }
            }
            return lista;
        }
    }
}
