﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAccounting.Models.ModelViews
{
    public class CardStockView
    {
        public string StockCode { get; set; }
        public string StockName { get; set; }
        public string TaxRateName { get; set; }
        public string MeasurementUnitName { get; set; }
    }
}