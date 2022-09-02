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
using System.Xml;

namespace TicariOtomasyon
{
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }

        sqlBaglantisi bgl = new sqlBaglantisi();

        void stokListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select URUNAD,Sum(ADET) As ADET From TblUrunler Group By URUNAD Having Sum(ADET)<=20 Order By Sum(ADET)",bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void notListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select Top 10 TARIH,SAAT,BASLIK From TblNotlar Order By ID Desc", bgl.baglanti());
            da.Fill(dt);
            gridControl2.DataSource = dt;
        }

        void firmaHareketListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Execute FirmaHareketler2", bgl.baglanti());
            da.Fill(dt);
            gridControl4.DataSource = dt;
        }

        void firmaFihristListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select AD,TELEFON From TblFirmalar", bgl.baglanti());
            da.Fill(dt);
            gridControl3.DataSource = dt;
        }

        
        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {
            stokListesi();
            notListesi();
            firmaHareketListesi();
            firmaFihristListesi();
            webBrowser1.Navigate("https://www.tcmb.gov.tr/kurlar/today.xml");
            webBrowser2.Navigate("https://www.youtube.com.tr");
        }
    }
}
