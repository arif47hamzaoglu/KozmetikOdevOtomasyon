using System;
using System.Windows.Forms;
using KozmetikOtomasyon.Forms;

namespace KozmetikOtomasyon
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Veritabanını başlat (tablolar yoksa oluşturur)
            DatabaseHelper.Initialize();

            // İlk açılan form Login formu
            Application.Run(new LoginForm());
        }
    }
}
