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
        public static short secilenId;
        public Form1()
        {
            InitializeComponent();
            tabNavigationPage1.PageVisible = false;
            tabNavigationPage2.PageVisible = false;
            tabAddRole.Visible = false;

            dataGridView1.DataSource = db.Tasks.Select(x => new { 

                x.TaskTitle,
                x.TaskDescription,
                x.TaskId


            }).ToList();

           



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
           
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            grcUsers.DataSource = db.Users.Select(x => new {

                Ad = x.Username,
                Şifre = x.Password,
                Rolü = x.Role.RoleName,
                Kayıt_Tarihi=x.RegisterDate


            }).ToList();

        }

       

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            try
            {
                Tasks gorevler = new Tasks();  
                gorevler.StartTime = Convert.ToDateTime(dtStart.SelectedText);
                gorevler.FinishTime = Convert.ToDateTime(dtFinish.SelectedText);
                if (gorevler.StartTime>gorevler.FinishTime)
                {
                    MessageBox.Show("Başlangıç TArihi biriş tarihinden büyük olamaz");
                }
                else
                {
                    gorevler.StatusId = 1;
                    gorevler.TaskTitle = txtTitle.Text;
                    gorevler.TaskDescription = txtDescription.Text;
                    db.Tasks.Add(gorevler);
                    db.SaveChanges();
                    txtTitle.Text = "";
                    txtDescription.Text = "";
                    dtStart.Text = "";
                    dtFinish.Text = "";
                }
               
            }
            catch (Exception)
            {

                MessageBox.Show("Hatalı bir işlem yaptınız");
            }


        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            gcTaskList.DataSource = db.Tasks.Select(x => new {

                GorevBaslik=x.TaskTitle,
                Gorev=x.TaskDescription,
                BaslangicTarihi=x.StartTime,
                BitisTarihi=x.FinishTime


            }).ToList();

        }

        private void tabFormControl1_Click(object sender, EventArgs e)
        {

        }

        
        private void button1_Click(object sender, EventArgs e)
        {
           
                
            }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            secilenId = Convert.ToInt16(dataGridView1.CurrentRow.Cells[2].Value.ToString());
            frmGorevAta frmGorev = new frmGorevAta();
            frmGorev.Visible = true;

        }
    }

       
    }

