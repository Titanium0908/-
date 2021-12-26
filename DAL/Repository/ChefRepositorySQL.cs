using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Classes;

namespace DAL.Repository
{
    public class ChefRepositorySQL : IntRepository<Chef>
    {
        private Restaurant db;
        public ChefRepositorySQL(Restaurant dbContext)
        {
            db = dbContext;
        }
        public void Create(Chef item)
        {
            db.Chef.Add(item);
        }

        public void Delete(int id)
        {
            Chef item = db.Chef.Find(id);
            if (item != null)
                db.Chef.Remove(item);
        }

        public List<Chef> GetAll()
        {
            return db.Chef.ToList();
        }

        public Chef GetItem(int id)
        {
            return db.Chef.Find(id);
        }

        public void Update(Chef item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
