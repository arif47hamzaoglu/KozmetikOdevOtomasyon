using System;
using System.Linq;
using System.Windows.Forms;

namespace KozmetikOtomasyon.Forms
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            var years = DatabaseHelper.GetReportYears();
            cmbYear.DataSource = years;
            cmbYear.SelectedIndex = 0;
            LoadReport();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void LoadReport()
        {
            if (cmbYear.SelectedItem == null) return;
            int year = (int)cmbYear.SelectedItem;

            // Aylık özet
            var monthly = DatabaseHelper.GetMonthlyReport(year);
            dgvMonthly.DataSource = null;
            dgvMonthly.DataSource = monthly;

            if (dgvMonthly.Columns.Count > 0)
            {
                dgvMonthly.Columns["AySayisi"].Visible          = false;
                dgvMonthly.Columns["Ay"].HeaderText             = "Ay";
                dgvMonthly.Columns["ToplamSiparis"].HeaderText  = "Sipariş Sayısı";
                dgvMonthly.Columns["ToplamCiro"].HeaderText     = "Ciro (TL)";
                dgvMonthly.Columns["Onaylanan"].HeaderText      = "Onaylanan";
                dgvMonthly.Columns["Bekleyen"].HeaderText       = "Bekleyen";
                dgvMonthly.Columns["Iptal"].HeaderText          = "İptal";
            }

            // Yıllık özet
            if (monthly.Count > 0)
            {
                int     toplamSiparis = monthly.Sum(m => m.ToplamSiparis);
                decimal toplamCiro    = monthly.Sum(m => m.ToplamCiro);
                int     toplamOnay    = monthly.Sum(m => m.Onaylanan);
                int     toplamBekle   = monthly.Sum(m => m.Bekleyen);
                int     toplamIptal   = monthly.Sum(m => m.Iptal);

                lblSummary.Text =
                    $"{year} Yılı Toplamı:  " +
                    $"{toplamSiparis} Sipariş  |  " +
                    $"Ciro: {toplamCiro:N2} TL  |  " +
                    $"Onaylanan: {toplamOnay}  |  " +
                    $"Bekleyen: {toplamBekle}  |  " +
                    $"İptal: {toplamIptal}";
            }
            else
            {
                lblSummary.Text = $"{year} yılına ait sipariş bulunamadı.";
            }

            // En çok satan ürünler
            var topProducts = DatabaseHelper.GetTopProducts(year);
            dgvTopProducts.DataSource = null;
            dgvTopProducts.DataSource = topProducts;

            if (dgvTopProducts.Columns.Count > 0)
            {
                dgvTopProducts.Columns["UrunAdi"].HeaderText    = "Ürün Adı";
                dgvTopProducts.Columns["ToplamAdet"].HeaderText = "Toplam Satış (Adet)";
                dgvTopProducts.Columns["ToplamCiro"].HeaderText = "Toplam Ciro (TL)";
            }
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadReport();
        }
    }
}
