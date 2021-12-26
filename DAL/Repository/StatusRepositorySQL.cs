using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Classes;

namespace DAL.Repository
{
    public class StatusRepositorySQL : IntRepository<Status>
    {
        private Restaurant db;
        public StatusRepositorySQL(Restaurant dbContext)
        {
            db = dbContext;
        }
        public void Create(Status item)
        {
            db.Status.Add(item);
        }

        public void Delete(int id)
        {
            Status item = db.Status.Find(id);
            if (item != null)
                db.Status.Remove(item);
        }

        public List<Status> GetAll()
        {
            return db.Status.ToList();
        }

        public Status GetItem(int id)
        {
            return db.Status.Find(id);
        }

        public void Update(Status item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
