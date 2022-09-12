using System;

namespace Empleados
{
    static class Program
    {
        public static int Main(string[] args)
        {
            List<Empleado> listaEmpleados = new List<Empleado>();
            bool exito;
            Mensajes.Titulo("BIENVENIDO");
            do
            {
                exito = CargarEmpleados(listaEmpleados);
            } while (!exito);
            MostrarEmpleados(listaEmpleados);
            Console.WriteLine("\nGracias por utilizar el programa.");
            return 0;
        }

        static bool CargarEmpleados(List<Empleado> listaEmpleados)
        {
            Mensajes.TerminarLinea("Carga de empleados");
            try
            {
                Console.Write("Ingrese la cantidad de empleados a cargar: ");
                int cantidad = Convert.ToInt32(Console.ReadLine());
                for (int i = 1; i <= cantidad; i++)
                {
                    Console.WriteLine($"\nEmpleado [{i}]:");
                    Empleado empleado = new Empleado();
                    if (empleado.Cargar())
                    {
                        listaEmpleados.Add(empleado);
                    }
                    else
                    {
                        Console.WriteLine("Error al cargar el empleado. Intente nuevamente");
                        i--;
                    }
                }
                Console.WriteLine("\nFin de la carga.");
                return true;
            }
            catch (Exception exNumero)
            {
                Console.WriteLine("ERROR: El número ingresado no es válido");
                Console.WriteLine("Intente nuevamente");
                //Console.WriteLine(exNumero); // activar si quiero mostrar el error
                return false;
            }
        }

        static void MostrarEmpleados(List<Empleado> listaEmpleados)
        {
            Mensajes.TerminarLinea("Mostrando empleados:");
            foreach (Empleado emple in listaEmpleados)
            {
                Console.WriteLine($"\nEmpleado [{listaEmpleados.IndexOf(emple)+1}]:");
                emple.Mostrar();
            }
            Console.WriteLine("\nFin de la lista.");
        }
    }

}