namespace PurchaseSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class order
    {
        [Key]
        public int order_id { get; set; }

        [Required]
        [StringLength(30)]
        public string order_purid { get; set; }

        [Required]
        [StringLength(30)]
        public string order_prodid { get; set; }

        public int order_num { get; set; }

        public bool order_delflag { get; set; }

        public virtual Prouduct Prouduct { get; set; }

        public virtual Purchase Purchase { get; set; }
    }
}
