using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Classes.Entidades;
using Classes.Dados;

namespace Compras
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtLogin.Text) && !string.IsNullOrEmpty(txtSenha.Text))
                {
                    DaoUsuarios dao = new DaoUsuarios();
                    var login = dao.Login(txtLogin.Text, txtSenha.Text);

                    if (login.Id > 0)
                    {
                        
                        frmProdutos f = new frmProdutos();
                        f.Show();
                    }
                    else
                        MessageBox.Show("Não achou");
                }
                else
                {
                    MessageBox.Show("Informe um Login e Senha", "Alerta",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
