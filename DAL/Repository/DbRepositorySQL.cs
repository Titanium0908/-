using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Classes;
using DAL.Interfaces;

namespace DAL.Repository
{
    public class DbRepositorySQL : IntDbRepository
    {
        private Restaurant db;

        private CategoryRepositorySQL categoryRepository;
        private ChefRepositorySQL chefRepository;
        private DishOrderRepositorySQL dishorderRepository;
        private DishRepositorySQL dishRepository;
        private IngredientRepositorySQL ingredientRepository;
        private OrderRepositorySQL orderRepository;
        private IngredientStringRepositorySQL ingredientstringRepository;
        private StatusRepositorySQL statusRepository;
        private ServiceRepositorySQL serviceRepositorySQL;


        public DbRepositorySQL()
        {
            db = new Restaurant();
        }
        public IServiceRepository Services
        {
            get
            {
                if (serviceRepositorySQL == null)
                    serviceRepositorySQL = new ServiceRepositorySQL(db);
                return serviceRepositorySQL;
            }
        }

        public IntRepository<Category> Categorys
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new CategoryRepositorySQL(db);
                return categoryRepository;
            }
        }
        public IntRepository<Chef> Chefs
        {
            get
            {
                if (chefRepository == null)
                    chefRepository = new ChefRepositorySQL(db);
                return chefRepository;
            }
        }
        public IntRepository<Dish> Dishs
        {
            get
            {
                if (dishRepository == null)
                    dishRepository = new DishRepositorySQL(db);
                return dishRepository;
            }
        }
        public IntRepository<DishOrder> DishOrders
        {
            get
            {
                if (dishorderRepository == null)
                    dishorderRepository = new DishOrderRepositorySQL(db);
                return dishorderRepository;
            }
        }
        public IntRepository<Order> Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepositorySQL(db);
                return orderRepository;
            }
        }
        public IntRepository<Ingredient> Ingredients
        {
            get
            {
                if (ingredientRepository == null)
                    ingredientRepository = new IngredientRepositorySQL(db);
                return ingredientRepository;
            }
        }
        public IntRepository<IngredientString> IngredientStrings
        {
            get
            {
                if (ingredientstringRepository == null)
                    ingredientstringRepository = new IngredientStringRepositorySQL(db);
                return ingredientstringRepository;
            }
        }
        public IntRepository<Status> Statuss
        {
            get
            {
                if (statusRepository == null)
                    statusRepository = new StatusRepositorySQL(db);
                return statusRepository;
            }
        }


        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
