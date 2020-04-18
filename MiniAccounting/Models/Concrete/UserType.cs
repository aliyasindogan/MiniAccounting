namespace MiniAccounting.Models.Concrete
{
    using MiniAccounting.Models.BaseEntities.Abstract;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Kullanýcý Tipi
    /// </summary>
    [Table("UserType")]
    public partial class UserType : IBaseEntity
    {
        public UserType()
        {
            User = new HashSet<User>();
            UserRole = new HashSet<UserRole>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string UserTypeName { get; set; }

        public virtual ICollection<User> User { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}