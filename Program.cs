using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace MongoDBDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create DB
            MongoCRUD db = new MongoCRUD("SportApp");

            // Inserting new record
            db.InsertRecord("Hareketler", new HareketModel { HareketAdı = "leg Press",HareketYakılanKalori=100 } );

            

            //// Returning model from db
            //var result = db.Load<BookModel>("Books");




            //// Returning model with Guid
            ////var IdResult = db.LoadWithyQuery<BookModel>("Books", new Guid("37f40443-185f-43b0-8d84-8ea41f7f600d"));


            //// Update
            //var record = db.LoadWithyQuery<BookModel>("Books", new Guid("37f40443-185f-43b0-8d84-8ea41f7f600d"));
            //record.BookName = "deneme 123 ";
            //db.UpdateRecord<BookModel>("Books", record.Id, record);


            //// Delete

            //db.DeleteRecord<BookModel>("Books", new Guid("37f40443-185f-43b0-8d84-8ea41f7f600d"));
        }
    }

     
     public class MongoCRUD
    {
         private IMongoDatabase db;

        public MongoCRUD(string database)
        {
            var client = new MongoClient();
            db = client.GetDatabase(database);
        }
        // Veri ekleme
        public void InsertRecord<T>(string table, T record)
        {
            var col = db.GetCollection<T>(table);
            col.InsertOne(record);
        }
        // Veri çekme (Bütün tabloyu çeke)
        public List<T> Load<T>(string tableName)
        {
            var col = db.GetCollection<T>(tableName);
            return col.Find(new BsonDocument()).ToList();
        }
        // ID bilgisine göre veri çekme
        public T LoadWithyQuery<T>(string tableName, Guid guid)
        {
            var col = db.GetCollection<T>(tableName);
            var filter = Builders<T>.Filter.Eq("Id", guid);
            return col.Find(filter).First();
        }
        // Girilen ID bilgisine göre güncelleme
        public void UpdateRecord<T>(string tableName, Guid guid , T record)
        {
            var col = db.GetCollection<T>(tableName);
            var result = col.ReplaceOne(new BsonDocument("_id", guid),record,new UpdateOptions { IsUpsert = true });
        }
        public void DeleteRecord<T>(string tableName , Guid guid)
        {
            var col = db.GetCollection<T>(tableName);
            var filter = Builders<T>.Filter.Eq("Id", guid);
            col.DeleteOne(filter);
        }


    }

}
