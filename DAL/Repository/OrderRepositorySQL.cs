using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Classes;

namespace DAL.Repository
{
    public class OrderRepositorySQL : IntRepository<Order>
    {
        private Restaurant db;
        public OrderRepositorySQL(Restaurant dbContext)
        {
            db = dbContext;
        }
        public void Create(Order item)
        {
            db.Order.Add(item);
        }

        public void Delete(int id)
        {
            Order item = db.Order.Find(id);
            if (item != null)
                db.Order.Remove(item);
        }

        public List<Order> GetAll()
        {
            return db.Order.ToList();
        }

        public Order GetItem(int id)
        {
            return db.Order.Find(id);
        }

        public void Update(Order item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
