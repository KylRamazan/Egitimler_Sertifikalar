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
    public partial class FrmYeniDepartman : Form
    {
        public FrmYeniDepartman()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TblDepartman t = new TblDepartman();
            if (TxtDepartmanAdi.Text.Length <= 50 && TxtDepartmanAdi.Text != null && TxtAciklama.Text.Length >= 1)
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
    }
}
