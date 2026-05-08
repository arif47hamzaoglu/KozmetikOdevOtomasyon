namespace KozmetikOtomasyon.Forms
{
    partial class ReportForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle       = new System.Windows.Forms.Label();
            this.lblYearLabel   = new System.Windows.Forms.Label();
            this.cmbYear        = new System.Windows.Forms.ComboBox();
            this.btnLoad        = new System.Windows.Forms.Button();
            this.tabControl     = new System.Windows.Forms.TabControl();
            this.tabMonthly     = new System.Windows.Forms.TabPage();
            this.dgvMonthly     = new System.Windows.Forms.DataGridView();
            this.lblSummary     = new System.Windows.Forms.Label();
            this.tabTopProducts = new System.Windows.Forms.TabPage();
            this.dgvTopProducts = new System.Windows.Forms.DataGridView();
            this.tabControl.SuspendLayout();
            this.tabMonthly.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonthly)).BeginInit();
            this.tabTopProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopProducts)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location  = new System.Drawing.Point(10, 12);
            this.lblTitle.Size      = new System.Drawing.Size(300, 30);
            this.lblTitle.Text      = "Aylık Sipariş Raporu";

            // lblYearLabel
            this.lblYearLabel.Location = new System.Drawing.Point(330, 18);
            this.lblYearLabel.Size     = new System.Drawing.Size(35, 23);
            this.lblYearLabel.Text     = "Yıl:";

            // cmbYear
            this.cmbYear.Location              = new System.Drawing.Point(370, 15);
            this.cmbYear.Size                  = new System.Drawing.Size(90, 25);
            this.cmbYear.DropDownStyle         = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.SelectedIndexChanged += new System.EventHandler(this.cmbYear_SelectedIndexChanged);

            // btnLoad
            this.btnLoad.Location  = new System.Drawing.Point(470, 13);
            this.btnLoad.Size      = new System.Drawing.Size(75, 28);
            this.btnLoad.Text      = "Getir";
            this.btnLoad.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnLoad.ForeColor = System.Drawing.Color.White;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Click    += new System.EventHandler(this.btnLoad_Click);

            // tabControl
            this.tabControl.Location = new System.Drawing.Point(10, 52);
            this.tabControl.Size     = new System.Drawing.Size(755, 440);
            this.tabControl.Controls.Add(this.tabMonthly);
            this.tabControl.Controls.Add(this.tabTopProducts);

            // ── AYLIK ÖZET TABI ──────────────────────────
            this.tabMonthly.Text = "Aylık Özet";
            this.tabMonthly.Controls.Add(this.dgvMonthly);
            this.tabMonthly.Controls.Add(this.lblSummary);

            this.dgvMonthly.Location            = new System.Drawing.Point(5, 5);
            this.dgvMonthly.Size                = new System.Drawing.Size(738, 365);
            this.dgvMonthly.AllowUserToAddRows  = false;
            this.dgvMonthly.ReadOnly            = true;
            this.dgvMonthly.SelectionMode       = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMonthly.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMonthly.RowHeadersVisible   = false;

            this.lblSummary.Location  = new System.Drawing.Point(5, 378);
            this.lblSummary.Size      = new System.Drawing.Size(738, 28);
            this.lblSummary.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSummary.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lblSummary.Text      = "";

            // ── EN ÇOK SATAN TABI ────────────────────────
            this.tabTopProducts.Text = "En Çok Satan Ürünler";
            this.tabTopProducts.Controls.Add(this.dgvTopProducts);

            this.dgvTopProducts.Location            = new System.Drawing.Point(5, 5);
            this.dgvTopProducts.Size                = new System.Drawing.Size(738, 400);
            this.dgvTopProducts.AllowUserToAddRows  = false;
            this.dgvTopProducts.ReadOnly            = true;
            this.dgvTopProducts.SelectionMode       = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTopProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTopProducts.RowHeadersVisible   = false;

            // ReportForm
            this.ClientSize      = new System.Drawing.Size(775, 505);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text            = "Aylık Sipariş Raporu";
            this.Load           += new System.EventHandler(this.ReportForm_Load);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblYearLabel);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.tabControl);
            this.tabControl.ResumeLayout(false);
            this.tabMonthly.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonthly)).EndInit();
            this.tabTopProducts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopProducts)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label        lblTitle;
        private System.Windows.Forms.Label        lblYearLabel;
        private System.Windows.Forms.ComboBox     cmbYear;
        private System.Windows.Forms.Button       btnLoad;
        private System.Windows.Forms.TabControl   tabControl;
        private System.Windows.Forms.TabPage      tabMonthly;
        private System.Windows.Forms.DataGridView dgvMonthly;
        private System.Windows.Forms.Label        lblSummary;
        private System.Windows.Forms.TabPage      tabTopProducts;
        private System.Windows.Forms.DataGridView dgvTopProducts;
    }
}
