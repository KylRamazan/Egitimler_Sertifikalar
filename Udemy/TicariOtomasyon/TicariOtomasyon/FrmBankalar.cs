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
    public partial class FrmBankalar : Form
    {
        public FrmBankalar()
        {
            InitializeComponent();
        }

        sqlBaglantisi bgl = new sqlBaglantisi();

        void bankaListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Execute bankaBilgileri", bgl.baglanti());
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

        void temizle()
        {
            TxtID.Text = "";
            TxtBankaAdi.Text = "";
            comboBoxIl.Text = "";
            comboBoxIlce.Text = "";
            TxtSube.Text = "";
            TxtIban.Text = "";
            TxtHesapNo.Text = "";
            TxtYetkili.Text = "";
            maskedTxtTelefon.Text = "";
            maskedTxtTarih.Text = "";
            TxtHesapTuru.Text = "";
            lookUpEditFirma.Text= "";
        }

        private void FrmBankalar_Load(object sender, EventArgs e)
        {
            bankaListesi();
            firmaListesi();
            sehirListesi();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Insert into TblBankalar (BANKAAD,IL,ILCE,SUBE,IBAN,HESAPNO,YETKILI,TELEFON,TARIH," +
                "HESAPTURU,FIRMAID) Values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtBankaAdi.Text);
            komut.Parameters.AddWithValue("@p2", comboBoxIl.Text);
            komut.Parameters.AddWithValue("@p3", comboBoxIlce.Text);
            komut.Parameters.AddWithValue("@p4", TxtSube.Text);
            komut.Parameters.AddWithValue("@p5", TxtIban.Text);
            komut.Parameters.AddWithValue("@p6", TxtHesapNo.Text);
            komut.Parameters.AddWithValue("@p7", TxtYetkili.Text);
            komut.Parameters.AddWithValue("@p8", maskedTxtTelefon.Text);
            komut.Parameters.AddWithValue("@p9", maskedTxtTarih.Text);
            komut.Parameters.AddWithValue("@p10", TxtHesapTuru.Text);
            komut.Parameters.AddWithValue("@p11", lookUpEditFirma.EditValue);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Banka Ekleme İşlemi Başarıyla Gerçekleştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            bankaListesi();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            DialogResult onay = new DialogResult();
            onay = MessageBox.Show("Bankayı Gerçekten Silmek İstiyor Musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (onay == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("Delete From TblBankalar Where ID=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtID.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Banka Silme İşlemi Başarıyla Gerçekleştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                bankaListesi();
            }
            else
            {
                MessageBox.Show("Banka Silme İşlemi İptal Edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TblBankalar set BANKAAD=@p1,IL=@p2,ILCE=@p3,SUBE=@p4,IBAN=@p5,HESAPNO=@p6," +
                "YETKILI=@p7,TELEFON=@p8,TARIH=@p9,HESAPTURU=@p10,FIRMAID=@p11 Where ID=@P12", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtBankaAdi.Text);
            komut.Parameters.AddWithValue("@p2", comboBoxIl.Text);
            komut.Parameters.AddWithValue("@p3", comboBoxIlce.Text);
            komut.Parameters.AddWithValue("@p4", TxtSube.Text);
            komut.Parameters.AddWithValue("@p5", TxtIban.Text);
            komut.Parameters.AddWithValue("@p6", TxtHesapNo.Text);
            komut.Parameters.AddWithValue("@p7", TxtYetkili.Text);
            komut.Parameters.AddWithValue("@p8", maskedTxtTelefon.Text);
            komut.Parameters.AddWithValue("@p9", maskedTxtTarih.Text);
            komut.Parameters.AddWithValue("@p10", TxtHesapTuru.Text);
            komut.Parameters.AddWithValue("@p11", lookUpEditFirma.EditValue);
            komut.Parameters.AddWithValue("@p12", TxtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Banka Güncelleme İşlemi Başarıyla Gerçekleştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            bankaListesi();
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
            TxtBankaAdi.Text = dr["BANKAAD"].ToString();
            comboBoxIl.Text = dr["IL"].ToString();
            comboBoxIlce.Text = dr["ILCE"].ToString();
            TxtSube.Text = dr["SUBE"].ToString();
            TxtIban.Text = dr["IBAN"].ToString();
            TxtHesapNo.Text = dr["HESAPNO"].ToString();
            TxtYetkili.Text = dr["YETKILI"].ToString();
            maskedTxtTelefon.Text = dr["TELEFON"].ToString();
            maskedTxtTarih.Text = dr["TARIH"].ToString();
            TxtHesapTuru.Text = dr["HESAPTURU"].ToString();
            lookUpEditFirma.Text = dr["AD"].ToString();
        }
    }
}
