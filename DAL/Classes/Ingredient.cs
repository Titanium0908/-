namespace DAL.Classes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ingredient")]
    public partial class Ingredient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ingredient()
        {
            IngredientString = new HashSet<IngredientString>();
        }

        [Key]
        public int Ingredient_ID { get; set; }

        [Column(TypeName = "money")]
        public decimal Ingredient_Cost { get; set; }

        [Required]
        [StringLength(50)]
        public string Ingredient_Name { get; set; }

        public bool? Ingredient_Aveliability { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IngredientString> IngredientString { get; set; }
    }
}
