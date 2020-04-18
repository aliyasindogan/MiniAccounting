namespace MiniAccounting.Models.Concrete
{
    using MiniAccounting.Models.BaseEntities.Abstract;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Vergi Oraný (KDV)
    /// </summary>
    [Table("TaxRate")]
    public partial class TaxRate : IBaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaxRate()
        {
            CardStock = new HashSet<Stock>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string TaxName { get; set; }

        public int TaxRateValue { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stock> CardStock { get; set; }
    }
}