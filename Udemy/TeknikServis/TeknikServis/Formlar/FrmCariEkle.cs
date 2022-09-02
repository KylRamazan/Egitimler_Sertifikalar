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
    public partial class FrmCariEkle : Form
    {
        public FrmCariEkle()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        int secilen;
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TblCari t = new TblCari();
            t.AD = TxtAd.Text;
            t.SOYAD = TxtSoyad.Text;
            t.TELEFON = TxtTelefon.Text;
            t.MAIL = TxtMail.Text;
            t.IL = Txtil.Text;
            t.ILCE = Txtilce.Text;
            t.BANKA = TxtBanka.Text;
            t.VERGIDAIRESI = TxtVergiDairesi.Text;
            t.VERGINO = TxtVergiNo.Text;
            t.STATU = TxtStatü.Text;
            t.ADRES = TxtAdres.Text;

            db.TblCari.Add(t);
            db.SaveChanges();
            MessageBox.Show("Yeni Cari Başarıyla Eklendi.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void FrmCariEkle_Load(object sender, EventArgs e)
        {
            Txtil.Properties.DataSource = (from x in db.Tbl_Iller
                                                 select new
                                                 {
                                                     x.id,
                                                     x.sehir
                                                 }).ToList();
        }

        private void pictureEdit14_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtAd_Click(object sender, EventArgs e)
        {
            TxtAd.Text = "";
            TxtAd.Focus();
        }

        private void TxtSoyad_Click(object sender, EventArgs e)
        {
            TxtSoyad.Text = "";
            TxtSoyad.Focus();
        }

        private void TxtMail_Click(object sender, EventArgs e)
        {
            TxtMail.Text = "";
            TxtMail.Focus();
        }

        private void TxtBanka_Click(object sender, EventArgs e)
        {
            TxtBanka.Text = "";
            TxtBanka.Focus();
        }

        private void TxtVergiDairesi_Click(object sender, EventArgs e)
        {
            TxtVergiDairesi.Text = "";
            TxtVergiDairesi.Focus();
        }

        private void TxtVergiNo_Click(object sender, EventArgs e)
        {
            TxtVergiNo.Text = "";
            TxtVergiNo.Focus();
        }

        private void TxtStatü_Click(object sender, EventArgs e)
        {
            TxtStatü.Text = "";
            TxtStatü.Focus();
        }

        private void TxtAdres_Click(object sender, EventArgs e)
        {
            TxtAdres.Text = "";
            TxtAdres.Focus();
        }

        private void Txtil_EditValueChanged(object sender, EventArgs e)
        {
            secilen = int.Parse(Txtil.EditValue.ToString());
            Txtilce.Properties.DataSource = (from y in db.Tbl_Ilceler
                                                 select new
                                                 {
                                                     y.id,
                                                     y.ilce,
                                                     y.sehir
                                                 }).Where(z => z.sehir == secilen).ToList();
        }
    }
}
