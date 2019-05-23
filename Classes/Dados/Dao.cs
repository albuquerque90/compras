using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Classes.Dados
{
    public abstract class Dao<T>
    {
        protected SqlConnection cn;
        protected SqlCommand cmd;
        protected SqlDataReader reader;

        protected string url = ConfigurationManager.ConnectionStrings["conexao"].ToString();

        public abstract void Incluir(T entidade);
        public abstract IEnumerable<T> Listar();
        public abstract T Buscar(int Id);
    }
}
