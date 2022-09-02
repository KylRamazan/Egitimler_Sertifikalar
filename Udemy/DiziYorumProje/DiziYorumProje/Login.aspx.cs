using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiziYorumProje.Entity;

namespace DiziYorumProje
{
    public partial class Login : System.Web.UI.Page
    {
        BlogDiziDBEntities db = new BlogDiziDBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnGirisYap_Click(object sender, EventArgs e)
        {
            var sorgu = (from x in db.TblAdmin
                         where x.KULLANICI == TxtKullaniciAdi.Text && x.SIFRE == TxtSifre.Text
                         select x);
            if(sorgu.Any())
            {
                Session.Add("KULLANICI",TxtKullaniciAdi.Text);
                Response.Redirect("/AdminSayfalar/Bloglar.aspx");
            }
            else
            {
                Response.Write("Hata");
            }
        }
    }
}