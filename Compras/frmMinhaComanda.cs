using Classes.Dados;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compras
{
    public partial class frmMinhaComanda : Form
    {
        public frmMinhaComanda()
        {
            InitializeComponent();
        }

        private void FrmMinhaComanda_Load(object sender, EventArgs e)
        {
            try
            {
                DaoComandas dao = new DaoComandas();
                var lstComandas = dao.Listar();
                var source = (from t0 in lstComandas select new { t0.Produto.Nome, t0.Produto.Valor, t0.Quantidade }).ToList();
                 
                dgvComanda.AutoGenerateColumns = false;
                dgvComanda.DataSource = source;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
