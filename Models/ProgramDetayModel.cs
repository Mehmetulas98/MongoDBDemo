using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDBDemo.Models
{
    public class ProgramDetayModel
    {
        public List<HareketModel> GöğüsHareketleri { get; set; }
        public List<HareketModel> BicepsHareketleri { get; set; }
        public List<HareketModel> TricepsHareketleri { get; set; }
        public List<HareketModel> OmuzHareketleri { get; set; }
        public List<HareketModel> SırtHareketleri { get; set; }
        public List<HareketModel> BacakHareketleri { get; set; }
        public List<HareketModel> KarınHareketleri { get; set; }
        public List<HareketModel> DiğerHarekeler { get; set; }
        public void TotalKalori()
        {
            //int;
        }
        public void TotalEkipmanListesi()
        {
            //string;
        }
        public void TotalKasBölgesiListesi()
        {
            //string;
        }
    }
}
  