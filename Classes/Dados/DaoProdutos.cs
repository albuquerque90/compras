using Classes.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Dados
{
    public class DaoProdutos : Dao<Produto>
    {
        public override Produto Buscar(int Id)
        {
            throw new NotImplementedException();
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
                            Valor = float.Parse(reader["Valor"].ToString()),
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
