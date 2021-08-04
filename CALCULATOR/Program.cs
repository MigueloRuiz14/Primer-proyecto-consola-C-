using System;
using CalculatorLibrary;

namespace CalculatorProgram
{

    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
           
            Console.WriteLine("Console Calculator in C#\r");
            Console.WriteLine("------------------------\n");

            Calculator calculator = new Calculator();
            while (!endApp)
            {
                // Se declaran variables.
                string numeroInput1 = "";
                string numeroInput2 = "";
                double resultado = 0;

               
                Console.Write("Digite el primer número y presione Enter: ");
                numeroInput1 = Console.ReadLine();

                double cleanNum1 = 0;
                while (!double.TryParse(numeroInput1, out cleanNum1))
                {
                    Console.Write("Esta no es una entrada válida. Ingrese un valor entero: ");
                    numeroInput1 = Console.ReadLine();
                }

              
                Console.Write("Digite el segundo número y presione Enter: ");
                numeroInput2 = Console.ReadLine();

                double cleanNum2 = 0;
                while (!double.TryParse(numeroInput2, out cleanNum2))
                {
                    Console.Write("Esta no es una entrada válida. Ingrese un valor entero: ");
                    numeroInput2 = Console.ReadLine();
                }

              
                Console.WriteLine("Seleccione la operación que desea realizar:");
                Console.WriteLine("\ts - Suma");
                Console.WriteLine("\tr - Resta");
                Console.WriteLine("\tm - Multiplicación");
                Console.WriteLine("\td - Divición");
                Console.Write("Tú opción es: ");

                string op = Console.ReadLine();

                try
                {
                    resultado = calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(resultado))
                    {
                        Console.WriteLine("Esta operación resultará en un error matemático.\n");
                    }
                    else Console.WriteLine("Tú resultado es: {0:0.##}\n", resultado);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh no! Se produjo una excepción al intentar hacer los cálculos.\n - Detalles: " + e.Message);
                }

                Console.WriteLine("------------------------\n");

               
                Console.Write("Presione 'n' y Enter para cerrar la aplicación, o presione cualquier otra tecla y Enter para continuar: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n"); 
            }
            calculator.Finish();
            return;
        }
    }
}
