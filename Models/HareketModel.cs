using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDBDemo
{
    public class HareketModel
    {
        [BsonId]
        public Guid Id { get; set; }
        // Barbell Curl 
        public string HareketAdı { get; set; }
        // Dumbell
        public string HareketİçinGerekliEkipman { get; set; }
        // Kas Yapar
        public string HareketAçıklaması { get; set; }
        //
        public string HareketImagePath{ get; set; }
        public string HareketVideoPath { get; set; }
        public string HareketAudioPath { get; set; }
        // 3
        public string SetSayısı { get; set; }
        // 6
        public string TekrarSayısı { get; set; }
        // 120
        public int HareketYakılanKalori { get; set; }

    }
}
