using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev2
{
  class Program
  {
    static void Main(string[] args)
    {
      // 1.Soru
      //asalSayiBul();

      // 2.Soru
      buyukKucukBul();

      // 3.Soru
      //sesliHarfBul();

      Console.ReadKey();
    }

    public static void asalSayiBul()
    {
      ArrayList asalSayilar = new ArrayList();
      ArrayList asalOlmayanSayilar = new ArrayList();
      int sayi = 0;
      int sayac = 0;
      for (int i = 0; i < 20; i++)
      {
        Console.WriteLine((i + 1) + ". Sayıyı Giriniz:");
        sayi = int.Parse(Console.ReadLine());

        for (int x = 2; x < sayi; x++)
        {
          if (sayi % x == 0)
          {
            sayac++;
          }
        }
        if (sayac == 0)
        {
          asalSayilar.Add(sayi);
        }
        else
        {
          asalOlmayanSayilar.Add(sayi);
          sayac = 0;
        }
      }

      asalSayilar.Sort();
      asalOlmayanSayilar.Sort();
      Console.WriteLine("--- Asal Sayılar ---");
      foreach (var item in asalSayilar)
      {
        Console.WriteLine(item);
      }

      Console.WriteLine("--- Asal Olmayan Sayılar ---");
      foreach (var item in asalOlmayanSayilar)
      {
        Console.WriteLine(item);
      }
    }
    public static void buyukKucukBul()
    {
      int[] sayilar = new int[20];
      int[] buyuksayi = new int[3];
      int[] kucuksayi = new int[3];


      for (int i = 0; i < 20; i++)
      {
        Console.Write($"{i + 1}. Sayıyı giriniz:");
        sayilar[i] = Convert.ToInt32(Console.ReadLine());
      }

      Array.Sort(sayilar);
      kucuksayi[0] = sayilar[0];
      kucuksayi[1] = sayilar[1];
      kucuksayi[2] = sayilar[2];
      int topla = 0;
      Console.WriteLine("***** Küçük Sayıların Listesi *****");
      foreach (int sayi in kucuksayi)
      {
        Console.WriteLine(sayi);
        topla = topla + sayi;
      }
      Console.WriteLine($"Küçük sayıların toplamı: {topla}");
      Console.WriteLine($"Küçük sayıların ortalaması: {topla / 3}");


      buyuksayi[0] = sayilar[17];
      buyuksayi[1] = sayilar[18];
      buyuksayi[2] = sayilar[19];
      int topla2 = 0;
      Console.WriteLine("***** Küçük Sayıların Listesi *****");
      foreach (int sayi in buyuksayi)
      {
        Console.WriteLine(sayi);
        topla2 = topla2 + sayi;
      }
      Console.WriteLine($"Büyük sayıların toplamı: {topla2}");
      Console.WriteLine($"Büyük sayıların ortalaması: {topla2 / 3}");
    
    }
    public static void sesliHarfBul()
    {
      Console.WriteLine("Metin Giriniz:");
      string metin = Console.ReadLine();

      var karakterler = metin.ToCharArray();

      char[] harfler = {'a', 'A', 'e', 'E', 'ı', 'I', 'i', 'İ', 'o', 'O', 'ö', 'Ö', 'u', 'U', 'ü', 'Ü' };
      List<char> sesliHarfler = new List<char>();

      foreach (var item in karakterler)
      {
        foreach (var item2 in harfler)
        {
          if (item == item2)
          {
            sesliHarfler.Add(item);
          }
        }
      }

      Console.WriteLine("Sesli Harfler");
      sesliHarfler.Sort();
      foreach (var item in sesliHarfler)
      {
        Console.WriteLine(item);
      }
    }
  }
}
