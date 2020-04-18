using MiniAccounting.Models.BaseEntities.Concrete;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniAccounting.Models.Concrete
{
    /// <summary>
    /// Üretici Firma
    /// </summary>
    [Table("Manufacturer")]
    public class Manufacturer : AuditEntity
    {
        /// <summary>
        /// Ünvan
        /// </summary>
        public string Title { get; set; }

        [StringLength(50)]
        [Display(Name = "Yetkili Adı")]
        public string AuthorizedFirstName { get; set; }

        [Display(Name = "Yetkili Soyadı")]
        [StringLength(50)]
        public string AuthorizedLastName { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        public string Description { get; set; }

        public int? CityID { get; set; }
        public string Address { get; set; }

        public virtual City City { get; set; }
    }
}