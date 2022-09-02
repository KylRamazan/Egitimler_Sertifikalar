using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TeknikServis.Formlar
{
    public partial class FrmArizaListesi : Form
    {
        public FrmArizaListesi()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmArizaListesi_Load(object sender, EventArgs e)
        {
            var degerler =from x in db.TblUrunKabul
                          select new
                          {
                              x.ISLEMID,
                              CARİ=x.TblCari.AD +" "+ x.TblCari.SOYAD,
                              PERSONEL=x.TblPersonel.AD +" "+ x.TblPersonel.SOYAD,
                              x.GELISTARIHI,
                              x.CIKISTARIHI,
                              x.URUNSERINO,
                              x.URUNDURUMDETAY
                          };
            gridControl1.DataSource = degerler.ToList();

            labelControl3.Text = db.TblUrunKabul.Count(x=>x.URUNDURUM==true).ToString();
            labelControl5.Text = db.TblUrunKabul.Count(x => x.URUNDURUM == false).ToString();
            labelControl13.Text = db.TblUrun.Count().ToString();
            labelControl7.Text =db.TblUrunKabul.Count(x => x.URUNDURUMDETAY=="Parça Bekliyor.").ToString();
            labelControl1.Text = db.TblUrunKabul.Count(x => x.URUNDURUMDETAY == "Mesaj Bekliyor.").ToString();
            labelControl11.Text = db.TblUrunKabul.Count(x => x.URUNDURUMDETAY == "İptal Bekliyor.").ToString();

            SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-29QULOVF;Initial Catalog=DbTeknikServis;Integrated Security=True");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT URUNDURUMDETAY, COUNT(*) FROM TblUrunKabul GROUP BY URUNDURUMDETAY", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
            }
            baglanti.Close();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmArizaliUrunAciklama fr = new FrmArizaliUrunAciklama();
            fr.id =gridView1.GetFocusedRowCellValue("ISLEMID").ToString();
            fr.seriNo = gridView1.GetFocusedRowCellValue("URUNSERINO").ToString();
            fr.Show();
        }
    }
}
