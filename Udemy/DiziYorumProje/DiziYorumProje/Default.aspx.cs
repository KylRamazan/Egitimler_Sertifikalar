using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiziYorumProje.Entity;

namespace DiziYorumProje
{
    public partial class Default : System.Web.UI.Page
    {
        BlogDiziDBEntities db = new BlogDiziDBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            var bloglar =db.TblBlog.ToList();
            Repeater1.DataSource =bloglar;
            Repeater1.DataBind();

            var bloglar2 = db.TblKategori.ToList();
            Repeater2.DataSource = bloglar2;
            Repeater2.DataBind();

            var bloglar3 = db.TblBlog.OrderByDescending(x => x.BLOGID).Take(5).ToList();
            Repeater3.DataSource = bloglar3;
            Repeater3.DataBind();


            var bloglar4 = db.TblYorum.OrderByDescending(x => x.YORUMID).Take(5).ToList();
            Repeater4.DataSource = bloglar4;
            Repeater4.DataBind();
        }
    }
}