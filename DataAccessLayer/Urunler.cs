using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Urunler
    {
        public int ID { get; set; }
        public string Isim { get; set; }
        public string Satici { get; set; }
        public int UreticiUlke { get; set; }
        public decimal Fiyat { get; set; }
        public int Stok { get; set; }
        public bool Satistami { get; set; }
        public string SatistamiStr { get; set; }
    }
}
