using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberiUygulamasi_Console
{
  public class NumaraEkleme
  {
    public void NumaraKaydet(List<Kisi> Rehber)
    {
      Kisi yeniKisi = new Kisi();
      Console.WriteLine("Lütfen İsim Giriniz:");
      yeniKisi.Ad = Console.ReadLine();
      Console.WriteLine("Lütfen Soyisim Giriniz:");
      yeniKisi.Soyad = Console.ReadLine();
      Console.WriteLine("Lütfen Telefon Numarası Giriniz:");
      yeniKisi.TelefonNo = Console.ReadLine();

      Rehber.Add(yeniKisi);

      Console.WriteLine("Numara Başarıyla Kaydedilmiştir.");
    }
  }
}
