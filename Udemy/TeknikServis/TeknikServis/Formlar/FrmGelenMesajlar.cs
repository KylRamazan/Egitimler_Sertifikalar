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
    public partial class FrmGelenMesajlar : Form
    {
        public FrmGelenMesajlar()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmGelenMesajlar_Load(object sender, EventArgs e)
        {
            labelControl12.Text =db.Tbl_Iletisim.Count().ToString();
            labelControl14.Text = db.Tbl_Iletisim.Where(x=>x.KONU=="Teşekkür").Count().ToString();
            labelControl16.Text = db.Tbl_Iletisim.Where(x => x.KONU == "Rica").Count().ToString();
            labelControl18.Text = db.Tbl_Iletisim.Where(x => x.KONU == "Şikayet").Count().ToString();

            gridControl1.DataSource =(from x in db.Tbl_Iletisim
                                      select new
                                      {
                                          x.ID,
                                          x.ADSOYAD,
                                          x.MAIL,
                                          x.KONU,
                                          x.MESAJ
                                      }).ToList();

            labelControl1.Text =db.TblPersonel.Count().ToString();
            labelControl3.Text = db.TblCari.Count().ToString();
            labelControl5.Text = db.TblKategori.Count().ToString();
            labelControl7.Text = db.TblUrun.Count().ToString();
        }
    }
}
