using System;

namespace Empleados
{
    public class Empleado
    {
        // Obligatorios
        public string apellido;
        public string nombre;
        public string domicilio;
        public DateTime fechaNacimiento;
        public bool esCasado;
        public bool esDivorciado;
        public bool tieneTitulo;
        public DateTime fechaIngresoEmpresa;

        // Opcionales
        public int cantidadHijos;
        public string nombreTitulo;
        public string nombreUniversidad;
        public DateTime fechaDivorcio;

        // Estáticos
        static decimal basico = 50237.78m; // la letra M al final del número lo convierte en tipo "decimal"

        // Calculados
        public int edad;
        public int antieguedad;
        public decimal salario;

        //Métodos
        public bool Cargar()
        {
            try
            {
                Console.Write("\tIngrese los apellidos: ");
                if (String.IsNullOrWhiteSpace(apellido = Console.ReadLine())) throw new NullOrEmptyStringException();
                Console.Write("\tIngrese los nombres: ");
                if (String.IsNullOrWhiteSpace(nombre = Console.ReadLine())) throw new NullOrEmptyStringException();
                Console.Write("\tIngrese el domicilio: ");
                if (String.IsNullOrWhiteSpace(domicilio = Console.ReadLine())) throw new NullOrEmptyStringException();

                Console.Write("\tIngrese el día de nacimiento: ");
                int dia = Convert.ToInt32(Console.ReadLine());
                Console.Write("\tIngrese el mes de nacimiento: ");
                int mes = Convert.ToInt32(Console.ReadLine());
                Console.Write("\tIngrese el año de nacimiento: ");
                int ano = Convert.ToInt32(Console.ReadLine());
                fechaNacimiento = new DateTime(ano, mes, dia);

                Console.Write("\tIngrese el día de ingreso a la empresa: ");
                dia = Convert.ToInt32(Console.ReadLine());
                Console.Write("\tIngrese el mes de ingreso a la empresa: ");
                mes = Convert.ToInt32(Console.ReadLine());
                Console.Write("\tIngrese el año de ingreso a la empresa: ");
                ano = Convert.ToInt32(Console.ReadLine());
                fechaIngresoEmpresa = new DateTime(ano, mes, dia);

                if (DateTime.Compare(fechaIngresoEmpresa, fechaNacimiento) <= 0)
                {
                    throw new IncoherentDateTimeException();
                }

                Console.Write("\t¿Es casado?: (1:Si | 2:No): ");
                int bandera = Convert.ToInt32(Console.ReadLine());
                if (bandera == 1)
                {
                    esCasado = true;
                    Console.Write("\tIngrese la cantidad de hijos: ");
                    cantidadHijos = Convert.ToInt32(Console.ReadLine());
                }
                else
                {
                    esCasado = false;
                }

                Console.Write("\t¿Es divorciado?: (1:Si | 2:No): ");
                bandera = Convert.ToInt32(Console.ReadLine());
                if (bandera == 1)
                {
                    esDivorciado = true;
                    Console.Write("\tIngrese el día de divorcio: ");
                    dia = Convert.ToInt32(Console.ReadLine());
                    Console.Write("\tIngrese el mes de divorcio: ");
                    mes = Convert.ToInt32(Console.ReadLine());
                    Console.Write("\tIngrese el año de divorcio: ");
                    ano = Convert.ToInt32(Console.ReadLine());
                    fechaDivorcio = new DateTime(ano, mes, dia);

                    if (DateTime.Compare(fechaDivorcio, fechaNacimiento) <= 0)
                    {
                        throw new IncoherentDateTimeException();
                    }
                }
                else
                {
                    esDivorciado = false;
                }

                Console.Write("\t¿Tiene título universitario?: (1:Si | 2:No): ");
                bandera = Convert.ToInt32(Console.ReadLine());
                if (bandera == 1)
                {
                    tieneTitulo = true;
                    Console.Write("\tIngrese nombre del título obtenido: ");
                    if (String.IsNullOrWhiteSpace(nombreTitulo = Console.ReadLine())) throw new NullReferenceException();
                    Console.Write("\tIngrese el nombre de la Universidad donde obtuvo el título: ");
                    if (String.IsNullOrWhiteSpace(nombreUniversidad = Console.ReadLine())) throw new NullReferenceException();
                }
                else
                {
                    tieneTitulo = false;
                }

                edad = CalcularEdad();
                antieguedad = CalcularAntiguedad();
                salario = CalcularSalario();
                return true;
            }
            catch (FormatException exNumero)
            {
                Console.WriteLine("ERROR: El número ingresado no es válido");
                //Console.WriteLine(exNumero.Message);
                return false;
            }
            catch (IncoherentDateTimeException exIncoherente)
            {
                Console.WriteLine("ERROR: Las fechas ingresadas son incoherentes");
                //Console.WriteLine(exIncoherente.Message);
                return false;
            }
            catch (NullOrEmptyStringException exVacio)
            {
                Console.WriteLine("ERROR: El campo no debería estar vacío");
                //Console.WriteLine(exNull.Message);
                return false;
            }
            catch (ArgumentOutOfRangeException exFecha)
            {
                Console.WriteLine("ERROR: La fecha ingresada es incorrecta");
                //Console.WriteLine(exFecha.Message);
                return false;
            }
        }


        public int CalcularEdad()
        {
            DateTime fechaActual = DateTime.Today;
            if (fechaActual.Year == fechaNacimiento.Year) // Tiene menos de 1 año de vida
            {
                return 0;
            }
            else
            {
                if (fechaActual.Month < fechaNacimiento.Month || (fechaActual.Month == fechaNacimiento.Month && fechaActual.Day < fechaNacimiento.Day)) // Todavía no cumplió años este año
                {
                    return (fechaActual.Year - fechaNacimiento.Year - 1);
                }
                else // Ya cumplió años este año
                {
                    return (fechaActual.Year - fechaNacimiento.Year);
                }
            }
        }

        public int CalcularAntiguedad()
        {
            DateTime fechaActual = DateTime.Today;
            if (fechaActual.Year == fechaIngresoEmpresa.Year) // Tiene menos de 1 año en la empresa
            {
                return 0;
            }
            else
            {
                if (fechaActual.Month < fechaIngresoEmpresa.Month || (fechaActual.Month == fechaIngresoEmpresa.Month && fechaActual.Day < fechaIngresoEmpresa.Day)) // Todavía no cumplió años en la empresa
                {
                    return (fechaActual.Year - fechaIngresoEmpresa.Year - 1);
                }
                else // Ya cumplió año en la empresa este año
                {
                    return (fechaActual.Year - fechaIngresoEmpresa.Year);
                }
            }
        }

        public decimal CalcularSalario()
        {
            decimal adicional;
            if (antieguedad < 20)
            {
                adicional = decimal.Round(basico * (1m + Convert.ToDecimal(antieguedad) / 100m), 2);
            }
            else
            {
                adicional = decimal.Round(basico * 1.25m, 2); // la letra M al final del número lo convierte en tipo "decimal"
            }
            return decimal.Round(basico * 0.85m + adicional, 2); // la letra M al final del número lo convierte en tipo "decimal"
        }

        public void Mostrar()
        {
            Console.WriteLine($"\tApellido y Nombre:\t{apellido}, {nombre}");
            Console.WriteLine($"\tEdad:\t\t\t{edad} años");
            if (esCasado)
            {
                Console.WriteLine($"\tCantidad de hijos:\t{cantidadHijos}");
            }
            if (esDivorciado)
            {
                Console.WriteLine($"\tFecha de divorcio:\t{fechaDivorcio.Day}/{fechaDivorcio.Month}/{fechaDivorcio.Year}");
            }
            if (tieneTitulo)
            {
                Console.WriteLine($"\tTítulo:\t\t\t{nombreTitulo}");
                Console.WriteLine($"\tUniversidad:\t\t{nombreUniversidad}");
            }
            Console.WriteLine($"\tAntiguedad:\t\t{antieguedad} años");
            Console.WriteLine($"\tSalario:\t\t$ {salario}");
        }
    }
}