using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicariOtomasyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string kullanici;
        private void Form1_Load(object sender, EventArgs e)
        {
            if (fr == null || fr.IsDisposed)
            {
                fr = new FrmAnaSayfa();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        FrmAnaSayfa fr;
        private void BtnAnaSayfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr == null || fr.IsDisposed)
            {
                fr = new FrmAnaSayfa();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        FrmUrunler fr2;
        private void BtnUrunler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr2 == null || fr2.IsDisposed)
            {
                fr2 = new FrmUrunler();
                fr2.MdiParent = this;
                fr2.Show();
            }
        }

        FrmStoklar fr3;
        private void BtnStoklar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr3 == null || fr3.IsDisposed)
            {
                fr3 = new FrmStoklar();
                fr3.MdiParent = this;
                fr3.Show();
            }
        }

        FrmMusteriler fr4;
        private void BtnMusteriler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr4 == null || fr4.IsDisposed)
            {
                fr4 = new FrmMusteriler();
                fr4.MdiParent = this;
                fr4.Show();
            }
        }

        FrmFirmalar fr5;
        private void BtnFirmalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr5 == null || fr5.IsDisposed)
            {
                fr5 = new FrmFirmalar();
                fr5.MdiParent = this;
                fr5.Show();
            }
        }

        FrmPersoneller fr6;
        private void BtnPersoneller_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr6 == null || fr6.IsDisposed)
            {
                fr6 = new FrmPersoneller();
                fr6.MdiParent = this;
                fr6.Show();
            }
        }

        FrmGiderler fr7;
        private void BtnGiderler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr7 == null || fr7.IsDisposed)
            {
                fr7 = new FrmGiderler();
                fr7.MdiParent = this;
                fr7.Show();
            }
        }

        FrmKasa fr8;
        private void BtnKasa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr8 == null || fr8.IsDisposed)
            {
                fr8 = new FrmKasa();
                fr8.ad = kullanici;
                fr8.MdiParent = this;
                fr8.Show();
            }
        }

        FrmNotlar fr9;
        private void BtnNotlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr9 == null || fr9.IsDisposed)
            {
                fr9 = new FrmNotlar();
                fr9.MdiParent = this;
                fr9.Show();
            }
        }

        FrmBankalar fr10;
        private void BtnBankalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr10 == null || fr10.IsDisposed)
            {
                fr10 = new FrmBankalar();
                fr10.MdiParent = this;
                fr10.Show();
            }
        }

        FrmRehber fr11;
        private void BtnRehber_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr11 == null || fr11.IsDisposed)
            {
                fr11 = new FrmRehber();
                fr11.MdiParent = this;
                fr11.Show();
            }
        }

        FrmFaturalar fr12;
        private void BtnFaturalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr12 == null || fr12.IsDisposed)
            {
                fr12 = new FrmFaturalar();
                fr12.MdiParent = this;
                fr12.Show();
            }
        }

        FrmHareketler fr13;
        private void BtnHareketler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr13 == null || fr13.IsDisposed)
            {
                fr13 = new FrmHareketler();
                fr13.MdiParent = this;
                fr13.Show();
            }
        }

        FrmRaporlar fr14;
        private void BtnRaporlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr14 == null || fr14.IsDisposed)
            {
                fr14 = new FrmRaporlar();
                fr14.MdiParent = this;
                fr14.Show();
            }
        }

        FrmAyarlar fr15;
        private void BtnAyarlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr15 == null || fr15.IsDisposed)
            {
                fr15 = new FrmAyarlar();
                fr15.Show();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
