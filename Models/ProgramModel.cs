using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDBDemo.Models
{
    public class ProgramModel
    {
         
        [BsonId]
        public Guid Id { get; set; }
        public string ProgramAdı{ get; set; }
        public string ProgramBilgilendirmeYazısı { get; set; }
        public string ProgramTipi { get; set; }
        // ?
        public int ProgramYakılanKalori { get; set; }
        public string ProgramZorluğu { get; set; }
        // ?
        public List<string> ProgramGerekliEkipmanlarListesi { get; set; }
        // ?
        public string ProgramHedefKasBölgesi { get; set; }
        // Dakika olarak
        public int ProgramEgzersizSüresi { get; set; }
        // 3
        public int ProgramHaftadaGünSayısı { get; set; }
        // 6
        public int ProgramHaftaSayısı { get; set; }
        public ProgramDetayModel ProgramDetay { get; set; }
    }
}
