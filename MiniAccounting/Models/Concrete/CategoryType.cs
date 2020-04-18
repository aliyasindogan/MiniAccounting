namespace MiniAccounting.Models.Concrete
{
    using MiniAccounting.Models.BaseEntities.Abstract;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Kategori Tipi
    /// </summary>
    [Table("CategoryType")]
    public partial class CategoryType : IBaseEntity
    {
        public CategoryType()
        {
            Category = new HashSet<Category>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string CategoryTypeName { get; set; }

        public virtual ICollection<Category> Category { get; set; }
    }
}