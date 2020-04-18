using DevExpress.XtraBars;
using MiniAccounting.Forms.Operations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MiniAccounting.Forms
{
    public partial class frmMain : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        //1/5 ) Delege tanımlanıyor
        public delegate void SelectedPageNameHandler(string PageName);

        //2/5 ) Event tanımlanıyor
        public static event SelectedPageNameHandler SelectedPageName;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            fdfContainer.Controls.Add(new xucNavigation() { Dock = DockStyle.Top });
            fdfContainer.Controls.Add(new xucDashboard() { Dock = DockStyle.Bottom });
        }

        private void aceCardStock_Click(object sender, EventArgs e)
        {
            fdfContainer.Controls.Clear();
            fdfContainer.Controls.Add(new xucNavigation() { Dock = DockStyle.Top });
            fdfContainer.Controls.Add(new xucCardStock() { Dock = DockStyle.Bottom });
            //3/5 ) Event nerede kullanılacaksa oraya ekleniyor.
            SelectedPageName("Stok Kartları");
        }

        private void aceCardCustomer_Click(object sender, EventArgs e)
        {
            fdfContainer.Controls.Clear();
            fdfContainer.Controls.Add(new xucNavigation() { Dock = DockStyle.Top });
            fdfContainer.Controls.Add(new xucCardCustomer() { Dock = DockStyle.Bottom });
            //3/5 ) Event nerede kullanılacaksa oraya ekleniyor.
            SelectedPageName("Müşteri Kartları");
        }
    }
}