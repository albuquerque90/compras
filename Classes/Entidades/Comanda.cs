using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Entidades
{
    public class Comanda
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
    }
}
