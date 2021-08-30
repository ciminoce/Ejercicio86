using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio86
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] temperaturas = new double[15];
            double mediaTemp = 0;
            int opcion = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("0-Salir");
                Console.WriteLine("1-Ingreso de Datos");
                Console.WriteLine("2-Listado de Datos");
                Console.WriteLine("3-Estadísticas");
                Console.WriteLine("4-Listado Estadístico");
                Console.WriteLine("5-Listado de Equivalencias");
                
                IngresarOpcion(ref opcion);
                switch (opcion)
                {
                    case 0:
                        break;
                    case 1:
                        PopulateArray(temperaturas);
                        break;
                    case 2:
                        PrintArray(temperaturas);
                        break;
                    case 3:
                        Statistics(temperaturas,ref mediaTemp);
                        break;
                    case 4:
                        PrintSuperior(temperaturas, mediaTemp);
                        break;
                    case 5:
                        PrintCelsiusAndOthers(temperaturas);
                        break;
                }
            } while (true);

            if (opcion==0)
            {
                return;
            }
        }

        private static void PrintSuperior(double[] temperaturas, double mediaTemp)
        {
            Console.Clear();
            Console.WriteLine($"Temperaturas superiores al promedio: {mediaTemp}");
            foreach (var temperatura in temperaturas)
            {
                if (temperatura>mediaTemp)
                {
                    Console.WriteLine($"{temperatura} *");
                }
                else
                {
                    Console.WriteLine($"{temperatura}");
                }
            }
            ProcesoFinalizado();
        }

        private static void PrintCelsiusAndOthers(double[] temperaturas)
        {
            Console.Clear();
            Console.WriteLine("Listado de Temperaturas y equivalentes");
            foreach (var temperatura in temperaturas)
            {
                var reamur = ConvertirReaumur(temperatura);
                string linea = string.Concat(temperatura.ToString("#0.0").PadLeft(4, ' '), "-",reamur.ToString("#0.0").PadLeft(5,' '));
                Console.WriteLine(linea);
            }
            ProcesoFinalizado();
        }

        private static double ConvertirReaumur(double temperatura)
        {
            return temperatura * 0.8;
        }

        private static void Statistics(double[] temperaturas, ref double mediaTemp)
        {
            PrintArray(temperaturas);
            var mayorTemp = ObtenerMayorTemperatura(temperaturas);
            Console.WriteLine($"Mayor Temperatura:{mayorTemp}");
            var menorTemp = ObtenerMenorTemperatura(temperaturas);
            Console.WriteLine($"Menor Temperatura:{menorTemp}");
            mediaTemp = ObtenerMedia(temperaturas);
            Console.WriteLine($"Temperatura Media:{mediaTemp}");
            var cantidadEntre0y10 = ContarTemperaturas(temperaturas,0, 10);
            Console.WriteLine($"Temperaturas entre 0 y 10:{cantidadEntre0y10}");
            var cantidadEntre11y20 = ContarTemperaturas(temperaturas,11, 20);
            Console.WriteLine($"Temperaturas entre 11 y 20:{cantidadEntre11y20}");
            var cantidadMayores20 = ContarTemperaturas(temperaturas, 20);
            Console.WriteLine($"Temperaturas superiores a 20:{cantidadMayores20}");
            ProcesoFinalizado();
        }

        private static int ContarTemperaturas(double[] temperaturas, int limiteInferior, int? limiteSuperior=null)
        {
            var resultado = 0;

            if (limiteSuperior!=null)
            {
                foreach (var temperatura in temperaturas)
                {
                    if (temperatura >= limiteInferior && temperatura <= limiteSuperior)
                    {
                        resultado++;
                    }
                }

            }
            else
            {
                foreach (var temperatura in temperaturas)
                {
                    if (temperatura>limiteInferior)
                    {
                        resultado++;
                    }
                }
            }
            return resultado;
        }

        private static double ObtenerMedia(double[] temperaturas)
        {
            //double promedio = 0;
            //foreach (var temperatura in temperaturas)
            //{
            //    promedio += temperatura;
            //}

            //return promedio / temperaturas.Length;
            return temperaturas.Average();
        }

        private static double ObtenerMenorTemperatura(double[] temperaturas)
        {
            //var resultado = 100d;
            //for (int i = 0; i < temperaturas.Length; i++)
            //{
            //    if (temperaturas[i]<resultado)
            //    {
            //        resultado = temperaturas[i];
            //    }
            //}
            //return resultado;
            return temperaturas.Min();
        }
        
        private static double ObtenerMayorTemperatura(double[] temperaturas)
        {
            //var resultado = -100d;
            //foreach (var temperatura in temperaturas)
            //{
            //    if (temperatura>resultado)
            //    {
            //        resultado = temperatura;
            //    }
            //}
            //return resultado;
            return temperaturas.Max();
        }

        private static void PrintArray(double[] temperaturas)
        {
            Console.Clear();
            Console.WriteLine("Listado de Temperaturas ingresadas");
            foreach (var temperatura in temperaturas)
            {
                Console.WriteLine(temperatura.ToString("#0.0").PadLeft(4,' '));
            }
            ProcesoFinalizado();
        }

        private static void PopulateArray(double[] temperaturas)
        {   
            Random r = new Random();
            for (int i = 0; i < temperaturas.Length; i++)
            {
                temperaturas[i] = TemperaturaRandom(r);
            }

            ProcesoFinalizado();
        }

        private static void ProcesoFinalizado()
        {
            Console.WriteLine("Proceso Finalizado... <ENTER> para continuar");
            Console.ReadLine();
        }

        private static double TemperaturaRandom(Random r)
        {
            return double.Parse(string.Concat(r.Next(0, 25).ToString(),",",r.Next(0, 10).ToString())); 
        }

        private static void IngresarOpcion(ref int opcion)
        {
            do
            {
                Console.Write("Ingrese una opción:");
                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Opción mal ingresada");
                }else if (opcion<0 ||opcion>5)
                {
                    Console.WriteLine("Opción fuera del rango permitido [0-5]");
                }
                else
                {
                    break;
                }
            } while (true);
        }
    }
}
