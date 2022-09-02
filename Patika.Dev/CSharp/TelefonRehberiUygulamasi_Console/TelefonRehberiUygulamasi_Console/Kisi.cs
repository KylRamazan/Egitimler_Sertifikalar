using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberiUygulamasi_Console
{
  public class Kisi
  {
    private string ad, soyad, telefonNo;

    public Kisi(string Ad, string Soyad, string TelefonNo)
    {
      this.ad = Ad;
      this.soyad = Soyad;
      this.telefonNo = TelefonNo;
    }

    public Kisi()
    { }

    public string Ad {
      get { return ad; }
      set { ad = value; }
    }

    public string Soyad
    {
      get { return soyad; }
      set { soyad = value; }
    }

    public string TelefonNo
    {
      get { return telefonNo; }
      set { telefonNo = value; }
    }
  }
}
