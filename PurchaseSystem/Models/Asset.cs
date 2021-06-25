namespace PurchaseSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Asset
    {
        [Key]
        public int assets_id { get; set; }

        public decimal assets_total { get; set; }
    }
}
