﻿using DevExpress.XtraEditors;
using MiniAccounting.Models.Concrete;
using MiniAccounting.Models.Context;
using MiniAccounting.Models.ModelViews;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MiniAccounting.Forms.Operations
{
    public partial class xucCardStock : XtraUserControl
    {
        private MiniAccountingContext db = new MiniAccountingContext();

        public xucCardStock()
        {
            InitializeComponent();
        }

        private void xucCardStock_Load(object sender, EventArgs e)
        {
            CardStockGridControlFill();

            var measurementUnitList = db.MeasurementUnit;
            foreach (var item in measurementUnitList)
            {
                cmbMeasurementUnit.Properties.Items.Add(item.MeasurementUnitName);
            }

            var taxRateList = db.TaxRate.OrderByDescending(x => x.Id);
            foreach (var item in taxRateList)
            {
                cmbTaxRate.Properties.Items.Add(item.TaxName);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Stock cardStock = new Stock
            {
                MeasurementUnitID = db.MeasurementUnit.FirstOrDefault(x => x.MeasurementUnitName == cmbMeasurementUnit.SelectedText).Id,
                TaxRateID = db.TaxRate.FirstOrDefault(x => x.TaxName == cmbTaxRate.SelectedText).Id,
                StockCode = txtStockCode.Text,
                StockName = txtStockName.Text,
            };
            db.CardStock.Add(cardStock);
            db.SaveChanges();
            XtraMessageBox.Show("Kayıt Başarılı", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtStockCode.Text = "";
            txtStockName.Text = "";
            cmbMeasurementUnit.SelectedIndex = 0;
            cmbTaxRate.SelectedIndex = 0;
            CardStockGridControlFill();
        }

        private void CardStockGridControlFill()
        {
            var cardStockList = from us in db.CardStock
                                select new CardStockView()
                                {
                                    MeasurementUnitName = db.MeasurementUnit.FirstOrDefault(x => x.Id == us.MeasurementUnitID).MeasurementUnitName,
                                    TaxRateName = db.TaxRate.FirstOrDefault(x => x.Id == us.TaxRateID).TaxName,
                                    StockCode = us.StockCode,
                                    StockName = us.StockName
                                };

            gridControl1.DataSource = cardStockList.ToList();
        }
    }
}