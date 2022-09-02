using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberiUygulamasi_Console
{
  public class RehberListele
  {
    public RehberListele()
    { }

    public void Listele(List<Kisi> Rehber)
    {
      Console.WriteLine("********** Telefon Rehberi **********");
      foreach (var item in Rehber)
      {
        Console.WriteLine("İsim: {0}\nSoyisim: {1}\nTelefon Numarası: {2}\n-",item.Ad,item.Soyad,item.TelefonNo);
      }
    }
  }
}
