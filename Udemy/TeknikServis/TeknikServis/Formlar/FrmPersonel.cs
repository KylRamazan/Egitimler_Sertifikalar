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
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }

        private void labelControl5_Click(object sender, EventArgs e)
        {

        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            var degerler =from p in db.TblPersonel
                          select new
                          {
                              p.ID,
                              p.AD,
                              p.SOYAD,
                              p.DEPARTMAN,
                              p.MAIL,
                              p.TELEFON
                          };
            gridControl1.DataSource = degerler.ToList();

            TxtDepartman.Properties.DataSource =(from x in db.TblDepartman
                                               select new
                                               {
                                                   x.ID,
                                                   x.AD
                                               }).ToList();

            labelControl5.Text =db.TblPersonel.First(x=>x.ID==1).AD+" "+ db.TblPersonel.First(x => x.ID == 1).SOYAD;
            labelControl6.Text = db.TblPersonel.First(x => x.ID == 1).TblDepartman.AD;
            labelControl8.Text = db.TblPersonel.First(x => x.ID == 1).MAIL;

            labelControl15.Text = db.TblPersonel.First(x => x.ID == 2).AD + " " + db.TblPersonel.First(x => x.ID == 2).SOYAD;
            labelControl14.Text = db.TblPersonel.First(x => x.ID == 2).TblDepartman.AD;
            labelControl13.Text = db.TblPersonel.First(x => x.ID == 2).MAIL;

            labelControl21.Text = db.TblPersonel.First(x => x.ID == 3).AD + " " + db.TblPersonel.First(x => x.ID == 3).SOYAD;
            labelControl20.Text = db.TblPersonel.First(x => x.ID == 3).TblDepartman.AD;
            labelControl19.Text = db.TblPersonel.First(x => x.ID == 3).MAIL;

            labelControl27.Text = db.TblPersonel.First(x => x.ID == 4).AD + " " + db.TblPersonel.First(x => x.ID == 4).SOYAD;
            labelControl26.Text = db.TblPersonel.First(x => x.ID == 4).TblDepartman.AD;
            labelControl25.Text = db.TblPersonel.First(x => x.ID == 4).MAIL;
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TblPersonel t = new TblPersonel();
            t.AD = TxtAd.Text;
            t.SOYAD = TxtSoyad.Text;
            t.DEPARTMAN = byte.Parse(TxtDepartman.EditValue.ToString());
            t.MAIL = TxtMail.Text;
            t.TELEFON = TxtTelefon.Text;
            db.TblPersonel.Add(t);
            db.SaveChanges();
            MessageBox.Show("Personel Bilgileri Başarıyla Kaydedildi.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            var degerler = from p in db.TblPersonel
                           select new
                           {
                               p.ID,
                               p.AD,
                               p.SOYAD,
                               p.DEPARTMAN,
                               p.MAIL,
                               p.TELEFON
                           };
            gridControl1.DataSource = degerler.ToList();
        }
    }
}
