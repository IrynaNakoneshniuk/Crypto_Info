﻿using System;
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
       
        public string? Id{get; set; }
        public PopularAssets(string ? name, decimal ? precent, string ? icon, string? Id)
        {
            Name = name;
            Precent = precent;
            Icon = icon;
            this.Id = Id;
        }
    }
}
