﻿using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfasces;

namespace Plagins.DataStore.SQL
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly MarketContext db;

        public TransactionRepository(MarketContext db)
        {
            this.db = db;
        }
        public IEnumerable<Transaction> Get(string cashierName)
        {
            return db.Transactions.Where(x=>x.CashierName== cashierName).ToList();
        }

        public IEnumerable<Transaction> GetByDay(string cashierName, DateTime date)
        {
            if(string.IsNullOrWhiteSpace(cashierName))
                return db.Transactions.Where(x=>x.TimeStamp.Date == date.Date).ToList();
            return db.Transactions.Where(x => EF.Functions.Like(x.CashierName, $"%{cashierName}%") && x.TimeStamp.Date == date.Date).ToList();
            //return db.Transactions.Where(x=>x.CashierName.ToLower()==cashierName.ToLower() && x.TimeStamp.Date == date.Date).ToList();

        }

        public void Save(string cashierName, int productId, string productName, double price, int beforQty, int SoldQty)
        {
            var transaction = new Transaction
            {
                ProductId = productId,
               TimeStamp = DateTime.Now,
                ProductName = productName,
                Price= price,   
                BeforQty= beforQty,
                SoldQty= SoldQty,
                CashierName= cashierName


            };
            db.Transactions.Add(transaction);
            db.SaveChanges();
        }

        public IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate)
        {

            if (string.IsNullOrWhiteSpace(cashierName))
                return db.Transactions.Where(x => x.TimeStamp.Date >= startDate.Date && x.TimeStamp <= endDate.Date.AddDays(1).Date).ToList();
            else
                return db.Transactions.Where(x =>
                EF.Functions.Like(x.CashierName, $"%{cashierName}%") &&
                x.TimeStamp.Date >= startDate.Date && x.TimeStamp <= endDate.Date.AddDays(1).Date);
            //return db.Transactions.Where(x =>

            //    x.CashierName.ToLower() == cashierName.ToLower() &&
            //    x.TimeStamp.Date >= startDate.Date && x.TimeStamp<=endDate.Date.AddDays(1).Date);
        }
    }
}
