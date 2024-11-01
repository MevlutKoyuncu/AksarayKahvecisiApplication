using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Alicilar
    {
        public  int ID { get; set; }
        public string Isim { get; set; }
        public int UyelikTur_ID { get; set; }
        public string UyelikTur { get; set; }
        public string GorusulenKisi { get; set; }
        public string Telefon { get; set; }
        public string Sehir { get; set; }
        public string Adres { get; set; }
        public bool AktifMi { get; set; }
        public string AktifMiStr { get; set; }

    }
}
