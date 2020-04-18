using DevExpress.XtraEditors;
using MiniAccounting.Models.Concrete;
using MiniAccounting.Models.Context;
using MiniAccounting.Models.ModelViews;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MiniAccounting.Forms.Operations
{
    public partial class xucCardManufacturer : XtraUserControl
    {
        private MiniAccountingContext db = new MiniAccountingContext();

        public xucCardManufacturer()
        {
            InitializeComponent();
        }

        private void xucCardStock_Load(object sender, EventArgs e)
        {
            CardCustomerGridControlFill();

            var cityList = db.City;
            foreach (var item in cityList)
            {
                cmbCity.Properties.Items.Add(item.CityName);
            }
        }

        private void CardCustomerGridControlFill()
        {
            var cardStockList = from cc in db.CardCustomer
                                select new CardCustomerView()
                                {
                                    Address = cc.Address,
                                    CityName = db.City.FirstOrDefault(x => x.Id == cc.Id).CityName,
                                    Description = cc.Description,
                                    FirstName = cc.FirstName,
                                    LastName = cc.LastName,
                                    Phone = cc.Phone
                                };

            gridControl1.DataSource = cardStockList.ToList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Customer cardCustomer = new Customer
            {
                Address = txtAddress.Text,
                Phone = txtPhone.Text,
                LastName = txtLastName.Text,
                FirstName = txtFirstName.Text,
                Description = txtDescreption.Text,
                CityID = db.City.FirstOrDefault(x => x.CityName == cmbCity.SelectedText).Id,
            };
            db.CardCustomer.Add(cardCustomer);
            db.SaveChanges();
            XtraMessageBox.Show("Kayıt Başarılı", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtAddress.Text = "";
            txtPhone.Text = "";
            txtLastName.Text = "";
            txtFirstName.Text = "";
            txtDescreption.Text = "";
            cmbCity.SelectedIndex = 0;
            CardCustomerGridControlFill();
        }
    }
}