namespace PurchaseSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CategoryMaster")]
    public partial class CategoryMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CategoryMaster()
        {
            Prouducts = new HashSet<Prouduct>();
        }

        [Key]
        public int category_id { get; set; }

        [Required]
        [StringLength(30)]
        public string category_name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prouduct> Prouducts { get; set; }
    }
}
