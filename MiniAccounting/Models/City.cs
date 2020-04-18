using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAccounting.Models
{
    [Table("City")]
    public class City
    {
        public City()
        {
            CardCustomer = new HashSet<CardCustomer>();
        }

        public int Id { get; set; }
        public string CityName { get; set; }

        public virtual ICollection<CardCustomer> CardCustomer { get; set; }
    }
}