using System;

namespace TryCatch
{
    class Program
    {
        static void Main(string[] args)
        {
            int numerador, denominador;
            Console.WriteLine("Calculadora de cocientes:");
            try
            {
                Console.WriteLine("Ingrese el numerador");
                numerador = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingrese el denominador");
                denominador = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"El cociente entero es: {numerador / denominador}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
