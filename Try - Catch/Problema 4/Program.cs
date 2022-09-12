using System;
using System.Net;
using System.Text.Json;

namespace TryCatch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("BIENVENIDO");
            Console.WriteLine("El siguiente programa obtiene las provincias argentinas desde la API");
            Console.WriteLine("https://apis.datos.gob.ar/georef/api/provincias");
            //Datos para la conexión a la API
            var Url = @"https://apis.datos.gob.ar/georef/api/provincias?campos=id,nombre";
            var Conexion = (HttpWebRequest)WebRequest.Create(Url);
            Conexion.Method = "GET";
            Conexion.ContentType = "application/json";
            Conexion.Accept = "application/json";

            //Conexión a la API
            try
            {
                using (WebResponse Respuesta = Conexion.GetResponse())
                {
                    using (Stream SR = Respuesta.GetResponseStream())
                    {
                        if (SR == null) return;
                        using (StreamReader SRObjeto = new StreamReader(SR))
                        {
                            string RespuestaObjeto = SRObjeto.ReadToEnd();
                            Root ListadoAPI = JsonSerializer.Deserialize<Root>(RespuestaObjeto);
                            Console.WriteLine("\nListado de provincias:");
                            Console.WriteLine("\tID\tProvincia");
                            
                            foreach (Provincia Prov in ListadoAPI.Provincias)
                            {
                                Console.WriteLine($"\t{Prov.Id}\t{Prov.Nombre}");
                            }
                        }
                    }
                }
            }
            catch (WebException Excepcion)
            {
                Console.WriteLine("No se pudo acceder a la API.");
            }
        }
    }
}






