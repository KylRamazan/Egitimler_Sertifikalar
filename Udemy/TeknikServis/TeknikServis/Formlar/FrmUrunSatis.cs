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
    public partial class FrmUrunSatis : Form
    {
        public FrmUrunSatis()
        {
            InitializeComponent();
        }

        private void textEdit7_EditValueChanged(object sender, EventArgs e)
        {

        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void BtnSatisYap_Click(object sender, EventArgs e)
        {
            TblUrunHareket t = new TblUrunHareket();
            t.URUN = int.Parse(TxtUrunID.EditValue.ToString());
            t.MUSTERI = int.Parse(TxtMusteri.EditValue.ToString());
            t.PERSONEL = short.Parse(TxtPersonel.EditValue.ToString());
            t.TARIH =DateTime.Parse(TxtTarih.Text);
            t.ADET =short.Parse(TxtAdet.Text);
            t.FIYAT = decimal.Parse(TxtSatisFiyati.Text);
            t.URUNSERINO =TxtSeriNo.Text;
            db.TblUrunHareket.Add(t);
            db.SaveChanges();
            MessageBox.Show("Satış İşlemi Başarıyla Gerçekleştirildi.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void pictureEdit14_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtAdet_Click(object sender, EventArgs e)
        {
            TxtAdet.Text = "";
            TxtAdet.Focus();
        }

        private void TxtSatisFiyati_Click(object sender, EventArgs e)
        {
            TxtSatisFiyati.Text = "";
            TxtSatisFiyati.Focus();
        }

        private void TxtSeriNo_Click(object sender, EventArgs e)
        {
            TxtSeriNo.Text = "";
            TxtSeriNo.Focus();
        }

        private void FrmUrunSatis_Load(object sender, EventArgs e)
        {
            TxtUrunID.Properties.DataSource =(from x in db.TblUrun
                                              select new
                                              {
                                                  x.ID,
                                                  x.MARKA,
                                                  x.AD
                                              }).ToList();

            TxtMusteri.Properties.DataSource = (from x in db.TblCari
                                               select new
                                               {
                                                   x.ID,
                                                   x.AD,
                                                   x.SOYAD
                                               }).ToList();

            TxtPersonel.Properties.DataSource = (from x in db.TblPersonel
                                               select new
                                               {
                                                   x.ID,
                                                   x.AD,
                                                   x.SOYAD
                                               }).ToList();
        }

        private void TxtTarih_Click(object sender, EventArgs e)
        {
            TxtTarih.Text = DateTime.Now.ToShortDateString();
        }
    }
}
