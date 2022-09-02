using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiziYorumProje.Entity;

namespace DiziYorumProje.AdminSayfalar
{
    public partial class BlogGuncelle : System.Web.UI.Page
    {
        BlogDiziDBEntities db = new BlogDiziDBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            int y =int.Parse(Request.QueryString["BLOGID"]);

            if (Page.IsPostBack == false)
            {
                var turler = (from x in db.TblTur
                              select new
                              {
                                  x.TURID,
                                  x.BLOGAD
                              }).ToList();
                DropDownList1.DataSource = turler;
                DropDownList1.DataBind();

                var kategoriler = (from x in db.TblKategori
                                   select new
                                   {
                                       x.KATEGORIID,
                                       x.KATEGORIAD
                                   }).ToList();
                DropDownList2.DataSource = kategoriler;
                DropDownList2.DataBind();

                var deger = db.TblBlog.Find(y);
                TxtBaslik.Text = deger.BLOGBASLIK;
                TxtTarih.Text = deger.BLOGTARIH.ToString();
                TxtGorsel.Text = deger.BLOGGORSEL;
                TxtIcerik.Text = deger.BLOGICERIK;
                DropDownList1.SelectedValue = deger.BLOGTUR.ToString();
                DropDownList2.SelectedValue = deger.BLOGKATEGORI.ToString();
            }
        }

        protected void BtnGüncelle_Click(object sender, EventArgs e)
        {
            int y = int.Parse(Request.QueryString["BLOGID"]);
            var blog = db.TblBlog.Find(y);
            blog.BLOGBASLIK = TxtBaslik.Text;
            blog.BLOGTARIH = DateTime.Parse(TxtTarih.Text);
            blog.BLOGGORSEL = TxtGorsel.Text;
            blog.BLOGICERIK= TxtIcerik.Text;
            blog.BLOGTUR = Byte.Parse(DropDownList1.SelectedValue);
            blog.BLOGKATEGORI = Byte.Parse(DropDownList2.SelectedValue);
            db.SaveChanges();
            Response.Redirect("Bloglar.aspx");
        }
    }
}