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
    public partial class FrmArizaliUrunKaydi : Form
    {
        public FrmArizaliUrunKaydi()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void BtnSatisYap_Click(object sender, EventArgs e)
        {
            TblUrunKabul t = new TblUrunKabul();
            t.CARI =int.Parse(lookUpEdit1.EditValue.ToString());
            t.GELISTARIHI =DateTime.Parse(TxtTarih.Text);
            t.PERSONEL = short.Parse(lookUpEdit2.EditValue.ToString());
            t.URUNSERINO = TxtSeriNo.Text;
            t.URUNDURUMDETAY = "Ürün Kaydedildi";
            db.TblUrunKabul.Add(t);
            db.SaveChanges();
            MessageBox.Show("Arıza Kaydı Başarıyla Oluşturuldu.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void pictureEdit14_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureEdit14_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmArizaliUrunKaydi_Load(object sender, EventArgs e)
        {
            lookUpEdit1.Properties.DataSource = (from x in db.TblCari
                                                 select new
                                                 {
                                                     x.ID,
                                                     x.AD,
                                                     x.SOYAD
                                                 }).ToList();

            lookUpEdit2.Properties.DataSource = (from x in db.TblPersonel
                                                 select new
                                                 {
                                                     x.ID,
                                                     x.AD,
                                                     x.SOYAD
                                                 }).ToList();
        }

        private void TxtSeriNo_Click(object sender, EventArgs e)
        {
            TxtSeriNo.Text = "";
            TxtSeriNo.Focus();
        }

        private void TxtTarih_Click(object sender, EventArgs e)
        {
            TxtTarih.Text =DateTime.Now.ToShortDateString();
        }
    }
}
