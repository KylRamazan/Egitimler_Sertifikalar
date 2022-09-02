using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiziYorumProje.Entity;

namespace DiziYorumProje.AdminSayfalar
{
    public partial class Istatistik : System.Web.UI.Page
    {
        BlogDiziDBEntities db = new BlogDiziDBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text =db.TblBlog.Count().ToString();
            Label2.Text = db.TblYorum.Count().ToString();
            Label3.Text = db.TblBlog.Where(x=>x.BLOGTUR==2).Count().ToString();
            Label4.Text = db.TblBlog.Where(x=>x.TblTur.BLOGAD=="Dizi").Count().ToString();
            Label5.Text = db.TblBlog.Where(x=>x.TblTur.BLOGAD=="Animasyon").Count().ToString();
            Label6.Text = db.TblBlog.Where(y=>y.BLOGID==(db.TblYorum.GroupBy(x=>x.YORUMBLOG).
            OrderByDescending(x=>x.Count()).Select(z=>z.Key).FirstOrDefault())).Select(k=>k.BLOGBASLIK).FirstOrDefault();
        }
    }
}