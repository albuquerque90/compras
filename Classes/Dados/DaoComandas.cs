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
    public class DaoComandas : Dao<Comanda>
    {
        public override Comanda Buscar(int Id)
        {
            throw new NotImplementedException();
        }

        public override void Incluir(Comanda entidade)
        {
            using (cn = new SqlConnection(url))
            {
                using (cmd = new SqlCommand())
                {
                    cn.Open();
                    cmd.Connection = cn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO TBComanda (IdUsuario,IdProduto,Quantidade) VALUES (@IdUsuario,@IdProduto,@Quantidade)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@IdUsuario", entidade.Usuario.Id);
                    cmd.Parameters.AddWithValue("@IdProduto", entidade.Produto.Id);
                    cmd.Parameters.AddWithValue("@Quantidade", entidade.Quantidade);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public override IEnumerable<Comanda> Listar()
        {
            List<Comanda> lista = new List<Comanda>();
            using (cn = new SqlConnection(url))
            {
                using (cmd = new SqlCommand())
                {
                    cn.Open();
                    cmd.Connection = cn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = @"SELECT c.Id AS IdComanda, u.Nome AS Usuario, u.Login, p.Nome AS Produto, p.Valor, p.Detalhes, c.Quantidade FROM TBComanda c
                                            join TBUsuarios u on c.IdUsuario = u.Id
                                            join TBProdutos p on c.IdProduto = p.Id";
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Comanda comanda = new Comanda()
                        {
                            Id = Convert.ToInt32(reader["IdComanda"]),
                            Usuario = new Usuario()
                            {
                                Login = reader["Login"].ToString(),
                                Nome = reader["Usuario"].ToString()
                            },
                            Produto = new Produto()
                            {
                                Nome = reader["Produto"].ToString(),
                                Valor = Convert.ToDecimal(reader["Valor"], CultureInfo.InvariantCulture.NumberFormat),
                                Detalhe = reader["Detalhes"].ToString()
                            },
                            Quantidade = Convert.ToInt32(reader["Quantidade"])

                        };
                        lista.Add(comanda);
                    }
                }
            }
            return lista;
        }
    }
}
