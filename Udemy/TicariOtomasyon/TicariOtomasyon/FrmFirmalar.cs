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
    public partial class FrmFirmalar : Form
    {
        public FrmFirmalar()
        {
            InitializeComponent();
        }

        sqlBaglantisi bgl = new sqlBaglantisi();

        void firmaListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TblFirmalar", bgl.baglanti());
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
            TxtYetkiliGorev.Text = "";
            TxtYetkiliAd.Text = "";
            maskedTxtYetkiliTCNo.Text = "";
            TxtSektor.Text = "";
            maskedTxtTelefon.Text = "";
            maskedTxtTelefon2.Text = "";
            maskedTxtTelefon3.Text = "";
            maskedTxtFax.Text = "";
            TxtMail.Text = "";
            comboBoxIl.Text = "";
            comboBoxIlce.Text = "";
            richTxtAdres.Text = "";
            TxtVergiDairesi.Text = "";
            richTxtKod1.Text = "";
            richTxtKod2.Text = "";
            richTxtKod3.Text = "";
        }

        void cariKodAciklamalar()
        {
            SqlCommand komut = new SqlCommand("Select FIRMAKOD1 From TblKodlar", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                richTxtKod1.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();
        }

        private void FrmFirmalar_Load(object sender, EventArgs e)
        {
            firmaListesi();
            sehirListesi();
            cariKodAciklamalar();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Insert into TblFirmalar (AD,YETKILISTATU,YETKILIADSOYAD,YETKILITC,SEKTOR," +
                "TELEFON ,TELEFON2,TELEFON3,MAIL,FAX,IL,ILCE,VERGIDAIRE,ADRES,OZELKOD1,OZELKOD2,OZELKOD3) " +
                "Values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtYetkiliGorev.Text);
            komut.Parameters.AddWithValue("@p3", TxtYetkiliAd.Text);
            komut.Parameters.AddWithValue("@p4", maskedTxtYetkiliTCNo.Text);
            komut.Parameters.AddWithValue("@p5", TxtSektor.Text);
            komut.Parameters.AddWithValue("@p6", maskedTxtTelefon.Text);
            komut.Parameters.AddWithValue("@p7", maskedTxtTelefon2.Text);
            komut.Parameters.AddWithValue("@p8", maskedTxtTelefon3.Text);
            komut.Parameters.AddWithValue("@p9", TxtMail.Text);
            komut.Parameters.AddWithValue("@p10", maskedTxtFax.Text);
            komut.Parameters.AddWithValue("@p11", comboBoxIl.Text);
            komut.Parameters.AddWithValue("@p12", comboBoxIlce.Text);
            komut.Parameters.AddWithValue("@p13", TxtVergiDairesi.Text);
            komut.Parameters.AddWithValue("@p14", richTxtAdres.Text);
            komut.Parameters.AddWithValue("@p15", richTxtKod1.Text);
            komut.Parameters.AddWithValue("@p16", richTxtKod2.Text);
            komut.Parameters.AddWithValue("@p17", richTxtKod3.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Firma Ekleme İşlemi Başarıyla Gerçekleştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            firmaListesi();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            DialogResult onay = new DialogResult();
            onay = MessageBox.Show("Firmayı Gerçekten Silmek İstiyor Musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (onay == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("Delete From TblFirmalar Where ID=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtID.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Firma Silme İşlemi Başarıyla Gerçekleştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                firmaListesi();
            }
            else
            {
                MessageBox.Show("Firma Silme İşlemi İptal Edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TblFirmalar set AD=@p1,YETKILISTATU=@p2,YETKILIADSOYAD=@p3,YETKILITC=@p4," +
                "SEKTOR=@p5,TELEFON=@p6 ,TELEFON2=@p7,TELEFON3=@p8,MAIL=@p9,FAX=@p10,IL=@p11,ILCE=@p12,VERGIDAIRE=@p13,ADRES=@p14," +
                "OZELKOD1=@p15,OZELKOD2=@p16,OZELKOD3=@p17 Where ID=@P18", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtYetkiliGorev.Text);
            komut.Parameters.AddWithValue("@p3", TxtYetkiliAd.Text);
            komut.Parameters.AddWithValue("@p4", maskedTxtYetkiliTCNo.Text);
            komut.Parameters.AddWithValue("@p5", TxtSektor.Text);
            komut.Parameters.AddWithValue("@p6", maskedTxtTelefon.Text);
            komut.Parameters.AddWithValue("@p7", maskedTxtTelefon2.Text);
            komut.Parameters.AddWithValue("@p8", maskedTxtTelefon3.Text);
            komut.Parameters.AddWithValue("@p9", TxtMail.Text);
            komut.Parameters.AddWithValue("@p10", maskedTxtFax.Text);
            komut.Parameters.AddWithValue("@p11", comboBoxIl.Text);
            komut.Parameters.AddWithValue("@p12", comboBoxIlce.Text);
            komut.Parameters.AddWithValue("@p13", TxtVergiDairesi.Text);
            komut.Parameters.AddWithValue("@p14", richTxtAdres.Text);
            komut.Parameters.AddWithValue("@p15", richTxtKod1.Text);
            komut.Parameters.AddWithValue("@p16", richTxtKod2.Text);
            komut.Parameters.AddWithValue("@p17", richTxtKod3.Text);
            komut.Parameters.AddWithValue("@p18", TxtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Firma Güncelleme İşlemi Başarıyla Gerçekleştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            firmaListesi();
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
            TxtYetkiliGorev.Text = dr["YETKILISTATU"].ToString();
            TxtYetkiliAd.Text = dr["YETKILIADSOYAD"].ToString();
            maskedTxtYetkiliTCNo.Text = dr["YETKILITC"].ToString();
            TxtSektor.Text = dr["SEKTOR"].ToString();
            maskedTxtTelefon.Text = dr["TELEFON"].ToString();
            maskedTxtTelefon2.Text = dr["TELEFON2"].ToString();
            maskedTxtTelefon3.Text = dr["TELEFON3"].ToString();
            maskedTxtFax.Text = dr["FAX"].ToString();
            TxtMail.Text = dr["MAIL"].ToString();
            comboBoxIl.Text = dr["IL"].ToString();
            comboBoxIlce.Text = dr["ILCE"].ToString();
            richTxtAdres.Text = dr["ADRES"].ToString();
            TxtVergiDairesi.Text = dr["VERGIDAIRE"].ToString();
            richTxtKod1.Text = dr["OZELKOD1"].ToString();
            richTxtKod2.Text = dr["OZELKOD2"].ToString();
            richTxtKod3.Text = dr["OZELKOD3"].ToString();
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
