using System.ComponentModel.DataAnnotations;

namespace MiniAccounting.Models.ModelViews
{
    public class CardStockView
    {
        public int Id { get; set; }

        [Display(Name = "Stok Kodu")]
        public string StockCode { get; set; }

        [Display(Name = "Stok Adı")]
        public string StockName { get; set; }

        [Display(Name = "Kdv")]
        public string TaxRateName { get; set; }

        [Display(Name = "Ölçü Birimi")]
        public string MeasurementUnitName { get; set; }
    }
}