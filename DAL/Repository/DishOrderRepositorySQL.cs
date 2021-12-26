using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Classes;

namespace DAL.Repository
{
    public class DishOrderRepositorySQL : IntRepository<DishOrder>
    {
        private Restaurant db;
        public DishOrderRepositorySQL(Restaurant dbContext)
        {
            db = dbContext;
        }
        public void Create(DishOrder item)
        {
            db.DishOrder.Add(item);
        }

        public void Delete(int id)
        {
            DishOrder item = db.DishOrder.Find(id);
            if (item != null)
                db.DishOrder.Remove(item);
        }

        public List<DishOrder> GetAll()
        {
            return db.DishOrder.ToList();
        }

        public DishOrder GetItem(int id)
        {
            return db.DishOrder.Find(id);
        }

        public void Update(DishOrder item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
