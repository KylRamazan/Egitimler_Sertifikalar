using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberiUygulamasi_Console
{
  class Program
  {
    static void Main(string[] args)
    {
      List<Kisi> Rehber = new List<Kisi>();

      Kisi Kisi1 = new Kisi("Ali", "Gel", "05301112233");
      Rehber.Add(Kisi1);

      Kisi Kisi2 = new Kisi("Ayşe", "Gül", "05301114455");
      Rehber.Add(Kisi2);

      Kisi Kisi3 = new Kisi("Mehmet", "Kara", "05301116677");
      Rehber.Add(Kisi3);

      Kisi Kisi4 = new Kisi("Aylin", "Aysu", "05301118899");
      Rehber.Add(Kisi4);

      Kisi Kisi5 = new Kisi("Meltem", "Beyaz", "05301119900");
      Rehber.Add(Kisi5);

      IslemlerListesi islemlerListesi = new IslemlerListesi();
      islemlerListesi.Islemler(Rehber);

      Console.ReadKey();
    }
  }
}
