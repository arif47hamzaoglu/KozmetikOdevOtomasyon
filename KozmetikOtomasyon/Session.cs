using System.Collections.Generic;
using KozmetikOtomasyon.Models;

namespace KozmetikOtomasyon
{
    public static class Session
    {
        public static User           CurrentUser { get; set; }
        public static List<CartItem> Cart        { get; set; } = new List<CartItem>();
    }
}
