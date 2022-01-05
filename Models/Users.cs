using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDBDemo.Models
{
    public class Users
    {
        [BsonId]
        public Guid Id { get; set; }

        public string KullanıcıAd { get; set; }
        public string KullanıcıSoyad { get; set; }
        public float KullanıcıBoy { get; set; }
        public float KullanıcıKilo { get; set; }
        public string KullanıcıMail { get; set; }
        public string KullanıcıŞifre { get; set; }
        public string KullanıcıTercihÇalışmaSüresi { get; set; }
        public string KullanıcınınYaptığıAktiviteTürü { get; set; }
        public List<ProgramModel> KullanıcıProgramı { get; set; }

    }
}
