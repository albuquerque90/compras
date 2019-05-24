namespace Compras
{
    partial class frmMinhaComanda
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvComanda = new System.Windows.Forms.DataGridView();
            this.colProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComanda)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvComanda
            // 
            this.dgvComanda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComanda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProduto,
            this.colValor,
            this.colQuantidade});
            this.dgvComanda.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvComanda.Location = new System.Drawing.Point(0, 0);
            this.dgvComanda.Name = "dgvComanda";
            this.dgvComanda.Size = new System.Drawing.Size(800, 257);
            this.dgvComanda.TabIndex = 0;
            // 
            // colProduto
            // 
            this.colProduto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colProduto.DataPropertyName = "Nome";
            this.colProduto.HeaderText = "Produto";
            this.colProduto.Name = "colProduto";
            // 
            // colValor
            // 
            this.colValor.DataPropertyName = "Valor";
            this.colValor.HeaderText = "Valor";
            this.colValor.Name = "colValor";
            // 
            // colQuantidade
            // 
            this.colQuantidade.DataPropertyName = "Quantidade";
            this.colQuantidade.HeaderText = "Quantidade";
            this.colQuantidade.Name = "colQuantidade";
            // 
            // frmMinhaComanda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 264);
            this.Controls.Add(this.dgvComanda);
            this.Name = "frmMinhaComanda";
            this.Text = "Minha Comanda";
            this.Load += new System.EventHandler(this.FrmMinhaComanda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvComanda)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvComanda;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantidade;
    }
}