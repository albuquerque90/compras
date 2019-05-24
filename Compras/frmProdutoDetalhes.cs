using Classes.Dados;
using Classes.Entidades;
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
    public partial class frmProdutoDetalhes : Form
    {
        public frmProdutoDetalhes()
        {
            InitializeComponent();

            txtId.Text = frmProdutos._Produto.Id.ToString();
            txtNome.Text = frmProdutos._Produto.Nome;
            txtValor.Text = frmProdutos._Produto.Valor.ToString();
            txtDetalhe.Text = frmProdutos._Produto.Detalhe;
        }

        private void btnAdicionarComanda_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtQuantidade.Text))
                {
                    Comanda comanda = new Comanda()
                    {
                        Usuario = new Usuario() { Id = frmLogin._Usuario.Id, Nome = frmLogin._Usuario.Nome },
                        Produto = new Produto() { Id = Convert.ToInt32(txtId.Text), Nome = txtNome.Text, Valor = float.Parse(txtValor.Text) },
                        Quantidade = Convert.ToInt32(txtQuantidade.Text)
                    };

                    DaoComandas dao = new DaoComandas();
                    dao.Incluir(comanda);
                    MessageBox.Show("Produto Incluído na comanda", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Informe a quantidade", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
