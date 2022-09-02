using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TicariOtomasyon
{
    class sqlBaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan =new SqlConnection(@"Data Source=LAPTOP-29QULOVF;Initial Catalog=DbTicariOtomasyon;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
