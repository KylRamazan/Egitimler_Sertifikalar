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
    public partial class FrmArizaliUrunAciklama : Form
    {
        public FrmArizaliUrunAciklama()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TblUrunTakip t = new TblUrunTakip();
            t.ACIKLAMA = TxtAciklama.Text;
            t.SERINO = TxtSeriNo.Text;
            t.TARIH = DateTime.Parse(TxtTarih.Text);
            db.TblUrunTakip.Add(t);

            //2.güncelleme
            TblUrunKabul tb = new TblUrunKabul();
            int urunId =int.Parse(id.ToString());
            var deger = db.TblUrunKabul.Find(urunId);
            deger.URUNDURUMDETAY = comboBox1.Text;
            db.SaveChanges();
            MessageBox.Show("Ürün Arıza Açıklaması Başarıyla Kaydedildi.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void pictureEdit14_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtSeriNo_Click(object sender, EventArgs e)
        {
            TxtSeriNo.Text = "";
            TxtSeriNo.Focus();
        }

        private void TxtTarih_Click(object sender, EventArgs e)
        {
            TxtTarih.Text = DateTime.Now.ToShortDateString();
        }

        private void TxtAciklama_Click(object sender, EventArgs e)
        {
            TxtAciklama.Text = "";
            TxtAciklama.Focus();
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string id,seriNo;
        private void FrmArizaliUrunAciklama_Load(object sender, EventArgs e)
        {
            TxtSeriNo.Text = seriNo;
        }
    }
}
