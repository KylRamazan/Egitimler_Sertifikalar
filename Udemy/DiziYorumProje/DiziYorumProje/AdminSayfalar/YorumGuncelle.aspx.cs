using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiziYorumProje.Entity;

namespace DiziYorumProje.AdminSayfalar
{
    public partial class YorumGuncelle : System.Web.UI.Page
    {
        BlogDiziDBEntities db = new BlogDiziDBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            int y = int.Parse(Request.QueryString["YORUMID"]);

            if (Page.IsPostBack == false)
            {
                var deger = db.TblYorum.Find(y);
                TxtBaslik.Text = deger.TblBlog.BLOGBASLIK;
                TxtKullaniciAdi.Text = deger.KISIAD;
                TxtIcerik.Text = deger.YORUMICERIK;
            }
        }

        protected void BtnGüncelle_Click(object sender, EventArgs e)
        {
            int y = int.Parse(Request.QueryString["YORUMID"]);
            var yorum = db.TblYorum.Find(y);
            yorum.KISIAD = TxtKullaniciAdi.Text;
            yorum.YORUMICERIK = TxtIcerik.Text;
            db.SaveChanges();
            Response.Redirect("Yorumlar.aspx");
        }
    }
}