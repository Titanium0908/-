using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Classes;

namespace DAL.Repository
{
    
    public class ServiceRepositorySQL : IServiceRepository
    {
        private Restaurant dataBase;
        public ServiceRepositorySQL(Restaurant dbcontext)
        {
            dataBase = dbcontext;
        }

        public int ChooseChef()
        {
            Restaurant db = new Restaurant();
            var result = db.Order
                            .Join(db.Status, o => o.Status_FK, s => s.Status_ID, (o, s) => new { o.Chef_FK, s.Status_ID })
                            .Where(i => i.Status_ID == 2 || i.Status_ID == 4)
                            .Join(db.Chef, i => i.Chef_FK, c => c.Chef_ID, (i, c) => new { i.Chef_FK })
                            .ToList();
            var chefs = db.Chef.Select(i => new ChefChoose { Amount = 0, Chef_ID = i.Chef_ID }).ToList();
            foreach(var i in chefs)
            {
                foreach (var j in result)
                {
                    if (j.Chef_FK == i.Chef_ID)
                    {
                        i.Amount = i.Amount + 1;
                    }
                }
            }
            var ordered = chefs.OrderBy(i => i.Amount).ToList();
            chefs = ordered;
            return chefs[0].Chef_ID;
        }
        public List<DishSelection> GetDishinMenu(int category)
        {
            Restaurant db = new Restaurant();
            var result = db.Category.Where(i => i.Category_ID == category)
                                    .Join(db.Dish, cat => cat.Category_ID, di => di.Category_FK, (cat, di) => new DishSelection
                                    { 
                                        Category_Name = cat.Category_Name,
                                        Dish_Aveliability = di.Dish_Aveliability,
                                        Dish_Cost = di.Dish_Cost, 
                                        Dish_Grammers = di.Dish_Grammers, 
                                        Dish_ID = di.Dish_ID,
                                        Dish_Image = di.Dish_Image, 
                                        Dish_Name = di.Dish_Name
                                    }).ToList();
            foreach (var dish in result)
            {
                var ingr = db.IngredientString.Where(i => i.Dish_FK == dish.Dish_ID)
                                              .Join(db.Ingredient, inst => inst.Ingredient_FK, i => i.Ingredient_ID, (inst, i) => new { gramm = inst.IngredientString_Grammers, name = i.Ingredient_Name })
                                              .ToList();
                var newres = new System.Collections.ObjectModel.ObservableCollection<string>();
                foreach (var i in ingr)
                {
                    newres.Add($"{i.name}: {i.gramm}гр.");
                }
                dish.Ingredients = newres;

            }
            return result;
        }

        public List<ChefOrder> GetOrdersForChef(int chef_id)
        {
            Restaurant db = new Restaurant();
            var result = db.Order.Where(i => i.Chef_FK == chef_id && (i.Status_FK == 2 || i.Status_FK == 4))
                                 .Join(db.Status, i => i.Status_FK, s => s.Status_ID, (i,s) => new { i.Order_ID, i.Order_Number, i.Order_Date, i.Status_FK, i.Chef_FK, Status = s.Status1 } )
                                 .Join(db.DishOrder, i => i.Order_ID, d => d.Order_FK, (i, d) => new { d.DIshOrder_Id, i.Order_ID, i.Order_Number, i.Order_Date, i.Status_FK, i.Chef_FK, i.Status, d.Number, d.Dish_FK, d.Ready })
                                 .Join(db.Dish, i => i.Dish_FK, d => d.Dish_ID, (i, d) => new ChefOrder
                                 {
                                     Order_Dish_ID = i.DIshOrder_Id,
                                     Ready = i.Ready,
                                     Number = i.Number,
                                     Chef_FK = i.Chef_FK,
                                     Dish_Image = d.Dish_Image,
                                     Dish_Name = d.Dish_Name,
                                     Dish_ID = d.Dish_ID,
                                     Order_Date = i.Order_Date,
                                     Order_ID = i.Order_ID,
                                     Order_Number = i.Order_Number,
                                     Status_FK = i.Status_FK,
                                     Status = i.Status
                                 }).ToList();
            foreach (var dish in result)
            {
                var ingr = db.IngredientString.Where(i => i.Dish_FK == dish.Dish_ID)
                                              .Join(db.Ingredient, inst => inst.Ingredient_FK, i => i.Ingredient_ID, (inst, i) => new { gramm = inst.IngredientString_Grammers, name = i.Ingredient_Name })
                                              .ToList();
                var newres = new System.Collections.ObjectModel.ObservableCollection<string>();
                foreach (var i in ingr)
                {
                    newres.Add($"{i.name}: {i.gramm}гр.");
                }
                dish.Ingredients = newres;
            }
            return result;
        }
    }
}
