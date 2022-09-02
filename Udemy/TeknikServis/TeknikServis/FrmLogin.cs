using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.Formlar
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db=new DbTeknikServisEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            var sorgu = from x in db.TblAdmin
                        where x.KULLANICIAD==TxtKullaniciAdi.Text && x.SIFRE==TxtSifre.Text select x;
            if(sorgu.Any())
            {
                Form1 frm = new Form1();
                frm.Show();
                this.Hide();
            }
            else
            {
                XtraMessageBox.Show("Hatalı Giriş Yaptınız!\nLütfen Tekrar Deneyiniz.","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void pictureEdit14_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
