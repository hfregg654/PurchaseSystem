namespace PurchaseSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Purchase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Purchase()
        {
            orders = new HashSet<order>();
        }

        [Key]
        [StringLength(30)]
        public string pur_id { get; set; }

        public decimal pur_total { get; set; }

        public DateTime pur_purdate { get; set; }

        public decimal pur_assets { get; set; }

        public DateTime pur_credate { get; set; }

        public int pur_creid { get; set; }

        public DateTime? pur_update { get; set; }

        public int? pur_upid { get; set; }

        public DateTime? pur_deldate { get; set; }

        public int? pur_delid { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order> orders { get; set; }

        public virtual User User { get; set; }
    }
}
