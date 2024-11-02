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
        public int AlıcıID { get; set; }
        public int UrunID { get; set; }
        public int Miktar { get; set; }
        public bool SiparisDurumu { get; set; }
    }
}
