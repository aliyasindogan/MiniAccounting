﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MiniAccounting.Forms
{
    public partial class xucNavigation : DevExpress.XtraEditors.XtraUserControl
    {
        public xucNavigation()
        {
            InitializeComponent();
        }

        private void xucNavigation_Load(object sender, EventArgs e)
        {
            //4/5 ) xucNavigation UserControl Load olduğunda (sayfa yüklendiğinde) Event'ımızı tanımlıyoruz
            frmMain.SelectedPageName += FrmMain_SelectedPageName;
        }

        private void FrmMain_SelectedPageName(string PageName)
        {
            lblPageName.Text = PageName;
        }
    }
}