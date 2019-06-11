using Classes.Dados;
using Classes.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compras
{
    public partial class frmProdutos : Form
    {
        #region Globais
        public static Produto _Produto = null;
        public IEnumerable<Produto> _LstProdutos { get; set; }
        #endregion

        public frmProdutos()
        {
            InitializeComponent();
        }

        private void frmProdutos_Load(object sender, EventArgs e)
        {
            try
            {
                GetAllProdutos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDetalhesProduto_Click(object sender, EventArgs e)
        {
            if (_Produto != null)
            {
                frmProdutoDetalhes frm = new frmProdutoDetalhes();
                frm.Show();

                this.Close();
            }
            else
            {
                MessageBox.Show("Selecione um produto", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DgvProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DgvProdutos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProdutos.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgvProdutos.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgvProdutos.Rows[selectedrowindex];

                int IdProduto = Convert.ToInt32(selectedRow.Cells[0].Value);

                _Produto = _LstProdutos.Where(p => p.Id == IdProduto).First();

                frmProdutoDetalhes frm = new frmProdutoDetalhes();
                frm.Show();

                Close();
            }
        }

        private void BtnAbrirComanda_Click(object sender, EventArgs e)
        {
            frmMinhaComanda frm = new frmMinhaComanda();
            frm.Show();
        }

        private async void GetAllProdutos()
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync("https://localhost:44339/api/produtos"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var ProdutoJsonString = await response.Content.ReadAsStringAsync();


                        _LstProdutos = JsonConvert.DeserializeObject<Produto[]>(ProdutoJsonString).ToList();
                        dgvProdutos.AutoGenerateColumns = false;
                        dgvProdutos.DataSource = _LstProdutos;
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível obter o produto : " + response.StatusCode);
                    }
                }
            }
        }
    }
}
