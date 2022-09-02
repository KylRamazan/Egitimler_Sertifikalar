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
    public partial class FrmUrunler : Form
    {
        public FrmUrunler()
        {
            InitializeComponent();
        }

        sqlBaglantisi bgl = new sqlBaglantisi();
        void urunListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TblUrunler", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void temizle()
        {
            TxtID.Text = "";
            TxtUrunAd.Text = "";
            TxtMarka.Text = "";
            TxtModel.Text = "";
            maskedTxtYil.Text = "";
            numericUpDown1.Value = 0;
            TxtAlisFiyat.Text = "";
            TxtSatisFiyat.Text = "";
            richTxtDetay.Text = "";
        }
        private void FrmUrunler_Load(object sender, EventArgs e)
        {
            urunListesi();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Insert into TblUrunler (URUNAD,MARKA,MODEL,YIL,ADET,ALISFIYAT,SATISFIYAT,DETAY) " +
                "Values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtUrunAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtMarka.Text);
            komut.Parameters.AddWithValue("@p3", TxtModel.Text);
            komut.Parameters.AddWithValue("@p4", maskedTxtYil.Text);
            komut.Parameters.AddWithValue("@p5", numericUpDown1.Text);
            komut.Parameters.AddWithValue("@p6", decimal.Parse(TxtAlisFiyat.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(TxtSatisFiyat.Text));
            komut.Parameters.AddWithValue("@p8", richTxtDetay.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Ekleme İşlemi Başarıyla Gerçekleştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            urunListesi();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            DialogResult onay = new DialogResult();
            onay = MessageBox.Show("Ürünü Gerçekten Silmek İstiyor Musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (onay == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("Delete From TblUrunler Where ID=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtID.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Ürün Silme İşlemi Başarıyla Gerçekleştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                urunListesi();
            }
            else
            {
                MessageBox.Show("Ürün Silme İşlemi İptal Edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TblUrunler set URUNAD=@P1,MARKA=@P2,MODEL=@P3,YIL=@P4,ADET=@P5," +
                "ALISFIYAT=@P6,SATISFIYAT=@P7,DETAY=@P8 Where ID=@P9", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtUrunAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtMarka.Text);
            komut.Parameters.AddWithValue("@p3", TxtModel.Text);
            komut.Parameters.AddWithValue("@p4", maskedTxtYil.Text);
            komut.Parameters.AddWithValue("@p5", numericUpDown1.Text);
            komut.Parameters.AddWithValue("@p6", decimal.Parse(TxtAlisFiyat.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(TxtSatisFiyat.Text));
            komut.Parameters.AddWithValue("@p8", richTxtDetay.Text);
            komut.Parameters.AddWithValue("@P9", TxtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Güncelleme İşlemi Başarıyla Gerçekleştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            urunListesi();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            TxtID.Text = dr["ID"].ToString();
            TxtUrunAd.Text = dr["URUNAD"].ToString();
            TxtMarka.Text = dr["MARKA"].ToString();
            TxtModel.Text = dr["MODEL"].ToString();
            maskedTxtYil.Text = dr["YIL"].ToString();
            numericUpDown1.Text = dr["ADET"].ToString();
            TxtAlisFiyat.Text = dr["ALISFIYAT"].ToString();
            TxtSatisFiyat.Text = dr["SATISFIYAT"].ToString();
            richTxtDetay.Text = dr["DETAY"].ToString();
        }
    }
}