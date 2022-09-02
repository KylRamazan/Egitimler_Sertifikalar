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
    public partial class FrmIstatistik : Form
    {
        public FrmIstatistik()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmIstatistik_Load(object sender, EventArgs e)
        {
            labelControl2.Text =db.TblUrun.Count().ToString();
            labelControl3.Text = db.TblKategori.Count().ToString();
            labelControl5.Text = db.TblUrun.Sum(x=>x.STOK).ToString();
            labelControl7.Text = "10";
            labelControl12.Text = (from x in db.TblUrun
                                   orderby x.SATISFIYAT ascending
                                   select x.AD).FirstOrDefault();
            labelControl13.Text = (from x in db.TblUrun
                                   orderby x.SATISFIYAT descending
                                   select x.AD).FirstOrDefault();
            labelControl16.Text = db.maksKategoriUrun().FirstOrDefault();
            labelControl18.Text = (from x in db.TblUrun
                                   orderby x.STOK ascending
                                   select x.AD).FirstOrDefault();
            labelControl19.Text =(from x in db.TblUrun 
                                  orderby x.STOK descending
                                  select x.AD).FirstOrDefault();
            labelControl22.Text = db.TblUrun.Count(x => x.KATEGORI == 3).ToString();
            labelControl24.Text = db.TblUrun.Count(x => x.KATEGORI==1).ToString();
            labelControl28.Text = db.TblUrun.Count(x => x.KATEGORI == 4).ToString();
            labelControl33.Text =(from x in db.TblUrun
                                  select x.MARKA).Distinct().Count().ToString();
            labelControl39.Text = db.TblUrunKabul.Count().ToString();
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void labelControl4_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl5_Click(object sender, EventArgs e)
        {

        }

        private void labelControl6_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureEdit4_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl7_Click(object sender, EventArgs e)
        {

        }

        private void labelControl8_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureEdit5_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl9_Click(object sender, EventArgs e)
        {

        }

        private void labelControl10_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
