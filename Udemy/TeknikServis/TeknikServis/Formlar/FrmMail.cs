using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using DevExpress.XtraGauges.Win.Gauges.Circular;

namespace TeknikServis.Formlar
{
    public partial class FrmMail : Form
    {
        public FrmMail()
        {
            InitializeComponent();
        }

        private void pictureEdit14_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtKonu_Click(object sender, EventArgs e)
        {
            TxtKonu.Text = "";
            TxtKonu.Focus();
        }

        private void TxtIcerik_Click(object sender, EventArgs e)
        {
            TxtIcerik.Text = "";
            TxtIcerik.Focus();
        }

        private void BtnGonder_Click(object sender, EventArgs e)
        {
            MailMessage mail = new MailMessage();
            string fromMail = "ramazan171214@hotmail.com";
            string sifre ="56745RYk-";
            string aliciMail = TxtAlici.Text;
            string konu = TxtKonu.Text;
            string icerik = TxtIcerik.Text;

            mail.From =new MailAddress(fromMail);
            mail.To.Add(aliciMail);
            mail.Subject =konu;
            mail.Body = icerik;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.live.com",587);
            smtp.Credentials = new NetworkCredential(fromMail,sifre);
            smtp.EnableSsl = true;
            smtp.Send(mail);
            MessageBox.Show("Mail Gönderme İşlemi Başarıyla Gerçekleştirildi.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void TxtAlici_Click(object sender, EventArgs e)
        {
            TxtAlici.Text = "";
            TxtAlici.Focus();
        }
    }
}
