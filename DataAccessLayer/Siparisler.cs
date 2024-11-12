using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Siparisler
    {
        public int ID { get; set; }
        public int AliciID { get; set; }
        public int UrunID { get; set; }
        public string UrunIsim { get; set; }
        public int TurID { get; set; }
        public string TurIsim { get; set; }
        public int Miktar { get; set; }
        public int DurumID { get; set; }
        public string DurumIsim { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamFiyat { get; set; }
        public DateTime Tarih { get; set; }
    }
}
