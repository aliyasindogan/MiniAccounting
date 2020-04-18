namespace MiniAccounting.Models.Concrete
{
    using MiniAccounting.Models.BaseEntities.Abstract;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Ölçü Birimi
    /// </summary>
    [Table("MeasurementUnit")]
    public partial class MeasurementUnit : IBaseEntity
    {
        public MeasurementUnit()
        {
            CardStock = new HashSet<Stock>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string MeasurementUnitName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stock> CardStock { get; set; }
    }
}