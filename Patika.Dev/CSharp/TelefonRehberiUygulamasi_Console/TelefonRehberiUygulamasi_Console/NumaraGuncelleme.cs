using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberiUygulamasi_Console
{
  public class NumaraGuncelleme
  {
    public NumaraGuncelleme()
    {
    }

    public void NumaraGuncelle(List<Kisi> Rehber)
    {
    git:
      Console.WriteLine("Lütfen Numarasını Güncellemek İstediğiniz Kişinin Adını Ya Da Soyadını Giriniz:");
      var AdSoyad = Console.ReadLine();
      int rehberSayisi = Rehber.Count();

      foreach (var item in Rehber)
      {
        if (item.Ad == AdSoyad || item.Soyad == AdSoyad)
        {
        onay:
          Console.WriteLine("Yeni Numarayı Giriniz:");
          string yeniNumara = Console.ReadLine();
          int index = Rehber.IndexOf(item);
          Console.WriteLine("{0} Numarayı {1} Numarası İle Güncellemek Üzeresiniz, Onaylıyor Musunuz? (Y/N):", item.TelefonNo, yeniNumara);
          char islem = char.Parse(Console.ReadLine());

          if ('Y' == islem)
          {
            item.TelefonNo = yeniNumara;
            Rehber[index] = item;
            Console.WriteLine("Güncelleme İşlemi Başarıyla Gerçekleşti.");
          }
          else if ('N' == islem)
          {
            Console.WriteLine("Güncelleme İşlemi İptal Edildi!");
          }
          else
          {
            Console.WriteLine("Lütfen Listede Bulunan İşlemlerden Bir Tanesini Seçiniz!");
            goto onay;
          }
        }
      }

      if (rehberSayisi == Rehber.Count())
      {
        Console.WriteLine("Aradığınız Krtiterlere Uygun Veri Rehberde Bulunamadı! Lütfen Başka Bir Seçim Yapınız.");
        Console.WriteLine("* Güncellemeyi Sonlandırmak İçin : (1)");
        Console.WriteLine("* Yeniden Denemek İçin : (2)");
      cikisListesi:
        char islem = char.Parse(Console.ReadLine());
        if ('1' == islem)
        {
          IslemlerListesi islemlerListesi = new IslemlerListesi();
          islemlerListesi.Islemler(Rehber);
        }

        else if ('2' == islem)
        {
          goto git;
        }
        else
        {
          Console.WriteLine("Lütfen Listede Bulunan İşlemlerden Bir Tanesini Seçiniz!");
          goto cikisListesi;
        }
      }

    }
  }
}
