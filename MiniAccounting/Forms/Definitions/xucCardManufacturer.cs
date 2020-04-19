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

        private void xucCardManufacturer_Load(object sender, EventArgs e)
        {
            CardManufacturerGridControlFill();

            var cityList = db.City;
            foreach (var item in cityList)
            {
                cmbCity.Properties.Items.Add(item.CityName);
            }
        }

        private void CardManufacturerGridControlFill()
        {
            var cardManufacturerList = from m in db.Manufacturer
                                       select new CardManufacturerView()
                                       {
                                           Title = m.Title,
                                           Address = m.Address,
                                           CityName = db.City.FirstOrDefault(x => x.Id == m.CityID).CityName,
                                           Description = m.Description,
                                           FirstName = m.AuthorizedFirstName,
                                           LastName = m.AuthorizedLastName,
                                           Phone = m.Phone
                                       };

            gridControl1.DataSource = cardManufacturerList.ToList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Manufacturer cardManufacturer = new Manufacturer
            {
                Address = txtAddress.Text,
                Phone = txtPhone.Text,
                AuthorizedLastName = txtLastName.Text,
                AuthorizedFirstName = txtFirstName.Text,
                Description = txtDescreption.Text,
                Title = txtTitle.Text,
                CityID = db.City.FirstOrDefault(x => x.CityName == cmbCity.SelectedText).Id,
                CreatedDate = DateTime.Now,
                CreatedUserID = 1
            };
            db.Manufacturer.Add(cardManufacturer);
            db.SaveChanges();
            XtraMessageBox.Show("Kayıt Başarılı", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtAddress.Text = "";
            txtPhone.Text = "";
            txtLastName.Text = "";
            txtFirstName.Text = "";
            txtDescreption.Text = "";
            cmbCity.SelectedIndex = 0;
            txtTitle.Text = "";
            CardManufacturerGridControlFill();
        }
    }
}