using System;

namespace TryCatch
{
    class Program
    {
        static void Main(string[] args)
        {
            double numerador, denominador;
            Console.WriteLine("Calculadora de rendimiento:");
            try
            {
                Console.WriteLine("Ingrese los kilometros");
                numerador = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Ingrese los litros");
                denominador = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine($"El rendimiento es: {numerador / denominador} kilómetros/litro");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
