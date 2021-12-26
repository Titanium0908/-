namespace DAL.Classes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IngredientString")]
    public partial class IngredientString
    {
        [Key]
        public int IngredientString_ID { get; set; }

        public int? IngredientString_Grammers { get; set; }

        public int Ingredient_FK { get; set; }

        public int Dish_FK { get; set; }

        public virtual Dish Dish { get; set; }

        public virtual Ingredient Ingredient { get; set; }
    }
}
