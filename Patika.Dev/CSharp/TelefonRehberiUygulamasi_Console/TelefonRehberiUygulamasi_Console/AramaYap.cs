using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberiUygulamasi_Console
{
  public class AramaYap
  {
    public AramaYap()
    { }

    public void Ara(List<Kisi> Rehber)
    {
      List<Kisi> sonuclar = new List<Kisi>();
      Console.WriteLine("Arama Yapmak İstediğiniz Tipi Seçiniz: ");
      Console.WriteLine("********************************************");
      Console.WriteLine("İsim veya Soyisime Göre Arama Yapmak İçin: (1)");
      Console.WriteLine("Telefon Numarasına Göre Arama Yapmak İçin: (2)");

      if ('1' == char.Parse(Console.ReadLine()))
      {
        Console.WriteLine("Lütfen Aramak İstediğiniz Kişinin Adını Ya Da Soyadını Giriniz:");
        string AdSoyad = Console.ReadLine();

        foreach (var item in Rehber)
        {
          if (item.Ad == AdSoyad || item.Soyad == AdSoyad)
          {
            sonuclar.Add(item);
          }
        }
      }
      else if ('2' == char.Parse(Console.ReadLine()))
      {
        Console.WriteLine("Lütfen Aramak İstediğiniz Kişinin Telefon Numarasını Giriniz:");
        string telefonNo = Console.ReadLine();

        foreach (var item in Rehber)
        {
          if (item.TelefonNo == telefonNo)
          {
            sonuclar.Add(item);
          }
        }
      }
      else
      {
        Console.WriteLine("Lütfen Listede Bulunan İşlemlerden 1 Tanesini Seçiniz:");
      }

      Console.WriteLine("Arama Sonuçlarınız:");
      Console.WriteLine("************************");
      foreach (var item in sonuclar)
      {
        Console.WriteLine("İsim: {0}\nSoyisim: {1}\nTelefon Numarası: {2}\n-", item.Ad, item.Soyad, item.TelefonNo);
      }
    }
  }
}
