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
    public partial class FrmFaturaListesi : Form
    {
        public FrmFaturaListesi()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmFaturaListesi_Load(object sender, EventArgs e)
        {
            var degerler =from f in db.TblFaturaBilgi
                          select new
                          {
                              f.ID,
                              f.SERI,
                              f.SIRANO,
                              f.TARIH,
                              f.SAAT,
                              f.VERGIDAIRE,
                              CARI=f.TblCari.AD + " " + f.TblCari.SOYAD,
                              PERSONEL=f.TblPersonel.AD + " " +f.TblPersonel.SOYAD
                          };
            gridControl1.DataSource = degerler.ToList();

            lookUpEdit1.Properties.DataSource =(from x in db.TblCari
                                                select new
                                                {
                                                    x.ID,
                                                    AD=x.AD+" "+x.SOYAD
                                                }).ToList();

            lookUpEdit2.Properties.DataSource = (from x in db.TblPersonel
                                                 select new
                                                 {
                                                     x.ID,
                                                     AD = x.AD + " " + x.SOYAD
                                                 }).ToList();
        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void labelControl8_Click(object sender, EventArgs e)
        {

        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            var degerler = from f in db.TblFaturaBilgi
                           select new
                           {
                               f.ID,
                               f.SERI,
                               f.SIRANO,
                               f.TARIH,
                               f.SAAT,
                               f.VERGIDAIRE,
                               CARI = f.TblCari.AD + " " + f.TblCari.SOYAD,
                               PERSONEL = f.TblPersonel.AD + " " + f.TblPersonel.SOYAD
                           };
            gridControl1.DataSource = degerler.ToList();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TblFaturaBilgi t = new TblFaturaBilgi();
            t.SERI = TxtSeriNo.Text;
            t.SIRANO = TxtSiraNo.Text;
            t.TARIH = DateTime.Parse(TxtTarih.Text);
            t.SAAT = TxtSaat.Text;
            t.VERGIDAIRE = TxtVergiDairesi.Text;
            t.CARI = int.Parse(lookUpEdit1.EditValue.ToString());
            t.PERSONEL = short.Parse(lookUpEdit2.EditValue.ToString());
            db.TblFaturaBilgi.Add(t);
            db.SaveChanges();
            MessageBox.Show("Fatura Başarıyla Kaydedildi.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        FrmFaturaKalemPopup fr;
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (fr == null || fr.IsDisposed)
            {
                fr= new FrmFaturaKalemPopup();
                fr.id = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                fr.Show();
            }
        }
    }
}
