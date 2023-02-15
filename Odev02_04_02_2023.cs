namespace Odev02_04_02_2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Vize notunu giriniz :");
            int vize = Convert.ToInt32(Console.ReadLine());
            Console.Write("Final notunu giriniz :");
            int final = Convert.ToInt32(Console.ReadLine());
            int ort = Convert.ToInt32(vize * 0.4 + final * 0.6);
            Console.WriteLine();
            if (ort >= 60) 

            {
                Console.WriteLine("Geçtiniz: ");
            }

            else if (ort <= 60)
            {
                Console.WriteLine("Kaldınız: ");
            }

        }
    }
}