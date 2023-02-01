using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Crypto_Info
{
    public class PopularAssets
    { 
        public string ?  Name { get; set; }
        public decimal ? Precent { get; set; }
        public string ? Icon { get; set; }

        public Brush? ColorPrecent{get; set; }
        public PopularAssets(string ? name, decimal ? precent, string ? icon, Brush? ColorPrecent)
        {
            Name = name;
            Precent = precent;
            Icon = icon;
            this.ColorPrecent = ColorPrecent;
        }
    }
}
