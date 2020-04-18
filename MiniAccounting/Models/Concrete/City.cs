using MiniAccounting.Models.BaseEntities.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniAccounting.Models.Concrete
{
    /// <summary>
    /// Şehir
    /// </summary>
    [Table("City")]
    public class City : IBaseEntity
    {
        public City()
        {
            CardCustomer = new HashSet<Customer>();
            Manufacturer = new HashSet<Manufacturer>();
        }

        public int Id { get; set; }
        public string CityName { get; set; }

        public virtual ICollection<Customer> CardCustomer { get; set; }
        public virtual ICollection<Manufacturer> Manufacturer { get; set; }
    }
}