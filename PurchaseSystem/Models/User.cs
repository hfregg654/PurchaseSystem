namespace PurchaseSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Purchases = new HashSet<Purchase>();
        }

        [Key]
        public int user_id { get; set; }

        [Required]
        [StringLength(20)]
        public string user_acc { get; set; }

        [Required]
        [StringLength(20)]
        public string user_pwd { get; set; }

        [Required]
        [StringLength(15)]
        public string user_pri { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
