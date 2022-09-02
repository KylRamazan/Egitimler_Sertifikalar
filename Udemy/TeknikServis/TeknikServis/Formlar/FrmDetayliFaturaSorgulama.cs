using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.Formlar
{
    public partial class FrmDetayliFaturaSorgulama : Form
    {
        public FrmDetayliFaturaSorgulama()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void BtnAra_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(TxtFaturaID.Text);
                var degerler = (from d in db.TblFaturaDetay
                                select new
                                {
                                    d.FATURADETAYID,
                                    d.URUN,
                                    d.ADET,
                                    d.FIYAT,
                                    d.TUTAR,
                                    d.FATURAID
                                }).Where(x => x.FATURAID == id);
                gridControl1.DataSource = degerler.ToList();
        }
    }
}
