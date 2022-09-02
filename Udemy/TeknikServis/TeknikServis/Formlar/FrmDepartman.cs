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
    public partial class FrmDepartman : Form
    {
        public FrmDepartman()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmDepartman_Load(object sender, EventArgs e)
        {
            var degerler =from d in db.TblDepartman
                          select new
                          {
                              d.ID,
                              d.AD,
                              d.ACIKLAMA
                          };
            gridControl1.DataSource =degerler.ToList();
            labelControl12.Text =db.TblDepartman.Count().ToString();
            labelControl14.Text = db.TblPersonel.Count().ToString();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TblDepartman t = new TblDepartman();
            if(TxtDepartmanAdi.Text.Length <=50 && TxtDepartmanAdi.Text != null && TxtAciklama.Text.Length >= 1)
            {
                t.AD = TxtDepartmanAdi.Text;
                t.ACIKLAMA = TxtAciklama.Text;
                db.TblDepartman.Add(t);
                db.SaveChanges();
                MessageBox.Show("Departman Başarıyla Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lütfen Alanları Kontrol Edip Tekrar Deneyiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id =int.Parse(TxtID.Text);
            var deger =db.TblDepartman.Find(id);
            db.TblDepartman.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Departman Başarıyla Silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.TblDepartman.Find(id);
            deger.AD = TxtDepartmanAdi.Text;
            deger.ACIKLAMA = TxtAciklama.Text;
            db.SaveChanges();
            MessageBox.Show("Departman Başarıyla Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            var degerler = from d in db.TblDepartman
                           select new
                           {
                               d.ID,
                               d.AD,
                               d.ACIKLAMA
                           };
            gridControl1.DataSource = degerler.ToList();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtDepartmanAdi.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
            TxtAciklama.Text = gridView1.GetFocusedRowCellValue("ACIKLAMA").ToString();
        }
    }
}
