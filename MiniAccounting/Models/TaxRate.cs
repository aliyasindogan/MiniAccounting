namespace MiniAccounting.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaxRate")]
    public partial class TaxRate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaxRate()
        {
            CardStock = new HashSet<CardStock>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string TaxName { get; set; }

        public int TaxRateValue { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CardStock> CardStock { get; set; }
    }
}
