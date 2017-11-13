using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using YEON.VDSC.CORE.Domain;

namespace YEON.VDSC.CORE.Dao
{
    public interface ITMonDao
    {
        void InsertProducts(IList<Product> products);
        IList<Product> SelectOverProducts(int discount);
    }

    public class TMonDao : ITMonDao
    {
        MongoClient cli;
        IMongoDatabase db;
        IMongoCollection<Product> collection;
        private static readonly string connString = "mongodb://localhost";
        private static readonly string databaseString = "VDSCDB";
        private static readonly string collectionsString = "tmon";

        public TMonDao()
        {
            cli = new MongoClient(connString);
            db = cli.GetDatabase(databaseString);
            collection = db.GetCollection<Product>(collectionsString);
        }

        public void InsertProducts(IList<Product> products)
        {
            db.DropCollection(collectionsString);
            collection.InsertMany(products);
        }

        public IList<Product> SelectOverProducts(int discount)
        {
            var filter = Builders<Product>.Filter.AnyGte("discount", discount);
            IList<Product> results = collection.Find(filter).SortByDescending(x => x.Discount).ToList<Product>();

            return results;
        }
    }
}
