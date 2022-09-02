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
    public partial class FrmGiderler : Form
    {
        public FrmGiderler()
        {
            InitializeComponent();
        }

        sqlBaglantisi bgl = new sqlBaglantisi();

        void giderListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TblGiderler", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void temizle()
        {
            TxtID.Text = "";
            comboBoxAy.Text = "";
            comboBoxYil.Text = "";
            TxtElektrik.Text = "";
            TxtSu.Text = "";
            TxtDogalgaz.Text = "";
            TxtInternet.Text = "";
            TxtMutfak.Text = "";
            TxtMaaslar.Text = "";
            TxtEkstra.Text = "";
            richTxtNotlar.Text = "";
        }
        private void FrmGiderler_Load(object sender, EventArgs e)
        {
            giderListesi();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Insert into TblGiderler (AY,YIL,ELEKTRIK,SU,DOGALGAZ,INTERNET,MUTFAK,MAASLAR," +
                "EKSTRA,NOTLAR) Values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", comboBoxAy.Text);
            komut.Parameters.AddWithValue("@p2", comboBoxYil.Text);
            komut.Parameters.AddWithValue("@p3", decimal.Parse(TxtElektrik.Text));
            komut.Parameters.AddWithValue("@p4", decimal.Parse(TxtSu.Text));
            komut.Parameters.AddWithValue("@p5", decimal.Parse(TxtDogalgaz.Text));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(TxtInternet.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(TxtMutfak.Text));
            komut.Parameters.AddWithValue("@p8", decimal.Parse(TxtMaaslar.Text));
            komut.Parameters.AddWithValue("@p9", decimal.Parse(TxtEkstra.Text));
            komut.Parameters.AddWithValue("@p10", richTxtNotlar.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Gider Ekleme İşlemi Başarıyla Gerçekleştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            giderListesi();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            DialogResult onay = new DialogResult();
            onay = MessageBox.Show("Gideri Gerçekten Silmek İstiyor Musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (onay == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("Delete From TblGiderler Where ID=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtID.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Gider Silme İşlemi Başarıyla Gerçekleştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                giderListesi();
            }
            else
            {
                MessageBox.Show("Gider Silme İşlemi İptal Edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TblGiderler set AY=@P1,YIL=@P2,ELEKTRIK=@P3,SU=@P4,DOGALGAZ=@P5,INTERNET=@P6," +
                "MUTFAK=@P7,MAASLAR=@P8,EKSTRA=@P9,NOTLAR=@P10 Where ID=@P11", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", comboBoxAy.Text);
            komut.Parameters.AddWithValue("@p2", comboBoxYil.Text);
            komut.Parameters.AddWithValue("@p3", decimal.Parse(TxtElektrik.Text));
            komut.Parameters.AddWithValue("@p4", decimal.Parse(TxtSu.Text));
            komut.Parameters.AddWithValue("@p5", decimal.Parse(TxtDogalgaz.Text));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(TxtInternet.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(TxtMutfak.Text));
            komut.Parameters.AddWithValue("@p8", decimal.Parse(TxtMaaslar.Text));
            komut.Parameters.AddWithValue("@p9", decimal.Parse(TxtEkstra.Text));
            komut.Parameters.AddWithValue("@p10", richTxtNotlar.Text);
            komut.Parameters.AddWithValue("@P11", TxtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Gider Güncelleme İşlemi Başarıyla Gerçekleştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            giderListesi();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            TxtID.Text = dr["ID"].ToString();
            comboBoxAy.Text = dr["AY"].ToString();
            comboBoxYil.Text = dr["YIL"].ToString();
            TxtElektrik.Text = dr["ELEKTRIK"].ToString();
            TxtSu.Text = dr["SU"].ToString();
            TxtDogalgaz.Text = dr["DOGALGAZ"].ToString();
            TxtInternet.Text = dr["INTERNET"].ToString();
            TxtMutfak.Text = dr["MUTFAK"].ToString();
            TxtMaaslar.Text = dr["MAASLAR"].ToString();
            TxtEkstra.Text = dr["EKSTRA"].ToString();
            richTxtNotlar.Text = dr["NOTLAR"].ToString();
        }
    }
}
