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
    public partial class FrmFaturaKalem : Form
    {
        public FrmFaturaKalem()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmFaturaKalem_Load(object sender, EventArgs e)
        {
            var degerler =from d in db.TblFaturaDetay
                          select new
                          {
                              d.FATURADETAYID,
                              d.URUN,
                              d.ADET,
                              d.FIYAT,
                              d.TUTAR,
                              d.FATURAID
                          };
            gridControl1.DataSource = degerler.ToList();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TblFaturaDetay t = new TblFaturaDetay();
            t.URUN = TxtUrun.Text;
            t.ADET = short.Parse(TxtAdet.Text);
            t.FIYAT = decimal.Parse(TxtFiyat.Text);
            t.TUTAR = decimal.Parse(TxtTutar.Text);
            t.FATURAID = int.Parse(TxtFaturaId.Text);
            db.TblFaturaDetay.Add(t);
            db.SaveChanges();
            MessageBox.Show("Fatura Kalem İşlemi Başarıyla Kaydedildi.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            var degerler = from d in db.TblFaturaDetay
                           select new
                           {
                               d.FATURADETAYID,
                               d.URUN,
                               d.ADET,
                               d.FIYAT,
                               d.TUTAR,
                               d.FATURAID
                           };
            gridControl1.DataSource = degerler.ToList();
        }
    }
}
