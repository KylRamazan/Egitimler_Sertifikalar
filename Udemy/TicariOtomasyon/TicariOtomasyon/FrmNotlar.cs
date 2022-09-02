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
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }

        sqlBaglantisi bgl = new sqlBaglantisi();
        void notListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TblNotlar", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void temizle()
        {
            TxtID.Text = "";
            maskedTxtTarih.Text = "";
            maskedTxtSaat.Text = "";
            TxtBaslik.Text = "";
            TxtOlusturan.Text = "";
            TxtHitap.Text = "";
            richTxtDetay.Text = "";
        }

        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            notListesi();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Insert into TblNotlar (TARIH,SAAT,BASLIK,OLUSTURAN,HITAP,DETAY) " +
                "Values(@p1,@p2,@p3,@p4,@p5,@p6)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", maskedTxtTarih.Text);
            komut.Parameters.AddWithValue("@p2", maskedTxtSaat.Text);
            komut.Parameters.AddWithValue("@p3", TxtBaslik.Text);
            komut.Parameters.AddWithValue("@p4", TxtOlusturan.Text);
            komut.Parameters.AddWithValue("@p5", TxtHitap.Text);
            komut.Parameters.AddWithValue("@p6", richTxtDetay.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Not Ekleme İşlemi Başarıyla Gerçekleştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            notListesi();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            DialogResult onay = new DialogResult();
            onay = MessageBox.Show("Notu Gerçekten Silmek İstiyor Musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (onay == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("Delete From TblNotlar Where ID=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtID.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Not Silme İşlemi Başarıyla Gerçekleştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                notListesi();
            }
            else
            {
                MessageBox.Show("Not Silme İşlemi İptal Edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TblNotlar set TARIH=@p1,SAAT=@p2,BASLIK=@p3,OLUSTURAN=@p4,HITAP=@p5," +
                "DETAY=@p6 Where ID=@p7", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", maskedTxtTarih.Text);
            komut.Parameters.AddWithValue("@p2", maskedTxtSaat.Text);
            komut.Parameters.AddWithValue("@p3", TxtBaslik.Text);
            komut.Parameters.AddWithValue("@p4", TxtOlusturan.Text);
            komut.Parameters.AddWithValue("@p5", TxtHitap.Text);
            komut.Parameters.AddWithValue("@p6", richTxtDetay.Text);
            komut.Parameters.AddWithValue("@p7", TxtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Not Güncelleme İşlemi Başarıyla Gerçekleştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            notListesi();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            TxtID.Text = dr["ID"].ToString();
            maskedTxtTarih.Text = dr["TARIH"].ToString();
            maskedTxtSaat.Text = dr["SAAT"].ToString();
            TxtBaslik.Text = dr["BASLIK"].ToString();
            TxtOlusturan.Text = dr["OLUSTURAN"].ToString();
            TxtHitap.Text = dr["HITAP"].ToString();
            richTxtDetay.Text = dr["DETAY"].ToString();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmNotlarDetay fr = new FrmNotlarDetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                fr.metin = dr["DETAY"].ToString();
                fr.Show();
            }
        }
    }
}
