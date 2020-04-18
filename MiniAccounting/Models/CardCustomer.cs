using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAccounting.Models
{
    [Table("CardCustomer")]
    public class CardCustomer
    {
        public int Id { get; set; }

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