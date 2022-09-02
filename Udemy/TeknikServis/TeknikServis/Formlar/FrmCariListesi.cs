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
    public partial class FrmCariListesi : Form
    {
        public FrmCariListesi()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        int secilen;
        void liste()
        {
            gridControl1.DataSource = (from x in db.TblCari
                                       select new
                                       {
                                           x.ID,
                                           x.AD,
                                           x.SOYAD,
                                           x.MAIL,
                                           x.TELEFON,
                                           x.IL,
                                           x.ILCE,
                                           x.ADRES,
                                           x.BANKA,
                                           x.VERGIDAIRESI,
                                           x.VERGINO
                                       }).ToList();
        }
        private void FrmCariListesi_Load(object sender, EventArgs e)
        {
            liste();
            labelControl12.Text =db.TblCari.Count().ToString();

            
            lookUpEdit1.Properties.DataSource =(from x in db.Tbl_Iller
                                                select new
                                                {
                                                    x.id,
                                                    x.sehir
                                                }).ToList();

            labelControl16.Text =db.TblCari.Select(x=>x.IL).Distinct().Count().ToString();
            labelControl18.Text = db.TblCari.Select(x => x.ILCE).Distinct().Count().ToString();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            secilen =int.Parse(lookUpEdit1.EditValue.ToString());
            lookUpEdit2.Properties.DataSource = (from y in db.Tbl_Ilceler
                                                 select new
                                                 {
                                                     y.id,
                                                     y.ilce,
                                                     y.sehir
                                                 }).Where(z=>z.sehir==secilen).ToList();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if(TxtCariAd.Text!="" && TxtCariSoyad.Text !="" && TxtTelefon.Text!="")
            {
                TblCari t = new TblCari();
                t.AD = TxtCariAd.Text;
                t.SOYAD = TxtCariSoyad.Text;
                t.TELEFON = TxtTelefon.Text;
                t.IL = lookUpEdit1.Text;
                t.ILCE = lookUpEdit2.Text;
                t.BANKA = TxtBanka.Text;
                t.VERGIDAIRESI = TxtVergiDairesi.Text;
                t.VERGINO = TxtVergiNo.Text;
                t.STATU = TxtStatu.Text;
                t.ADRES = TxtAdres.Text;
                db.TblCari.Add(t);
                db.SaveChanges();
                MessageBox.Show("Cari Başarıyla Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }else
            {
                MessageBox.Show("Lütfen Bütün Alanları Kontrol Ediniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            liste();
        }
    }
}
