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
    public partial class FrmFaturaKalemPopup : Form
    {
        public FrmFaturaKalemPopup()
        {
            InitializeComponent();
        }

        private void pictureEdit14_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        public int id;
        private void FrmFaturaKalemPopup_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource =(from x in db.TblFaturaDetay
                                      select new
                                      {
                                          x.FATURADETAYID,
                                          x.URUN,
                                          x.ADET,
                                          x.FIYAT,
                                          x.TUTAR,
                                          x.FATURAID
                                      }).Where(y=>y.FATURADETAYID==id).ToList();
            gridControl2.DataSource = (from x in db.TblFaturaBilgi
                                       select new
                                       {
                                           x.ID,
                                           x.SERI,
                                           x.SIRANO,
                                           x.TARIH,
                                           x.SAAT,
                                           x.VERGIDAIRE,
                                           x.CARI,
                                           x.PERSONEL
                                       }).Where(y => y.ID == id).ToList();
        }

        private void pictureEdit14_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            string path ="Dosya1.Pdf";
            gridControl1.ExportToPdf(path);
        }

        private void pictureEdit2_Click(object sender, EventArgs e)
        {
            string path = "Dosya1.Xls";
            gridControl1.ExportToXls(path);
        }
    }
}
