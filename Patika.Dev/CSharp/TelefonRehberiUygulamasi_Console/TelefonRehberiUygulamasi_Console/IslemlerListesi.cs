using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberiUygulamasi_Console
{
  public class IslemlerListesi
  {
    public void Islemler(List<Kisi> Rehber)
    {
      Console.WriteLine("Lütfen Yapmak İstediğiniz İşlemi Seçiniz:");
      Console.WriteLine("************************************************");
      Console.WriteLine("(1) Yeni Numara Kaydetmek");
      Console.WriteLine("(2) Var Olan Numarayı Silmek");
      Console.WriteLine("(3) Var Olan Numarayı Güncellemek");
      Console.WriteLine("(4) Rehberi Listelemek");
      Console.WriteLine("(5) Rehberde Arama Yapmak");
      git:
      char islem = char.Parse(Console.ReadLine());
      switch (islem)
      {
        case '1':
          NumaraEkleme numaraEkleme = new NumaraEkleme();
          numaraEkleme.NumaraKaydet(Rehber);
          break;
        case '2':
          NumaraSilme numaraSilme = new NumaraSilme();
          numaraSilme.NumaraSil(Rehber);
          break;
        case '3':
          NumaraGuncelleme numaraGuncelleme = new NumaraGuncelleme();
          numaraGuncelleme.NumaraGuncelle(Rehber);
          break;
        case '4':
          RehberListele rehberListele = new RehberListele();
          rehberListele.Listele(Rehber);
          break;
        case '5':
          AramaYap aramaYap = new AramaYap();
          aramaYap.Ara(Rehber);
          break;
        default:
          Console.WriteLine("Lütfen Listede Bulunan İşlemlerden Bir Tanesini Seçiniz!");
          goto git;
      }
    }
  }
}
