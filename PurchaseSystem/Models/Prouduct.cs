namespace PurchaseSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Prouduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Prouduct()
        {
            orders = new HashSet<order>();
        }

        [Key]
        [StringLength(30)]
        public string prod_id { get; set; }

        [Required]
        [StringLength(30)]
        public string prod_name { get; set; }

        public decimal prod_price { get; set; }

        public int prod_categoryid { get; set; }

        public int prod_stock { get; set; }

        public virtual CategoryMaster CategoryMaster { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order> orders { get; set; }
    }
}
