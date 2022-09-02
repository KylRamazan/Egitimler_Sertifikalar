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
    public partial class FrmArizaliUrunAciklamaListesi : Form
    {
        public FrmArizaliUrunAciklamaListesi()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmArizaliUrunAciklamaListesi_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource =(from x in db.TblUrunTakip
                                     select new
                                     {
                                         x.TAKIPID,
                                         x.SERINO,
                                         x.TARIH,
                                         x.ACIKLAMA
                                     }).ToList();
        }
    }
}
