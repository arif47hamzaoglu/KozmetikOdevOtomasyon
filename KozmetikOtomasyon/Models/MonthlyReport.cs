namespace KozmetikOtomasyon.Models
{
    public class MonthlyReport
    {
        public int     AySayisi      { get; set; }
        public string  Ay            { get; set; }
        public int     ToplamSiparis { get; set; }
        public decimal ToplamCiro    { get; set; }
        public int     Onaylanan     { get; set; }
        public int     Bekleyen      { get; set; }
        public int     Iptal         { get; set; }
    }
}
