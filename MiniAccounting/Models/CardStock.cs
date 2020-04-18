namespace MiniAccounting.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CardStock")]
    public partial class CardStock
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string StockCode { get; set; }

        [Required]
        [StringLength(500)]
        public string StockName { get; set; }

        public int TaxRateID { get; set; }

        public int MeasurementUnitID { get; set; }

        public virtual MeasurementUnit MeasurementUnit { get; set; }

        public virtual TaxRate TaxRate { get; set; }
    }
}
