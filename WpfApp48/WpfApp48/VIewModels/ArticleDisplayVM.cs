using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp48.ViewModels
{
    public class ArticleDisplayVM
    {
        public string ID { get; set; }
        public string ItemName { get; set; }
        public string Prijevodi { get; set; }
        public string ColorDescription { get; set; }
        public string ItemSize { get; set; }
        public string Gender { get; set; }
        public string BarCode { get; set; }
        public string So_Price { get; set; }
        public string CollectionCategory { get; set; }
    }
}

   

