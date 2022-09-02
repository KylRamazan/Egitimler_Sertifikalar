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
using DevExpress.Charts;

namespace TicariOtomasyon
{
    public partial class FrmKasa : Form
    {
        public FrmKasa()
        {
            InitializeComponent();
        }

        sqlBaglantisi bgl = new sqlBaglantisi();

        void musteriHareketListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Execute MusteriHareketler",bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource =dt;
        }

        void firmaHareketListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Execute FirmaHareketler", bgl.baglanti());
            da.Fill(dt);
            gridControl3.DataSource = dt;
        }

        void giderListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TblGiderler", bgl.baglanti());
            da.Fill(dt);
            gridControl2.DataSource = dt;
        }

        public string ad;
        private void FrmKasa_Load(object sender, EventArgs e)
        {
            musteriHareketListesi();
            firmaHareketListesi();
            giderListesi();

            //Aktif Kullanıcı
            LblAktifKullanici.Text = ad;

            //Toplam Tutar
            SqlCommand komut = new SqlCommand("Select sum(TUTAR) From TblFaturaDetay",bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                LblToplamTutar.Text =dr[0].ToString()+" TL";
            }
            bgl.baglanti().Close();
            
            //Ödemeler (Son ay giderler)
            SqlCommand komut2 = new SqlCommand("Select (ELEKTRIK+SU+DOGALGAZ+INTERNET+MUTFAK+MAASLAR+EKSTRA) From TblGiderler Order By ID Asc", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                LblOdemeler.Text = dr2[0].ToString() + " TL";
            }
            bgl.baglanti().Close();
            
            //Personel Maaşları (Son ay maaşlar)
            SqlCommand komut3 = new SqlCommand("Select MAASLAR From TblGiderler Order By ID Asc", bgl.baglanti());
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                LblPersonelMaaslari.Text = dr3[0].ToString() + " TL";
            }
            bgl.baglanti().Close();

            //Personel Sayısı
            SqlCommand komut4 = new SqlCommand("Select Count(*) From TblPersoneller", bgl.baglanti());
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                LblPersonelSayisi.Text = dr4[0].ToString();
            }
            bgl.baglanti().Close();

            //Müşteri Sayısı
            SqlCommand komut5 = new SqlCommand("Select Count(*) From TblMusteriler", bgl.baglanti());
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                LblMusteriSayisi.Text = dr5[0].ToString();
            }
            bgl.baglanti().Close();

            //Firma Sayısı
            SqlCommand komut6 = new SqlCommand("Select Count(*) From TblFirmalar", bgl.baglanti());
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                LblFirmaSayisi.Text = dr6[0].ToString();
            }
            bgl.baglanti().Close();

            //Firma Şehir Sayısı
            SqlCommand komut7 = new SqlCommand("Select Count(Distinct(IL)) From TblFirmalar", bgl.baglanti());
            SqlDataReader dr7 = komut7.ExecuteReader();
            while (dr7.Read())
            {
                LblFirmaSehirSayisi.Text = dr7[0].ToString();
            }
            bgl.baglanti().Close();

            //Müşteri Şehir Sayısı
            SqlCommand komut8 = new SqlCommand("Select Count(Distinct(IL)) From TblMusteriler", bgl.baglanti());
            SqlDataReader dr8 = komut8.ExecuteReader();
            while (dr8.Read())
            {
                LblMusteriSehirSayisi.Text = dr8[0].ToString();
            }
            bgl.baglanti().Close();

            //Stok Sayısı
            SqlCommand komut9 = new SqlCommand("Select Sum(ADET) From TblUrunler", bgl.baglanti());
            SqlDataReader dr9 = komut9.ExecuteReader();
            while (dr9.Read())
            {
                LblStokSayisi.Text = dr9[0].ToString();
            }
            bgl.baglanti().Close();
        }

        int sayac = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;
            if(sayac>0 && sayac<=5)
            {
                //Chart1 Elektrik Faturası Listeleme (son 4 ay)
                groupControl3.Text = "Elektrik Faturaları";
                chartControl1.Series["Aylar"].Points.Clear();
                SqlCommand komut10 = new SqlCommand("Select Top 4 AY,ELEKTRIK From TblGiderler Order By ID Desc", bgl.baglanti());
                SqlDataReader dr10 = komut10.ExecuteReader();
                while (dr10.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr10[0], dr10[1]));
                }
                bgl.baglanti().Close();
            }else if(sayac > 5 && sayac <= 10)
            {
                //Chart1 Su Faturası Listeleme (son 4 ay)
                groupControl3.Text = "Su Faturaları";
                chartControl1.Series["Aylar"].Points.Clear();
                SqlCommand komut10 = new SqlCommand("Select Top 4 AY,SU From TblGiderler Order By ID Desc", bgl.baglanti());
                SqlDataReader dr10 = komut10.ExecuteReader();
                while (dr10.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr10[0], dr10[1]));
                }
                bgl.baglanti().Close();
            }
            else if (sayac > 10 && sayac <= 15)
            {
                //Chart1 Doğalgaz Faturası Listeleme (son 4 ay)
                groupControl3.Text = "Doğalgaz Faturaları";
                chartControl1.Series["Aylar"].Points.Clear();
                SqlCommand komut10 = new SqlCommand("Select Top 4 AY,DOGALGAZ From TblGiderler Order By ID Desc", bgl.baglanti());
                SqlDataReader dr10 = komut10.ExecuteReader();
                while (dr10.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr10[0], dr10[1]));
                }
                bgl.baglanti().Close();
            }
            else if (sayac > 15 && sayac <= 20)
            {
                //Chart1 İnternet Faturası Listeleme (son 4 ay)
                groupControl3.Text = "İnternet Faturaları";
                chartControl1.Series["Aylar"].Points.Clear();
                SqlCommand komut10 = new SqlCommand("Select Top 4 AY,INTERNET From TblGiderler Order By ID Desc", bgl.baglanti());
                SqlDataReader dr10 = komut10.ExecuteReader();
                while (dr10.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr10[0], dr10[1]));
                }
                bgl.baglanti().Close();
            }
            else if (sayac > 20 && sayac <= 25)
            {
                //Chart1 Mutfak Faturası Listeleme (son 4 ay)
                groupControl3.Text = "Mutfak Faturaları";
                chartControl1.Series["Aylar"].Points.Clear();
                SqlCommand komut10 = new SqlCommand("Select Top 4 AY,MUTFAK From TblGiderler Order By ID Desc", bgl.baglanti());
                SqlDataReader dr10 = komut10.ExecuteReader();
                while (dr10.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr10[0], dr10[1]));
                }
                bgl.baglanti().Close();
            }
            else if (sayac > 25 && sayac <= 30)
            {
                //Chart1 Ekstra Faturası Listeleme (son 4 ay)
                groupControl3.Text = "Ekstra Faturaları";
                chartControl1.Series["Aylar"].Points.Clear();
                SqlCommand komut10 = new SqlCommand("Select Top 4 AY,EKSTRA From TblGiderler Order By ID Desc", bgl.baglanti());
                SqlDataReader dr10 = komut10.ExecuteReader();
                while (dr10.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr10[0], dr10[1]));
                }
                bgl.baglanti().Close();
            }else if(sayac>31)
            {
                sayac = 0;
            }
        }
    }
}
