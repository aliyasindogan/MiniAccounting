using System.ComponentModel.DataAnnotations;

namespace MiniAccounting.Models.ModelViews
{
    public class CardCustomerView
    {
        [Display(Name = "Ad")]
        public string FirstName { get; set; }

        [Display(Name = "Soyad")]
        public string LastName { get; set; }

        [Display(Name = "Açıklama")]
        public string Description { get; set; }

        [Display(Name = "Telefon")]
        public string Phone { get; set; }

        [Display(Name = "Adres")]
        public string Address { get; set; }

        [Display(Name = "Şehir")]
        public string CityName { get; set; }
    }
}