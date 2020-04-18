namespace MiniAccounting.Models.Concrete
{
    using MiniAccounting.Models.BaseEntities.Abstract;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Kullanýcý
    /// </summary>
    [Table("User")]
    public partial class User : IModifiableEntity, IDisplay
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        public int UserTypeID { get; set; }

        public int? CreatedUserID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedUserID { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsDisplay { get; set; }
        public int DisplayOrder { get; set; }
        public virtual UserType UserType { get; set; }
    }
}