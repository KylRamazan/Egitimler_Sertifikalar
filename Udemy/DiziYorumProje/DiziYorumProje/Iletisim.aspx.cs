using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiziYorumProje.Entity;

namespace DiziYorumProje
{
    public partial class Iletisim : System.Web.UI.Page
    {
        BlogDiziDBEntities db = new BlogDiziDBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnGonder_Click(object sender, EventArgs e)
        {
            TblIletisim t = new TblIletisim();
            t.ADSOYAD = TxtAdSoyad.Text;
            t.KONU = TxtKonu.Text;
            t.MAIL = TxtMail.Text;
            t.TELEFON = TxtTelefon.Text;
            t.MESAJ = TxtMesaj.Text;
            db.TblIletisim.Add(t);
            db.SaveChanges();
        }
    }
}