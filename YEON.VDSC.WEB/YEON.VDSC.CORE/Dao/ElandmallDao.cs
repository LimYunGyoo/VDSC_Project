﻿using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using YEON.VDSC.CORE.Config;
using YEON.VDSC.CORE.Domain;

namespace YEON.VDSC.CORE.Dao
{
    public interface IElandmallDao
    {
        void InsertProducts(IList<Product> products);
        IList<Product> SelectOverProducts(int discount);
    }

    public class ElandmallDao : IElandmallDao
    {
        MongoClient cli;
        IMongoDatabase db;
        IMongoCollection<Product> collection;
        private static readonly string collectionsString = "elandmall";

        public ElandmallDao(IOptions<Connection> connectionSetting)
        {
            cli = new MongoClient(connectionSetting.Value.ConnectionString);
            db = cli.GetDatabase(connectionSetting.Value.DBName);
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
