namespace MiniAccounting.Models.Concrete
{
    using MiniAccounting.Models.BaseEntities.Concrete;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Kullanýcý Rol
    /// </summary>
    [Table("UserRole")]
    public partial class UserRole : AuditEntity
    {
        public int UserTypeID { get; set; }

        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }

        public virtual UserType UserType { get; set; }
    }
}