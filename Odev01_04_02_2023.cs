namespace Odev01_04_02_2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Birinci sayiyi giriniz.: ");
            int sayi1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("İkinci sayiyi giriniz: ");
            int sayi2 = Convert.ToInt32(Console.ReadLine());
            int sonuc = sayi1 / sayi2;
            Console.WriteLine(sonuc);
            if (sonuc >= 50)
            {
                Console.WriteLine("Geçti");

            }
            else
            {
                Console.WriteLine("Kaldı");
            }

        }


        
         

    }
}