using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev1
{
  class Program
  {
    static void Main(string[] args)
    {
      //int deger = 2;
      //string degisken = null;
      //string Degisken = null;

      //byte b = 5; // 1 byte
      //sbyte sb = 5; // 1 byte

      //short s = 5; // 2 byte
      //ushort us = 5; // 2 byte

      //Int16 i16 = 2; // 2 byte
      //int i = 2; // 4 byte
      //Int32 i32 = 2; // 4 byte
      //Int64 i64 = 2; // 8 byte
      //uint ui = 2; // 4 byte

      //long l = 4; // 8 byte
      //ulong ul = 4; // 8 yte

      //float f = 5; // 4 byte
      //double d = 5; // 8 byte
      //decimal dec = 5; // 16 byte

      //char c = '2'; // 2 byte
      //string str = "Deneme"; // sınırsız 

      //bool bo = true;
      //DateTime dt = DateTime.Now;
      //Console.WriteLine(dt);

      //object o1 = "x";
      //object o2 = 'y';
      //object o3 = 4;
      //object o4 = 4.3;

      //string ad = "Deneme";
      //string soyad = "Test";
      //string adSoyad = ad + " " + soyad;

      //int x = 3;
      //int y = 3;

      //y = y + 2;
      //Console.WriteLine(y);

      //y += 2;
      //Console.WriteLine(y);

      //y /= 1;
      //Console.WriteLine(y);

      //x *= 2;
      //Console.WriteLine(x);


      //bool isSucces = true;
      //bool isCompleted = false;

      //if (isSucces && isCompleted)
      //  Console.WriteLine("Perfect!");

      //if (isSucces || isCompleted)
      //  Console.WriteLine("Great!");

      //if (isSucces && !isCompleted)
      //  Console.WriteLine("Fine!");

      //int sayi1 = 3;
      //int sayi2 = 4;
      //bool sonuc = sayi1<sayi2;
      //Console.WriteLine(sonuc);

      //sonuc = sayi1 > sayi2;
      //Console.WriteLine(sonuc);

      //sonuc = sayi1 >= sayi2;
      //Console.WriteLine(sonuc);

      //sonuc = sayi1 <= sayi2;
      //Console.WriteLine(sonuc);

      //sonuc = sayi1 != sayi2;
      //Console.WriteLine(sonuc);


      // 1.Soru
      /*
      git:
      Console.WriteLine("Pozitif Bir Sayı Giriniz:");
      int sayi = Convert.ToInt32(Console.ReadLine());
      int sayi2=0;

      List<int> ciftSayilar = new List<int>();

      if (sayi > 0)
      {
        for (int i = 0; i < sayi; i++)
        {
          Console.WriteLine((i + 1) + ". Sayıyı Giriniz:");
          sayi2 = Convert.ToInt32(Console.ReadLine());

          if (sayi2 % 2 == 0)
          {
            ciftSayilar.Add(sayi2);
          }
        }

        Console.WriteLine("--- Girdiğiniz Sayılardan Çift Olanları ---");
        foreach (var item in ciftSayilar)
        {
          Console.WriteLine(item);
        }
      }else
      {
        goto git;
      }*/

      // 2.Soru

      /*git:
        Console.WriteLine("Pozitif Birinci Sayıyı Giriniz:");
        int sayi1 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Pozitif İkinci Sayıyı Giriniz:");
        int sayi2 = Convert.ToInt32(Console.ReadLine());

        List<int> Sayilar = new List<int>();
        int sayi = 0;

        if (sayi1 > 0 && sayi2 > 0)
        {
          for (int i = 0; i < sayi1; i++)
          {
            Console.WriteLine((i + 1) + ". Sayıyı Giriniz:");
            sayi = Convert.ToInt32(Console.ReadLine());

            if (sayi % sayi2 == 0 || sayi == sayi2)
            {
              Sayilar.Add(sayi);
            }
          }
          Console.WriteLine("--- Sonuç ---");
          foreach (var item in Sayilar)
          {
            Console.WriteLine(item);
          }
        }
        else
        {
          goto git;
        }*/

      // 3.Soru
      /*git:
        Console.WriteLine("Pozitif Birinci Sayıyı Giriniz:");
        int sayi1 = Convert.ToInt32(Console.ReadLine());

        List<string> Kelimeler = new List<string>();

        if (sayi1 > 0)
        {
          for (int i = 0; i < sayi1; i++)
          {
            Console.WriteLine((i + 1) + ". Kelimeyi Giriniz:");
            Kelimeler.Add(Console.ReadLine());
          }

          Kelimeler.Reverse();
          Console.WriteLine("--- Girdiğiniz Kelimelerin Sondan Sıralanmış Hali ---");
          foreach (var item in Kelimeler)
          {
            Console.WriteLine(item);
          }
        }
        else
        {
          goto git;
        }*/

      // 4.Soru
      Console.WriteLine("Cümle Yazınız:");
      string cumle = Console.ReadLine();

      var kelimeler = cumle.Split(' ');
      int kelimeSayisi = 0;
      int harfSayisi = 0;

      string liste = "ABCÇDEFGĞHİIJKLMNOÖPRSŞTUÜVYZabcçdefgğhiıjklmnoöprsştuüvyz";

      for (int i = 0; i < cumle.Length; i++)
      {
        //karakter katarkter kontrol ediyoruz.
        if (liste.Contains(cumle[i]))
        {
          harfSayisi++;
        }
      }

      foreach (var item in kelimeler)
      {
        kelimeSayisi++;
      }

      Console.WriteLine("Girdiğiniz Cümlede {0} Adet Kelime, {1} Adet Harf Bulunmaktadır.", kelimeSayisi,harfSayisi);
      Console.ReadKey();
    }
  }
}
