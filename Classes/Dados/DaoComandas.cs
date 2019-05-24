using Classes.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            throw new NotImplementedException();
        }
    }
}
