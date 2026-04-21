using KozmetikOtomasyon.Models;

namespace KozmetikOtomasyon
{
    // Giriş yapan kullanıcıyı tüm formlardan erişilebilir şekilde tutar
    public static class Session
    {
        public static User CurrentUser { get; set; }
    }
}
