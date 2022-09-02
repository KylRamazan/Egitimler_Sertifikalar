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
    public partial class FrmUrunListesi : Form
    {
        public FrmUrunListesi()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        public void method1()
        {
            var degerler = from urun in db.TblUrun
                           select new
                           {
                               urun.ID,
                               urun.AD,
                               urun.MARKA,
                               KATEGORI = urun.TblKategori.AD,
                               urun.ALISFIYAT,
                               urun.SATISFIYAT,
                               urun.STOK
                           };
            gridControl1.DataSource = degerler.ToList();
        }
        private void FrmUrunListesi_Load(object sender, EventArgs e)
        {
            //Listeleme
            //var degerler = db.TblUrun.ToList();  => butun alanlar geliyor
            method1();
            lookUpEdit1.Properties.DataSource =(from x in db.TblKategori
                                                select new
                                                {
                                                    x.ID,
                                                    x.AD
                                                }).ToList();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TblUrun t = new TblUrun();
            t.AD = TxtUrunAdi.Text;
            t.MARKA = TxtMarka.Text;
            t.ALISFIYAT = decimal.Parse(TxtAlisFiyat.Text);
            t.SATISFIYAT=decimal.Parse(TxtSatisFiyat.Text);
            t.STOK = short.Parse(TxtStok.Text);
            t.KATEGORI = byte.Parse(lookUpEdit1.EditValue.ToString());
            t.DURUM = false;
            db.TblUrun.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün Başarıyla Kaydedildi.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            method1();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtUrunAdi.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
            TxtMarka.Text = gridView1.GetFocusedRowCellValue("MARKA").ToString();
            TxtAlisFiyat.Text = gridView1.GetFocusedRowCellValue("ALISFIYAT").ToString();
            TxtSatisFiyat.Text = gridView1.GetFocusedRowCellValue("SATISFIYAT").ToString();
            TxtStok.Text = gridView1.GetFocusedRowCellValue("STOK").ToString();
            lookUpEdit1.Text= gridView1.GetFocusedRowCellValue("KATEGORI").ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.TblUrun.Find(id);//tblUrun içerisinde id degiskeninin degerini bul.
            db.TblUrun.Remove(deger);//deger'e ait butun verileri kaldır.
            db.SaveChanges();
            MessageBox.Show("Ürün Başarıyla Silindi.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Stop);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.TblUrun.Find(id);
            deger.AD = TxtUrunAdi.Text;
            deger.MARKA = TxtMarka.Text;
            deger.ALISFIYAT = decimal.Parse(TxtAlisFiyat.Text);
            deger.SATISFIYAT = decimal.Parse(TxtSatisFiyat.Text);
            deger.STOK = short.Parse(TxtStok.Text);
            deger.KATEGORI = byte.Parse(lookUpEdit1.EditValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Ürün Başarıyla Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            TxtID.Text = "";
            TxtUrunAdi.Text = "";
            TxtMarka.Text = "";
            TxtAlisFiyat.Text = "";
            TxtSatisFiyat.Text = "";
            TxtStok.Text = "";
            lookUpEdit1.Text = "";
            lookUpEdit1.Properties.DataSource = (from x in db.TblKategori
                                                 select new
                                                 {
                                                     x.ID,
                                                     x.AD
                                                 }).ToList();
        }
    }
}
