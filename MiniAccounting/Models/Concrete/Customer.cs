using MiniAccounting.Models.BaseEntities.Concrete;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniAccounting.Models.Concrete
{
    /// <summary>
    /// Müşteri
    /// </summary>
    [Table("Customer")]
    public class Customer : AuditEntity
    {
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        public string Description { get; set; }

        public int? CityID { get; set; }
        public string Address { get; set; }

        public virtual City City { get; set; }
    }
}