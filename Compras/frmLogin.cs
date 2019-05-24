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
        public static Usuario _Usuario = null;

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
                    _Usuario = dao.Login(txtLogin.Text, txtSenha.Text);

                    if (_Usuario.Id > 0)
                    {                        
                        frmProdutos f = new frmProdutos();
                        f.Show();
                        
                    }
                    else
                        MessageBox.Show("Login ou senha inválidos", "Alerta", 
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Informe um Login e Senha", "Alerta",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
