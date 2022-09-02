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
    public partial class FrmAnasayfa : Form
    {
        public FrmAnasayfa()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmAnasayfa_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblUrun
                                       select new
                                       {
                                           x.MARKA,
                                           x.AD,
                                           x.STOK
                                       }).Where(x => x.STOK < 50).ToList();

            gridControl2.DataSource = (from x in db.TblCari
                                       select new
                                       {
                                           x.AD,
                                           x.SOYAD,
                                           x.IL
                                       }).ToList();

            gridControl3.DataSource =db.urunKategori().ToList();
            
            DateTime bugun = DateTime.Today;
            gridControl4.DataSource = (from x in db.TblNotlarim.OrderBy(y=>y.ID) where(x.TARIH==bugun)
                                       select new
                                       {
                                           x.BASLIK,
                                           x.ICERIK
                                       }).ToList();

            String ad1, konu1, ad2, konu2, ad3, konu3, ad4, konu4, ad5, konu5;
            
            ad1 =db.Tbl_Iletisim.First(x=>x.ID==1).ADSOYAD;
            konu1= db.Tbl_Iletisim.First(x => x.ID == 1).KONU;
            labelControl1.Text =ad1+" - "+konu1;

            ad2 = db.Tbl_Iletisim.First(x => x.ID == 2).ADSOYAD;
            konu2 = db.Tbl_Iletisim.First(x => x.ID == 2).KONU;
            labelControl2.Text = ad2 + " - " + konu2;

            ad3 = db.Tbl_Iletisim.First(x => x.ID == 3).ADSOYAD;
            konu3 = db.Tbl_Iletisim.First(x => x.ID == 3).KONU;
            labelControl3.Text = ad3 + " - " + konu3;

            ad4 = db.Tbl_Iletisim.First(x => x.ID == 4).ADSOYAD;
            konu4 = db.Tbl_Iletisim.First(x => x.ID == 4).KONU;
            labelControl4.Text = ad4 + " - " + konu4;

            ad5 = db.Tbl_Iletisim.First(x => x.ID == 5).ADSOYAD;
            konu5 = db.Tbl_Iletisim.First(x => x.ID == 5).KONU;
            labelControl5.Text = ad5 + " - " + konu5;
        }
    }
}
