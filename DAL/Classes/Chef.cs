namespace DAL.Classes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Chef")]
    public partial class Chef
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Chef()
        {
            Order = new HashSet<Order>();
        }

        [Key]
        public int Chef_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Chef_FullName { get; set; }

        public int? Chef_Experience { get; set; }

        [StringLength(50)]
        public string Chef_Education { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }
    }
}
