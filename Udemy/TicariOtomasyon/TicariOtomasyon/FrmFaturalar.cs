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

namespace TicariOtomasyon
{
    public partial class FrmFaturalar : Form
    {
        public FrmFaturalar()
        {
            InitializeComponent();
        }

        sqlBaglantisi bgl = new sqlBaglantisi();

        void faturaBilgiListesi()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From TblFaturaBilgi", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void temizle()
        {
            TxtID.Text = "";
            TxtSeri.Text = "";
            TxtSiraNo.Text = "";
            maskedTxtTarih.Text = "";
            maskedTxtSaat.Text = "";
            TxtVergiDaire.Text = "";
            TxtAlici.Text = "";
            TxtTeslimEden.Text = "";
            TxtTeslimAlan.Text = "";
        }

        void temizle2()
        {
            TxtUrunID.Text = "";
            TxtUrunAd.Text = "";
            TxtMiktar.Text = "";
            TxtFiyat.Text = "";
            TxtTutar.Text = "";
            TxtFaturaID.Text = "";
        }

        void firmaListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select ID,AD From TblFirmalar", bgl.baglanti());
            da.Fill(dt);
            lookUpEditFirma.Properties.NullText = "Lütfen Firma Seçiniz.";
            lookUpEditFirma.Properties.ValueMember = "ID";
            lookUpEditFirma.Properties.DisplayMember = "AD";
            lookUpEditFirma.Properties.DataSource = dt;
        }

        void personelListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select ID,(AD+' '+SOYAD) As AD From TblPersoneller", bgl.baglanti());
            da.Fill(dt);
            lookUpEditPersonel.Properties.NullText = "Lütfen Personel Seçiniz.";
            lookUpEditPersonel.Properties.ValueMember = "ID";
            lookUpEditPersonel.Properties.DisplayMember = "AD";
            lookUpEditPersonel.Properties.DataSource = dt;
        }

        private void FrmFaturalar_Load(object sender, EventArgs e)
        {
            faturaBilgiListesi();
            firmaListesi();
            personelListesi();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if(TxtFaturaID.Text == "")
            {
                SqlCommand komut = new SqlCommand("Insert into TblFaturaBilgi (SERI,SIRANO,TARIH,SAAT,VERGIDAIRE,ALICI," +
                "TESLIMEDEN,TESLIMALAN) Values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtSeri.Text);
                komut.Parameters.AddWithValue("@p2", TxtSiraNo.Text);
                komut.Parameters.AddWithValue("@p3", maskedTxtTarih.Text);
                komut.Parameters.AddWithValue("@p4", maskedTxtSaat.Text);
                komut.Parameters.AddWithValue("@p5", TxtVergiDaire.Text);
                komut.Parameters.AddWithValue("@p6", TxtAlici.Text);
                komut.Parameters.AddWithValue("@p7", TxtTeslimEden.Text);
                komut.Parameters.AddWithValue("@p8", TxtTeslimAlan.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Fatura Bilgisi Ekleme İşlemi Başarıyla Gerçekleştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                faturaBilgiListesi();
            }
        }
        
        private void BtnSil_Click(object sender, EventArgs e)
        {
            DialogResult onay = new DialogResult();
            onay = MessageBox.Show("Fatura Bilgisini Gerçekten Silmek İstiyor Musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (onay == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("Delete From TblFaturaBilgi Where FATURABILGIID=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtID.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Fatura Bilgi Silme İşlemi Başarıyla Gerçekleştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                faturaBilgiListesi();
            }
            else
            {
                MessageBox.Show("Fatura Bilgi Silme İşlemi İptal Edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TblFaturaBilgi set SERI=@p1,SIRANO=@p2,TARIH=@p3,SAAT=@p4,VERGIDAIRE=@p5," +
                "ALICI=@p6,TESLIMEDEN=@p7,TESLIMALAN=@p8 Where FATURABILGIID=@p9", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtSeri.Text);
            komut.Parameters.AddWithValue("@p2", TxtSiraNo.Text);
            komut.Parameters.AddWithValue("@p3", maskedTxtTarih.Text);
            komut.Parameters.AddWithValue("@p4", maskedTxtSaat.Text);
            komut.Parameters.AddWithValue("@p5", TxtVergiDaire.Text);
            komut.Parameters.AddWithValue("@p6", TxtAlici.Text);
            komut.Parameters.AddWithValue("@p7", TxtTeslimEden.Text);
            komut.Parameters.AddWithValue("@p8", TxtTeslimAlan.Text);
            komut.Parameters.AddWithValue("@p9", TxtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Fatura Bilgi Güncelleme İşlemi Başarıyla Gerçekleştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            faturaBilgiListesi();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void BtnKaydet2_Click(object sender, EventArgs e)
        {
            //Firma Cari
            if(TxtFaturaID.Text != "" && comboBox1.Text=="Firma")
            {
                SqlCommand komut = new SqlCommand("Insert into TblFaturaDetay (URUNAD,MIKTAR,FIYAT,TUTAR,FATURAID) " +
                    "Values(@p1,@p2,@p3,@p4,@p5)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtUrunAd.Text);
                komut.Parameters.AddWithValue("@p2", TxtMiktar.Text);
                komut.Parameters.AddWithValue("@p3", decimal.Parse(TxtFiyat.Text));
                komut.Parameters.AddWithValue("@p4", decimal.Parse(TxtTutar.Text));
                komut.Parameters.AddWithValue("@p5", TxtFaturaID.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();

                //Hareket Tablosuna Veri Girişi
                SqlCommand komut2 = new SqlCommand("Insert into TblFirmaHareketler (URUNID,ADET,PERSONEL,FIRMA,FIYAT," +
                    "TOPLAM,FATURAID,TARIH) Values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", TxtUrunID.Text);
                komut2.Parameters.AddWithValue("@p2", TxtMiktar.Text);
                komut2.Parameters.AddWithValue("@p3", lookUpEditPersonel.EditValue);
                komut2.Parameters.AddWithValue("@p4", lookUpEditFirma.EditValue);
                komut2.Parameters.AddWithValue("@p5", decimal.Parse(TxtFiyat.Text));
                komut2.Parameters.AddWithValue("@p6", decimal.Parse(TxtTutar.Text));
                komut2.Parameters.AddWithValue("@p7", TxtFaturaID.Text);
                komut2.Parameters.AddWithValue("@p8", maskedTxtTarih.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();

                //Stok Sayısı Azaltma
                SqlCommand komut3 = new SqlCommand("Update TblUrunler Set ADET=ADET-@p1 Where ID=@p2", bgl.baglanti());
                komut3.Parameters.AddWithValue("@p1", TxtMiktar.Text);
                komut3.Parameters.AddWithValue("@p2", TxtUrunID.Text);
                komut3.ExecuteNonQuery();
                bgl.baglanti().Close();

                MessageBox.Show("Fatura Detay Ekleme İşlemi Başarıyla Gerçekleştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                faturaBilgiListesi();
            }

            //Müşteri Cari
            if (TxtFaturaID.Text != "" && comboBox1.Text == "Müşteri")
            {
                SqlCommand komut = new SqlCommand("Insert into TblFaturaDetay (URUNAD,MIKTAR,FIYAT,TUTAR,FATURAID) " +
                    "Values(@p1,@p2,@p3,@p4,@p5)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtUrunAd.Text);
                komut.Parameters.AddWithValue("@p2", TxtMiktar.Text);
                komut.Parameters.AddWithValue("@p3", decimal.Parse(TxtFiyat.Text));
                komut.Parameters.AddWithValue("@p4", decimal.Parse(TxtTutar.Text));
                komut.Parameters.AddWithValue("@p5", TxtFaturaID.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();

                //Hareket Tablosuna Veri Girişi
                SqlCommand komut2 = new SqlCommand("Insert into TblMusteriHareketler (URUNID,ADET,PERSONEL,MUSTERI,FIYAT," +
                    "TOPLAM,FATURAID,TARIH) Values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", TxtUrunID.Text);
                komut2.Parameters.AddWithValue("@p2", TxtMiktar.Text);
                komut2.Parameters.AddWithValue("@p3", lookUpEditPersonel.EditValue);
                komut2.Parameters.AddWithValue("@p4", lookUpEditFirma.EditValue);
                komut2.Parameters.AddWithValue("@p5", decimal.Parse(TxtFiyat.Text));
                komut2.Parameters.AddWithValue("@p6", decimal.Parse(TxtTutar.Text));
                komut2.Parameters.AddWithValue("@p7", TxtFaturaID.Text);
                komut2.Parameters.AddWithValue("@p8", maskedTxtTarih.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();

                //Stok Sayısı Azaltma
                SqlCommand komut3 = new SqlCommand("Update TblUrunler Set ADET=ADET-@p1 Where ID=@p2", bgl.baglanti());
                komut3.Parameters.AddWithValue("@p1", TxtMiktar.Text);
                komut3.Parameters.AddWithValue("@p2", TxtUrunID.Text);
                komut3.ExecuteNonQuery();
                bgl.baglanti().Close();

                MessageBox.Show("Fatura Detay Ekleme İşlemi Başarıyla Gerçekleştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                faturaBilgiListesi();
            }
        }

        private void BtnTemizle2_Click(object sender, EventArgs e)
        {
            temizle2();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            TxtID.Text = dr["FATURABILGIID"].ToString();
            TxtSeri.Text = dr["SERI"].ToString();
            TxtSiraNo.Text = dr["SIRANO"].ToString();
            maskedTxtTarih.Text = dr["TARIH"].ToString();
            maskedTxtSaat.Text = dr["SAAT"].ToString();
            TxtVergiDaire.Text = dr["VERGIDAIRE"].ToString();
            TxtAlici.Text = dr["ALICI"].ToString();
            TxtTeslimEden.Text = dr["TESLIMEDEN"].ToString();
            TxtTeslimAlan.Text = dr["TESLIMALAN"].ToString();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmFaturaUrunler fr = new FrmFaturaUrunler();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                fr.id = dr["FATURABILGIID"].ToString();
                fr.Show();
            }
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select URUNAD,SATISFIYAT From TblUrunler Where ID=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",TxtUrunID.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                TxtUrunAd.Text =dr[0].ToString();
                TxtFiyat.Text =dr[1].ToString();
            }
            bgl.baglanti().Close();
            if(TxtUrunAd.Text =="")
            {
                MessageBox.Show("Bu ID'ye Ait Ürün Bulunamadı!","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void BtnHesapla_Click(object sender, EventArgs e)
        {
            double miktar = 0.0, tutar = 0.0, fiyat = 0.0;
            fiyat = Convert.ToDouble(TxtFiyat.Text);
            miktar = Convert.ToDouble(TxtMiktar.Text);
            tutar = miktar * fiyat;
            TxtTutar.Text = tutar.ToString();
        }
    }
}
