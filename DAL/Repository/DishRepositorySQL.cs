using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Classes;

namespace DAL.Repository
{
    public class DishRepositorySQL : IntRepository<Dish>
    {
        private Restaurant db;
        public DishRepositorySQL(Restaurant dbContext)
        {
            db = dbContext;
        }
        public void Create(Dish item)
        {
            db.Dish.Add(item);
        }

        public void Delete(int id)
        {
            Dish item = db.Dish.Find(id);
            if (item != null)
                db.Dish.Remove(item);
        }

        public List<Dish> GetAll()
        {
            return db.Dish.ToList();
        }

        public Dish GetItem(int id)
        {
            return db.Dish.Find(id);
        }

        public void Update(Dish item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
