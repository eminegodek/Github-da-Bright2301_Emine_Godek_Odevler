namespace Odev03_04_02_2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sayi = 0;
            Console.Write("Sayı giriniz:");
            sayi = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Karesi: {0}", Math.Pow(sayi, 2));
            Console.WriteLine("Küpü: {0}", Math.Pow(sayi, 3));
            Console.ReadKey();
        }
    }
}