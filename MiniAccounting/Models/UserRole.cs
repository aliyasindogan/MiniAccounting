namespace MiniAccounting.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserRole")]
    public partial class UserRole
    {
        public int Id { get; set; }

        public int UserTypeID { get; set; }

        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }

        public virtual UserType UserType { get; set; }
    }
}
