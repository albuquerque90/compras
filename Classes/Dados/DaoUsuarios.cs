using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes.Entidades;
using System.Data.SqlClient;

namespace Classes.Dados
{
    public class DaoUsuarios : Dao<Usuario>
    {
        public override Usuario Buscar(int Id)
        {
            throw new NotImplementedException();
        }

        public Usuario Login(string Login, string Senha)
        {
            Usuario retorno = new Usuario();

            using (cn = new SqlConnection(url))
            {
                using (cmd = new SqlCommand())
                {
                    cn.Open();
                    cmd.Connection = cn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "SELECT Id, Nome, Login FROM TBUsuarios WHERE Login = @Id AND Senha = @Senha";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Id", Login);
                    cmd.Parameters.AddWithValue("@Senha", Senha);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Usuario usuarioDB = new Usuario()
                        {
                            Id = (int)reader["Id"],
                            Nome = reader["Nome"].ToString(),
                            Login = reader["Login"].ToString()
                        };

                        retorno = usuarioDB;
                    }
                }
            }
            return retorno;
        }

        public override void Incluir(Usuario entidade)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Usuario> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
