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
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = db.TblNotlarim.Where(x=>x.DURUM==false).ToList();
            gridControl2.DataSource = db.TblNotlarim.Where(y => y.DURUM == true).ToList();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if(TxtBaslik.Text==null && TxtIcerik.Text==null)
            {
                TblNotlarim t = new TblNotlarim();
                t.BASLIK = TxtBaslik.Text;
                t.ICERIK = TxtIcerik.Text;
                t.DURUM = false;
                t.TARIH =DateTime.Parse(TxtTarih.Text);
                db.TblNotlarim.Add(t);
                db.SaveChanges();
                MessageBox.Show("Yeni Not Başarıyla Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }else
            {
                MessageBox.Show("Lütfen Alanları Kontrol Edip Tekrar Deneyiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = db.TblNotlarim.Where(x => x.DURUM == false).ToList();
            gridControl2.DataSource = db.TblNotlarim.Where(y => y.DURUM == true).ToList();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if(checkEdit1.Checked==true)
            {
                int id = int.Parse(TxtID.Text);
                var deger =db.TblNotlarim.Find(id);
                deger.ICERIK = TxtIcerik.Text;
                deger.DURUM = true;
                db.SaveChanges();
                MessageBox.Show("Not Başarıyla Güncellendi.","Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text =gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtBaslik.Text = gridView1.GetFocusedRowCellValue("BASLIK").ToString();
            TxtIcerik.Text = gridView1.GetFocusedRowCellValue("ICERIK").ToString();
        }
    }
}
