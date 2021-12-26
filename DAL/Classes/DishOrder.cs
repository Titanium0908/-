namespace DAL.Classes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DishOrder")]
    public partial class DishOrder
    {
        [Key]
        public int DIshOrder_Id { get; set; }

        public int Dish_FK { get; set; }

        public int Order_FK { get; set; }

        public int Number { get; set; }

        public bool Ready { get; set; }

        public virtual Dish Dish { get; set; }

        public virtual Order Order { get; set; }
    }
}
