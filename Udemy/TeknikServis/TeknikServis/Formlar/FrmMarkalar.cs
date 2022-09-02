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
    public partial class FrmMarkalar : Form
    {
        public FrmMarkalar()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmMarkalar_Load(object sender, EventArgs e)
        {
            var degerler = db.TblUrun.OrderBy(x => x.MARKA).GroupBy(y => y.MARKA).Select(z => new
            {
                Marka = z.Key,
                Toplam = z.Count()
            });
            gridControl1.DataSource = degerler.ToList();
            labelControl2.Text =db.TblUrun.Count().ToString();
            labelControl3.Text =(from x in db.TblUrun
                                 select x.MARKA).Distinct().Count().ToString();
            labelControl5.Text =db.maksUrunMarka().FirstOrDefault();
            labelControl7.Text = (from x in db.TblUrun
                                  orderby x.SATISFIYAT descending
                                  select x.MARKA).FirstOrDefault();

            
            SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-29QULOVF;Initial Catalog=DbTeknikServis;Integrated Security=True");
            //1.chart
            baglanti.Open();
            SqlCommand komut =new SqlCommand("SELECT MARKA, COUNT(*) FROM TblUrun GROUP BY MARKA",baglanti);
            SqlDataReader dr =komut.ExecuteReader();
            while(dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]),int.Parse(dr[1].ToString()));
            }
            baglanti.Close();

            //2.chart
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("SELECT TblKategori.AD, COUNT(*) FROM TblUrun INNER JOIN TblKategori ON TblKategori.ID=TblUrun.KATEGORI GROUP BY TblKategori.AD", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                chartControl2.Series["Kategoriler"].Points.AddPoint(Convert.ToString(dr2[0]), int.Parse(dr2[1].ToString()));
            }
            baglanti.Close();

        }
    }
}
