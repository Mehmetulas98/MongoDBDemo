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
            MongoCRUD db = new MongoCRUD("Library");

            // Inserting new record
            //db.InsertRecord("Books", new BookModel { BookName = "LOTR 2 ", PageNumber = 20, Company = "Yayıncılık"  } );

            

            // Returning model from db
            var result = db.Load<BookModel>("Books");




            // Returning model with Guid
            //var IdResult = db.LoadWithyQuery<BookModel>("Books", new Guid("37f40443-185f-43b0-8d84-8ea41f7f600d"));


            // Update
            var record = db.LoadWithyQuery<BookModel>("Books", new Guid("37f40443-185f-43b0-8d84-8ea41f7f600d"));
            record.BookName = "deneme 123 ";
            db.UpdateRecord<BookModel>("Books", record.Id, record);


            // Delete

            db.DeleteRecord<BookModel>("Books", new Guid("37f40443-185f-43b0-8d84-8ea41f7f600d"));
        }
    }

    public class BookModel
    {
        [BsonId]
        public Guid Id { get; set; }
        public string BookName{ get; set; }
        public int PageNumber { get; set; }

        public string Company { get; set; }
    }
     public class MongoCRUD
    {
         private IMongoDatabase db;

        public MongoCRUD(string database)
        {
            var client = new MongoClient();
            db = client.GetDatabase(database);
        }

        public void InsertRecord<T>(string table, T record)
        {
            var col = db.GetCollection<T>(table);
            col.InsertOne(record);
        }
        public List<T> Load<T>(string tableName)
        {
            var col = db.GetCollection<T>(tableName);

            return col.Find(new BsonDocument()).ToList();

        }

        public T LoadWithyQuery<T>(string tableName, Guid guid)
        {
            var col = db.GetCollection<T>(tableName);
            var filter = Builders<T>.Filter.Eq("Id", guid);

            return col.Find(filter).First();

        }

        public void UpdateRecord<T>(string tableName, Guid guid , T record)
        {
            var col = db.GetCollection<T>(tableName);
            var result = col.ReplaceOne(new BsonDocument("_id", guid),
                record,
                new UpdateOptions { IsUpsert = true });

        }
        public void DeleteRecord<T>(string tableName , Guid guid)
        {

            var col = db.GetCollection<T>(tableName);
            var filter = Builders<T>.Filter.Eq("Id", guid);
            col.DeleteOne(filter);
        }


    }

}
