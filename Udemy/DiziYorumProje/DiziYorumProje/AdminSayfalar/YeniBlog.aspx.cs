using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiziYorumProje.Entity;

namespace DiziYorumProje.AdminSayfalar
{
    public partial class YeniBlog : System.Web.UI.Page
    {
        BlogDiziDBEntities db = new BlogDiziDBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack==false)
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
            }
        }

        protected void BtnKaydet_Click(object sender, EventArgs e)
        {
            TblBlog t = new TblBlog();
            t.BLOGBASLIK = TxtBaslik.Text;
            t.BLOGGORSEL = TxtGorsel.Text;
            t.BLOGICERIK = TxtIcerik.Text;
            t.BLOGTARIH = DateTime.Parse(TxtTarih.Text);
            t.BLOGTUR = byte.Parse(DropDownList1.SelectedValue);
            t.BLOGKATEGORI = byte.Parse(DropDownList2.SelectedValue);
            db.TblBlog.Add(t);
            db.SaveChanges();
            Response.Redirect("Bloglar.aspx");
        }
    }
}