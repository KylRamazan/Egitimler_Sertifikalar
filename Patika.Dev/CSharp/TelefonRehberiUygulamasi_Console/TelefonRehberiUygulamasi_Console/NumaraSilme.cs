using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberiUygulamasi_Console
{
  public class NumaraSilme
  {
    public NumaraSilme()
    {
    }

    public void NumaraSil(List<Kisi> Rehber)
    {
      git:
      Console.WriteLine("Lütfen Numarasını Silmek İstediğiniz Kişinin Adını Ya Da Soyadını Giriniz:");
      string AdSoyad = Console.ReadLine();
      int rehberSayisi = Rehber.Count();
      foreach (var item in Rehber)
      {
        if (item.Ad == AdSoyad || item.Soyad == AdSoyad)
        {
          onay:
          Console.WriteLine("{0} {1} {2} Rehberden Silinmek Üzere, Onaylıyor Musunuz? (Y/N):",item.Ad,item.Soyad,item.TelefonNo);
          char islem = char.Parse(Console.ReadLine());
          if ('Y' == islem)
          {
            Rehber.Remove(item);
            Console.WriteLine("Silme İşlemi Başarıyla Gerçekleşti.");
            break;
          }
          else if ('N' == islem)
          {
            Console.WriteLine("Rehberden Silme İşlemi İptal Edildi!");
            // Buraya cozum bulunacak!
            break;
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
        Console.WriteLine("* Silmeyi Sonlandırmak İçin : (1)");
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
