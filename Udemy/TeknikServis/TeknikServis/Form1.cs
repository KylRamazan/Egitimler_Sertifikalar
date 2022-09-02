using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeknikServis.Formlar;

namespace TeknikServis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Formlar.FrmUrunListesi fr3;
        private void BtnUrunListesiFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr3 == null || fr3.IsDisposed)
            {
                fr3 = new Formlar.FrmUrunListesi();
                fr3.MdiParent = this;
                fr3.Show();
            }
        }

        Formlar.FrmYeniUrun fr10;
        private void BtnYeniUrun_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr10 == null || fr10.IsDisposed)
            {
                fr10 = new Formlar.FrmYeniUrun();
                fr10.Show();
            }
        }

        Formlar.FrmKategori fr2;
        private void BtnKategoriListe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(fr2 ==null || fr2.IsDisposed)
            {
                fr2= new Formlar.FrmKategori();
                fr2.MdiParent = this;
                fr2.Show();
            }
        }

        Formlar.FrmYeniKategori fr9;
        private void BtnYeniKategori_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(fr9==null || fr9.IsDisposed)
            {
                fr9 = new Formlar.FrmYeniKategori();
                fr9.Show();
            }
        }

        Formlar.FrmIstatistik fr4;
        private void BtnIstatistik_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(fr4 == null || fr4.IsDisposed)
            {
                fr4 = new Formlar.FrmIstatistik();
                fr4.MdiParent = this;
                fr4.Show();
            }
        }

        Formlar.FrmMarkalar fr5;
        private void BtnMarkaIst_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr5 == null || fr5.IsDisposed)
            {
                fr5 = new Formlar.FrmMarkalar();
                fr5.MdiParent = this;
                fr5.Show();
            }
        }

        Formlar.FrmCariListesi fr14;
        private void BtnCariListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr14 == null || fr14.IsDisposed)
            {
                fr14 = new Formlar.FrmCariListesi();
                fr14.MdiParent = this;
                fr14.Show();
            }
        }

        Formlar.FrmCari_iller fr15;
        private void BtnCariIller_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr15 == null || fr15.IsDisposed)
            {
                fr15 = new Formlar.FrmCari_iller();
                fr15.MdiParent = this;
                fr15.Show();
            }
        }

        Formlar.FrmCariEkle fr13;
        private void BtnCariEkle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr13 == null || fr13.IsDisposed)
            {
                fr13 = new Formlar.FrmCariEkle();
                fr13.Show();
            }
        }

        Formlar.FrmDepartman fr22;
        private void BtnDepartmanListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr22 == null || fr22.IsDisposed)
            {
                fr22 = new Formlar.FrmDepartman();
                fr22.MdiParent = this;
                fr22.Show();
            }
        }

        Formlar.FrmYeniDepartman fr23;
        private void BtnYeniDepartman_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr23 == null || fr23.IsDisposed)
            {
                fr23 = new Formlar.FrmYeniDepartman();
                fr23.Show();
            }
        }

        Formlar.FrmPersonel fr21;
        private void BtnPersonelListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr21 == null || fr21.IsDisposed)
            {
                fr21 = new Formlar.FrmPersonel();
                fr21.MdiParent = this;
                fr21.Show();
            }
        }

        private void BtnHesapMakinesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }

        Formlar.FrmKurlar fr25;
        private void BtnKurlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr25 == null || fr25.IsDisposed)
            {
                fr25 = new Formlar.FrmKurlar();
                fr25.MdiParent = this;
                fr25.Show();
            }
        }

        private void BtnWord_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("winword");
        }

        private void BtnExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("excel");
        }

        Formlar.FrmYoutube fr26;
        private void BtnYoutube_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr26 == null || fr26.IsDisposed)
            {
                fr26 = new Formlar.FrmYoutube();
                fr26.MdiParent = this;
                fr26.Show();
            }
        }

        Formlar.FrmNotlar fr24;
        private void BtnNotListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr24 == null || fr24.IsDisposed)
            {
                fr24= new Formlar.FrmNotlar();
                fr24.MdiParent = this;
                fr24.Show();
            }
        }

        Formlar.FrmArizaListesi fr6;
        private void BtnArizaliUrunListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr6 == null || fr6.IsDisposed)
            {
                fr6 = new Formlar.FrmArizaListesi();
                fr6.MdiParent = this;
                fr6.Show();
            }
        }

        Formlar.FrmUrunSatis fr16;
        private void BtnUrunSatis_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr16 == null || fr16.IsDisposed)
            {
                fr16 = new Formlar.FrmUrunSatis();
                fr16.Show();
            }
        }

        Formlar.FrmSatisListesi fr17;
        private void BtnSatisListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr17 == null || fr17.IsDisposed)
            {
                fr17 = new Formlar.FrmSatisListesi();
                fr17.MdiParent = this;
                fr17.Show();
            }
        }

        Formlar.FrmArizaliUrunKaydi fr11;
        private void BtnYeniArizaliUrunKaydi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr11 == null || fr11.IsDisposed)
            {
                fr11 = new Formlar.FrmArizaliUrunKaydi();
                fr11.Show();
            }
        }

        Formlar.FrmArizaliUrunAciklama fr12;
        private void BtnArizaliUrunAciklama_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr12 == null || fr12.IsDisposed)
            {
                fr12 = new Formlar.FrmArizaliUrunAciklama();
                fr12.Show();
            }
        }

        Formlar.FrmArizaliUrunAciklamaListesi fr7;
        private void BtnArizaliUrunAciklamaListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr7 == null || fr7.IsDisposed)
            {
                fr7 = new Formlar.FrmArizaliUrunAciklamaListesi();
                fr7.MdiParent = this;
                fr7.Show();
            }
        }

        Formlar.FrmQRCodeOlustur fr8;
        private void BtnQRCodeOlustur_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(fr8==null || fr8.IsDisposed)
            {
                fr8 = new Formlar.FrmQRCodeOlustur();
                fr8.Show();
            }
        }

        Formlar.FrmFaturaListesi fr18;
        private void BtnFaturaListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr18 == null || fr18.IsDisposed)
            {
                fr18 = new Formlar.FrmFaturaListesi();
                fr18.MdiParent = this;
                fr18.Show();
            }
        }

        Formlar.FrmFaturaKalem fr19;
        private void BtnFaturaKalemGiris_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr19 == null || fr19.IsDisposed)
            {
                fr19 = new Formlar.FrmFaturaKalem();
                fr19.MdiParent = this;
                fr19.Show();
            }
        }

        Formlar.FrmDetayliFaturaSorgulama fr20;
        private void BtnDetayliFaturaSorgulama_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr20 == null || fr20.IsDisposed)
            {
                fr20 = new Formlar.FrmDetayliFaturaSorgulama();
                fr20.MdiParent = this;
                fr20.Show();
            }
        }

        Formlar.FrmGauge fr27;
        private void BtnHakkimizda_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr27 == null || fr27.IsDisposed)
            {
                fr27 = new Formlar.FrmGauge();
                fr27.MdiParent = this;
                fr27.Show();
            }
        }

        Formlar.FrmHarita fr28;
        private void BtnHaritalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr28 == null || fr28.IsDisposed)
            {
                fr28 = new Formlar.FrmHarita();
                fr28.MdiParent = this;
                fr28.Show();
            }
        }

        private void BtnRaporSihirbazi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmRapor fr = new Formlar.FrmRapor();
            fr.Show();
        }

        Formlar.FrmAnasayfa fr;
        private void BtnAnaSayfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(fr==null || fr.IsDisposed)
            {
                fr = new Formlar.FrmAnasayfa();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (fr == null)
            {
                fr = new Formlar.FrmAnasayfa();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void BtnBarkodOlustur_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        Formlar.FrmRehber fr29;
        private void BtnRehber_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr29 == null || fr29.IsDisposed)
            {
                fr29 = new Formlar.FrmRehber();
                fr29.MdiParent = this;
                fr29.Show();
            }
        }

        Formlar.FrmGelenMesajlar fr30;
        private void BtnGelenMesajlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr30 == null || fr30.IsDisposed)
            {
                fr30 = new Formlar.FrmGelenMesajlar();
                fr30.MdiParent = this;
                fr30.Show();
            }
        }

        Formlar.FrmMail fr31;
        private void BtnMail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr31 == null || fr31.IsDisposed)
            {
                fr31 = new Formlar.FrmMail();
                fr31.Show();
            }
        }
    }
}

