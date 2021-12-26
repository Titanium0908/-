namespace DAL.Classes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Dish")]
    public partial class Dish
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dish()
        {
            DishOrder = new HashSet<DishOrder>();
            IngredientString = new HashSet<IngredientString>();
        }

        [Key]
        public int Dish_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Dish_Name { get; set; }

        public int Dish_Grammers { get; set; }

        public bool? Dish_Aveliability { get; set; }

        public int Category_FK { get; set; }

        public int Dish_Cost { get; set; }

        [StringLength(50)]
        public string Dish_Image { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DishOrder> DishOrder { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IngredientString> IngredientString { get; set; }
    }
}
