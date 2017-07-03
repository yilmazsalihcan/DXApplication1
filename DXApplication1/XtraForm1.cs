using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DXApplication1
{
    public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm
    {
        public XtraForm1()
        {
            InitializeComponent();
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        TASKMANAGEMENTEntities db = new TASKMANAGEMENTEntities();
        public static short shortId;
        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            Users u = db.Users.FirstOrDefault(x => x.Username == username && x.Password == password);
            if (u==null)
            {
                MessageBox.Show("Yanlış Kullanıcı Adı veya şifre girdiniz");
            }
            else
            {
                MessageBox.Show("Hoşgeldiniz "+u.Username);
                if (u.RoleId==1)
                {
                    //Kişi Admin'dir. Admin Sayfasına yönlendir. 
                    Form1 admin = new Form1();
                    admin.Visible = true;
                }
                else
                {
                    //Kişi User'dır. User Sayfasına yönlendir.
                    UserPage kullaniciSayfasi = new UserPage();
                    kullaniciSayfasi.Visible = true;
                }                
            }
        }
    }
}