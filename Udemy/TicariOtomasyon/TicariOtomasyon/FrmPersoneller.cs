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
    public partial class FrmPersoneller : Form
    {
        public FrmPersoneller()
        {
            InitializeComponent();
        }

        sqlBaglantisi bgl = new sqlBaglantisi();

        void personelListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TblPersoneller", bgl.baglanti());
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
            maskedTxtTCNo.Text = "";
            TxtMail.Text = "";
            comboBoxIl.Text = "";
            comboBoxIlce.Text = "";
            richTxtAdres.Text = "";
            TxtGorev.Text = "";
        }

        private void FrmPersoneller_Load(object sender, EventArgs e)
        {
            personelListesi();
            sehirListesi();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Insert into TblPersoneller (AD,SOYAD,TELEFON,TC,MAIL,IL,ILCE,ADRES,GOREV) " +
                "Values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", maskedTxtTelefon.Text);
            komut.Parameters.AddWithValue("@p4", maskedTxtTCNo.Text);
            komut.Parameters.AddWithValue("@p5", TxtMail.Text);
            komut.Parameters.AddWithValue("@p6", comboBoxIl.Text);
            komut.Parameters.AddWithValue("@p7", comboBoxIlce.Text);
            komut.Parameters.AddWithValue("@p8", richTxtAdres.Text);
            komut.Parameters.AddWithValue("@p9", TxtGorev.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel Ekleme İşlemi Başarıyla Gerçekleştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            personelListesi();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            DialogResult onay = new DialogResult();
            onay = MessageBox.Show("Personeli Gerçekten Silmek İstiyor Musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (onay == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("Delete From TblPersoneller Where ID=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtID.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Personel Silme İşlemi Başarıyla Gerçekleştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                personelListesi();
            }
            else
            {
                MessageBox.Show("Personel Silme İşlemi İptal Edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TblPersoneller set AD=@p1,SOYAD=@p2,TELEFON=@p3,TC=@p4," +
                "MAIL=@p5,IL=@p6,ILCE=@p7,ADRES=@p8,GOREV=@p9 Where ID=@P10", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", maskedTxtTelefon.Text);
            komut.Parameters.AddWithValue("@p4", maskedTxtTCNo.Text);
            komut.Parameters.AddWithValue("@p5", TxtMail.Text);
            komut.Parameters.AddWithValue("@p6", comboBoxIl.Text);
            komut.Parameters.AddWithValue("@p7", comboBoxIlce.Text);
            komut.Parameters.AddWithValue("@p8", richTxtAdres.Text);
            komut.Parameters.AddWithValue("@p9", TxtGorev.Text);
            komut.Parameters.AddWithValue("@P10", TxtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel Güncelleme İşlemi Başarıyla Gerçekleştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            personelListesi();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            TxtID.Text = dr["ID"].ToString();
            TxtAd.Text = dr["AD"].ToString();
            TxtSoyad.Text = dr["SOYAD"].ToString();
            maskedTxtTelefon.Text = dr["TELEFON"].ToString();
            maskedTxtTCNo.Text = dr["TC"].ToString();
            TxtMail.Text = dr["MAIL"].ToString();
            comboBoxIl.Text = dr["IL"].ToString();
            comboBoxIlce.Text = dr["ILCE"].ToString();
            richTxtAdres.Text = dr["ADRES"].ToString();
            TxtGorev.Text = dr["GOREV"].ToString();
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
    }
}
