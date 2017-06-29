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
using System.Data.SqlClient;

namespace DXApplication1
{
    public partial class frmGorevAta : DevExpress.XtraEditors.XtraForm
    {
        public frmGorevAta()
        {
            InitializeComponent();
        }

        TASKMANAGEMENTEntities db = new TASKMANAGEMENTEntities();
        short secilenId;
        private void frmGorevAta_Load(object sender, EventArgs e)
        {
            secilenId = Form1.secilenId;
            label1.Text = db.Tasks.FirstOrDefault(x => x.TaskId == secilenId).TaskTitle;
            label2.Text = db.Tasks.FirstOrDefault(x => x.TaskId == secilenId).TaskDescription;
            List<Users> kullanicilar = db.Users.ToList();
            foreach (var item in kullanicilar)
            {
                listBox1.Items.Add(item.UserId+","+item.Username);                
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            listBox2.Items.Add(listBox1.SelectedItem);
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=SALIH-PC\\SQLEXPRESS; Initial Catalog=TASKMANAGEMENT; Integrated Security=True;");
            con.Open();
           

            List<Users> kullanici = new List<Users>();
            Tasks gorev = new Tasks();
            Users u = new Users();
           

            string[] id=new string[listBox2.Items.Count];
            string[] deger = new string[id.Length];
            int sayac = 0;
            for (int i = 0; i <listBox2.Items.Count; i++)
            {
               id=listBox2.Items[i].ToString().Split(',');
               deger[sayac] = id[0];
               sayac++;
            }

            for (int i = 0; i < deger.Length; i++)
            {
                short idConvert = Convert.ToInt16(deger[i]);
                SqlCommand cmd = new SqlCommand("Insert into UsersToTasks(UserId,TaskId) values('"+idConvert+"','"+secilenId+"')", con);
                cmd.ExecuteNonQuery();
                

            }
            con.Close();
            db.SaveChanges();
          
        }
    }
}