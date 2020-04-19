using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
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
        private int rowHandle;
        private GridColumn column;
        private int selectedID = 0;

        public xucCardStock()
        {
            InitializeComponent();
        }

        private void xucCardStock_Load(object sender, EventArgs e)
        {
            CardStockGridControlFill();

            #region Comboboxes Fill

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

            #endregion Comboboxes Fill

            #region gridView1 Settings

            //Bu özellik kolonun otomatik olup olmayacağını kontrol eder.
            this.gridView1.OptionsView.ColumnAutoWidth = true;
            //Gridviewdeki düzenleme (Edit) özelliğini kontrol eder.
            gridView1.OptionsBehavior.Editable = false;
            // Bu özellik çoklu seçim özelliğinin etkin olup olmadığını kontrol eder
            gridView1.OptionsSelection.MultiSelect = true;
            // Birden fazla hücre veya satır seçilip seçilemeyeceğini kontrol eder
            gridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;

            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.OptionsSelection.CheckBoxSelectorColumnWidth = 25;
            this.gridView1.Columns[0].Visible = false;
            //this.gridView1.Columns[1].ToolTip = "Kullanıcı No";
            //this.gridView1.Columns[1].MaxWidth = 35;

            #endregion gridView1 Settings

            #region Buttons

            btnEdit.Visible = false;
            btnSave.Visible = true;

            #endregion Buttons
        }

        private void CardStockGridControlFill()
        {
            var cardStockList = from cd in db.Stock
                                select new CardStockView()
                                {
                                    Id = cd.Id,
                                    MeasurementUnitName = db.MeasurementUnit.FirstOrDefault(x => x.Id == cd.MeasurementUnitID).MeasurementUnitName,
                                    TaxRateName = db.TaxRate.FirstOrDefault(x => x.Id == cd.TaxRateID).TaxName,
                                    StockCode = cd.StockCode,
                                    StockName = cd.StockName
                                };

            gridControl1.DataSource = cardStockList.ToList();
        }

        private void gridView1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            selectedID = Convert.ToInt32((sender as GridView).GetFocusedRowCellValue("Id").ToString());

            #region Gridviewden Çoklu Seçim Sayısı

            /*
             * Ali Yasin DOĞAN 16.04.2020
             * Gridview'den Çoklu Seçim Sayısı Alınıyor
             * selectedRowsCount eklenen saı aşağıda kontrol ediliyor.
            */
            int selectedRowsCount = 0;
            for (int i = 0; i < gridView1.DataRowCount; i++)
            {
                if (gridView1.IsRowSelected(i))
                {
                    selectedRowsCount++;
                }
            }

            #endregion Gridviewden Çoklu Seçim Sayısı

            GridView view = sender as GridView;
            GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

            #region Gridview'den Çoklu Seçim Sayısı Kontrolu

            if (selectedRowsCount <= 1)
            {
                //Tekli Menu
                popupMenu1.ItemLinks.Clear();
                barManager1.ForceInitialize();
                popupMenu1.ItemLinks.Add(new BarButtonItem(barManager1, "Düzenle"));
                popupMenu1.ItemLinks.Add(new BarButtonItem(barManager1, "Sil"));
                popupMenu1.ItemLinks.Add(new BarButtonItem(barManager1, "Sayfayı Yenile"));

                if (hitInfo.InRowCell)
                {
                    view.FocusedRowHandle = rowHandle = hitInfo.RowHandle;
                    column = hitInfo.Column;
                    this.gridView1.SelectRow(rowHandle);
                    popupMenu1.ShowPopup(barManager1, view.GridControl.PointToScreen(e.Point));
                }
            }
            else
            {
                //Çoklu Menu
                popupMenu1.ItemLinks.Clear();
                barManager1.ForceInitialize();
                popupMenu1.ItemLinks.Add(new BarButtonItem(barManager1, "Seçilenleri Sil"));
                popupMenu1.ItemLinks.Add(new BarButtonItem(barManager1, "Sayfayı Yenile"));

                //popupMenu1.ItemLinks.Add(new BarButtonItem(barManager1, "Tümünü Sil"));
                if (hitInfo.InRowCell)
                {
                    view.FocusedRowHandle = rowHandle = hitInfo.RowHandle;
                    column = hitInfo.Column;
                    popupMenu1.ShowPopup(barManager1, view.GridControl.PointToScreen(e.Point));
                }
            }

            #endregion Gridview'den Çoklu Seçim Sayısı Kontrolu
        }

        private void barManager1_ItemClick(object sender, ItemClickEventArgs e)
        {
            GridView view = gridControl1.FocusedView as GridView;
            if (e.Item.Caption == "Düzenle")
            {
                try
                {
                    var stock = db.Stock.FirstOrDefault(x => x.Id == selectedID);
                    txtStockCode.Text = stock.StockCode;
                    txtStockName.Text = stock.StockName;
                    cmbMeasurementUnit.EditValue = db.MeasurementUnit.FirstOrDefault(x => x.Id == stock.MeasurementUnitID).MeasurementUnitName;
                    cmbTaxRate.EditValue = db.TaxRate.FirstOrDefault(x => x.Id == stock.TaxRateID).TaxName;
                    CardStockGridControlFill();
                    btnEdit.Visible = true;
                    btnSave.Visible = false;
                }
                catch (Exception)
                {
                    XtraMessageBox.Show("Düzenleme İşleminde Hata Oluştu ! ", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (e.Item.Caption == "Sil")
            {
                try
                {
                    var stock = db.Stock.FirstOrDefault(x => x.Id == selectedID);
                    db.Stock.Remove(stock);
                    db.SaveChanges();
                    XtraMessageBox.Show("Silme Başarılı", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshForm();
                }
                catch (Exception)
                {
                    XtraMessageBox.Show("Silme İşleminde Hata Oluştu ! ", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //if (e.Item.Caption == "Tümünü Sil")
            //{
            //    var stocks = db.Stock.ToList();
            //    db.Stock.RemoveRange(stocks);
            //    db.SaveChanges();
            //    XtraMessageBox.Show("Tüm Stok Kartları Silindi !'", "İşlem Başarılı !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    CardStockGridControlFill();
            //}

            if (e.Item.Caption == "Seçilenleri Sil")
            {
                string selectedRowList = "";
                for (int i = 0; i < gridView1.DataRowCount; i++)
                {
                    if (gridView1.IsRowSelected(i))
                    {
                        selectedRowList += gridView1.GetRowCellValue(i, gridView1.Columns["Id"]).ToString() + " - " + gridView1.GetRowCellValue(i, gridView1.Columns["StockCode"]).ToString() + " " + gridView1.GetRowCellValue(i, gridView1.Columns["StockName"]).ToString() + "\n";
                        int selectedRowID = Convert.ToInt32(gridView1.GetRowCellValue(i, gridView1.Columns["Id"]));
                        var stock = db.Stock.FirstOrDefault(x => x.Id == selectedRowID);
                        db.Stock.Remove(stock);
                        db.SaveChanges();
                    }
                }
                CardStockGridControlFill();

                XtraMessageBox.Show("Silenen Stok Kartları Listesi:\n" + selectedRowList, "İşlem Başarılı !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (e.Item.Caption == "Sayfayı Yenile")
            {
                RefreshForm();
                XtraMessageBox.Show("Sayfa Yenilendi !", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void RefreshForm()
        {
            txtStockCode.Text = "";
            txtStockName.Text = "";
            cmbMeasurementUnit.SelectedIndex = -1;
            cmbTaxRate.SelectedIndex = -1;
            CardStockGridControlFill();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Stock cardStock = new Stock
                {
                    MeasurementUnitID = db.MeasurementUnit.FirstOrDefault(x => x.MeasurementUnitName == cmbMeasurementUnit.SelectedText).Id,
                    TaxRateID = db.TaxRate.FirstOrDefault(x => x.TaxName == cmbTaxRate.SelectedText).Id,
                    StockCode = txtStockCode.Text,
                    StockName = txtStockName.Text,
                    CreatedDate = DateTime.Now,
                    CreatedUserID = 1
                };
                db.Stock.Add(cardStock);
                db.SaveChanges();
                XtraMessageBox.Show("Kayıt Başarılı", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshForm();
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Kaydetme İşleminde Hata Oluştu ! ", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                var stock = db.Stock.FirstOrDefault(x => x.Id == selectedID);
                stock.StockName = txtStockName.Text;
                stock.StockCode = txtStockCode.Text;
                stock.MeasurementUnitID = db.MeasurementUnit.FirstOrDefault(x => x.MeasurementUnitName == cmbMeasurementUnit.SelectedItem.ToString()).Id;
                stock.TaxRateID = db.TaxRate.FirstOrDefault(x => x.TaxName == cmbTaxRate.SelectedItem.ToString()).Id;
                stock.ModifiedDate = DateTime.Now;
                stock.ModifiedUserID = 1;
                db.SaveChanges();
                XtraMessageBox.Show("Düzenleme Başarılı", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshForm();
                btnEdit.Visible = false;
                btnSave.Visible = true;
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Düzenleme İşleminde Hata Oluştu ! ", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}