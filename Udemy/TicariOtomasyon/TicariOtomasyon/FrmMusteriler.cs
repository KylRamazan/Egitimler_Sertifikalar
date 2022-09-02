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
    public partial class FrmMusteriler : Form
    {
        public FrmMusteriler()
        {
            InitializeComponent();
        }

        sqlBaglantisi bgl = new sqlBaglantisi();

        void musteriListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TblMusteriler", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void sehirListesi()
        {
            SqlCommand komut = new SqlCommand("Select SEHIR From Tbl_Iller", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBoxIl.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        void temizle()
        {
            TxtID.Text = "";
            TxtAd.Text = "";
            TxtSoyad.Text = "";
            maskedTxtTelefon.Text = "";
            maskedTxtTelefon2.Text = "";
            maskedTxtTCNo.Text = "";
            TxtMail.Text = "";
            comboBoxIl.Text = "";
            comboBoxIlce.Text = "";
            TxtVergiDairesi.Text = "";
            richTxtAdres.Text = "";
        }

        private void FrmMusteriler_Load(object sender, EventArgs e)
        {
            musteriListesi();
            sehirListesi();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Insert into TblMusteriler (AD,SOYAD,TELEFON,TELEFON2,TC,MAIL,IL,ILCE,ADRES,VERGIDAIRE) " +
                "Values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", maskedTxtTelefon.Text);
            komut.Parameters.AddWithValue("@p4", maskedTxtTelefon2.Text);
            komut.Parameters.AddWithValue("@p5", maskedTxtTCNo.Text);
            komut.Parameters.AddWithValue("@p6", TxtMail.Text);
            komut.Parameters.AddWithValue("@p7", comboBoxIl.Text);
            komut.Parameters.AddWithValue("@p8", comboBoxIlce.Text);
            komut.Parameters.AddWithValue("@p9", richTxtAdres.Text);
            komut.Parameters.AddWithValue("@p10", TxtVergiDairesi.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Müşteri Ekleme İşlemi Başarıyla Gerçekleştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            musteriListesi();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            DialogResult onay = new DialogResult();
            onay = MessageBox.Show("Müşteriyi Gerçekten Silmek İstiyor Musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (onay == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("Delete From TblMusteriler Where ID=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtID.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Müşteri Silme İşlemi Başarıyla Gerçekleştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                musteriListesi();
            }
            else
            {
                MessageBox.Show("Müşteri Silme İşlemi İptal Edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TblMusteriler set AD=@p1,SOYAD=@p2,TELEFON=@p3,TELEFON2=@p4,TC=@p5," +
                "MAIL=@p6,IL=@p7,ILCE=@p8,ADRES=@p9,VERGIDAIRE=@p10 Where ID=@P11", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", maskedTxtTelefon.Text);
            komut.Parameters.AddWithValue("@p4", maskedTxtTelefon2.Text);
            komut.Parameters.AddWithValue("@p5", maskedTxtTCNo.Text);
            komut.Parameters.AddWithValue("@p6", TxtMail.Text);
            komut.Parameters.AddWithValue("@p7", comboBoxIl.Text);
            komut.Parameters.AddWithValue("@p8", comboBoxIlce.Text);
            komut.Parameters.AddWithValue("@p9", richTxtAdres.Text);
            komut.Parameters.AddWithValue("@p10", TxtVergiDairesi.Text);
            komut.Parameters.AddWithValue("@P11", TxtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Müşteri Güncelleme İşlemi Başarıyla Gerçekleştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            musteriListesi();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void comboBoxIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxIlce.Properties.Items.Clear();
            SqlCommand komut = new SqlCommand("Select ILCE From Tbl_Ilceler Where SEHIR=@P1", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", comboBoxIl.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBoxIlce.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            TxtID.Text = dr["ID"].ToString();
            TxtAd.Text = dr["AD"].ToString();
            TxtSoyad.Text = dr["SOYAD"].ToString();
            maskedTxtTelefon.Text = dr["TELEFON"].ToString();
            maskedTxtTelefon2.Text = dr["TELEFON2"].ToString();
            maskedTxtTCNo.Text = dr["TC"].ToString();
            TxtMail.Text = dr["MAIL"].ToString();
            comboBoxIl.Text = dr["IL"].ToString();
            comboBoxIlce.Text = dr["ILCE"].ToString();
            richTxtAdres.Text = dr["ADRES"].ToString();
            TxtVergiDairesi.Text = dr["VERGIDAIRE"].ToString();
        }
    }
}
