using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DXApplication1
{
    public partial class Form1 : DevExpress.XtraBars.TabForm
    {
        public Form1()
        {
            InitializeComponent();
            tabNavigationPage1.PageVisible = false;
            tabNavigationPage2.PageVisible = false;
            tabAddRole.Visible = false;          
        }
        void OnOuterFormCreating(object sender, OuterFormCreatingEventArgs e)
        {
            Form1 form = new Form1();
            form.TabFormControl.Pages.Clear();
            e.Form = form;
            OpenFormCount++;      
        }
        static int OpenFormCount = 1;

        private void btnAddRole_ItemClick(object sender, ItemClickEventArgs e)
        {
            tabAddRole.Visible = true;
            tabNavigationPage1.PageVisible = true;
        }

        TASKMANAGEMENTEntities db = new TASKMANAGEMENTEntities();
        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            tabAddRole.Visible = true;
            tabNavigationPage2.PageVisible = true;
            gridControl1.DataSource = db.Role.Select(x => new
            {
               Rol=x.RoleName
                

            }).ToList();
           
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //Rol ekleme işlemi yapılacak.
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Deneme 1-2

            string a = "dsad";
        }
    }
}
