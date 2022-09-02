using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiziYorumProje.Entity;

namespace DiziYorumProje
{
    public partial class BlogDetay : System.Web.UI.Page
    {
        BlogDiziDBEntities db = new BlogDiziDBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["BLOGID"]);
            var blog = db.TblBlog.Where(x=>x.BLOGID==id).ToList();
            Repeater1.DataSource =blog;
            Repeater1.DataBind();

            var yorumlar = db.TblYorum.Where(x=>x.YORUMBLOG == id).ToList();
            Repeater2.DataSource = yorumlar;
            Repeater2.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["BLOGID"]);
            TblYorum t = new TblYorum();
            t.KISIAD = TxtKullaniciAdi.Text;
            t.MAIL = TxtMail.Text;
            t.YORUMICERIK = TxtMesaj.Text;
            t.YORUMBLOG = id;
            db.TblYorum.Add(t);
            db.SaveChanges();
            Response.Redirect("BlogDetay.aspx?BLOGID="+id);
        }
    }
}