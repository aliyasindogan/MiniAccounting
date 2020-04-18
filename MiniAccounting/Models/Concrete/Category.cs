namespace MiniAccounting.Models.Concrete
{
    using MiniAccounting.Models.BaseEntities.Concrete;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Kategori
    /// </summary>
    [Table("Category")]
    public partial class Category : AuditEntity
    {
        public Category()
        {
            UserRole = new HashSet<UserRole>();
        }

        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; }

        public int SubCategoryID { get; set; }

        public int CategoryTypeID { get; set; }

        public virtual CategoryType CategoryType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}