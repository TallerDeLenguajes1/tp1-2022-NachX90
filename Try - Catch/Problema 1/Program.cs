using System;

namespace TryCatch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese un número");
            int numero;
            try
            {
                numero = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"El cuadrado es: {numero*numero}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
