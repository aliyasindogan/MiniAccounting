using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MiniAccounting.Models;
using MiniAccounting.Models.ModelViews;

namespace MiniAccounting.Forms.Operations
{
    public partial class xucCardCustomer : XtraUserControl
    {
        private MiniAccountingContext db = new MiniAccountingContext();

        public xucCardCustomer()
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
            CardCustomer cardCustomer = new CardCustomer
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