namespace MiniAccounting.Models.Concrete
{
    using MiniAccounting.Models.BaseEntities.Concrete;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Stok
    /// </summary>
    [Table("Stock")]
    public partial class Stock : AuditEntity
    {
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