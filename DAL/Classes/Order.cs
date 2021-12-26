namespace DAL.Classes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            DishOrder = new HashSet<DishOrder>();
        }

        [Key]
        public int Order_ID { get; set; }

        public int Order_Number { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime Order_Date { get; set; }

        public int Status_FK { get; set; }

        public int Chef_FK { get; set; }

        public int Total { get; set; }

        public virtual Chef Chef { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DishOrder> DishOrder { get; set; }

        public virtual Status Status { get; set; }
    }
}
