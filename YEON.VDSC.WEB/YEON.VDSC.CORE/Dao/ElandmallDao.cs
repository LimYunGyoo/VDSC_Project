using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using YEON.VDSC.CORE.Domain;

namespace YEON.VDSC.CORE.Dao
{
    public interface IElandmallDao
    {
        void InsertProducts(IList<Product> products);
        IList<Product> SelectAllProducts(int discount);
    }

    public class ElandmallDao : IElandmallDao
    {
        MongoClient cli;
        IMongoDatabase db;
        IMongoCollection<Product> collection;
        private static readonly string connString = "mongodb://localhost";
        private static readonly string databaseString = "VDSCDB";
        private static readonly string collectionsString = "elandmall";

        public ElandmallDao()
        {
            cli = new MongoClient(connString);
            db = cli.GetDatabase(databaseString);
            collection = db.GetCollection<Product>(collectionsString);
        }

        public void InsertProducts(IList<Product> products)
        {
            collection.InsertMany(products);
        }

        public IList<Product> SelectAllProducts(int discount)
        {            
            var filter = Builders<Product>.Filter.AnyGte("discount", discount);
            
            IList<Product> results = collection.Find(filter).SortByDescending(x => x.Discount).ToList<Product>();
               
            return results;
        }


    }
}
