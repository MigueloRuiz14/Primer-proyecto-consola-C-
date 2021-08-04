using System;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json;

namespace CalculatorLibrary
{ 
    public class Calculator
    {

        JsonWriter writer; 

        public Calculator()
        {
            StreamWriter logFile = File.CreateText("calculatorlog.json");
            logFile.AutoFlush = true;
            writer = new JsonTextWriter(logFile);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName("Operations");
            writer.WriteStartArray();
        }

        public double DoOperation(double numero1, double numero2, string op)
        {
            double resultado = double.NaN; 
            writer.WriteStartObject();
            writer.WritePropertyName("Operand1");
            writer.WriteValue(numero1);
            writer.WritePropertyName("Operand2");
            writer.WriteValue(numero2);
            writer.WritePropertyName("Operation");
            
            switch (op)
            {
                case "s":
                    resultado = numero1 + numero2;
                    writer.WriteValue("Suma");
                    break;
                case "r":
                    resultado = numero1 - numero2;
                    writer.WriteValue("Resta");
                    break;
                case "m":
                    resultado = numero1 * numero2;
                    writer.WriteValue("Multiplicación");
                    break;
                case "d":
                    
                    if (numero2 != 0)
                    {
                        resultado = numero1 / numero2;
                        writer.WriteValue("Divición");
                    }
                    break;
                
                default:
                    break;
            }
            writer.WritePropertyName("Resultado");
            writer.WriteValue(resultado);
            writer.WriteEndObject();

            return resultado;
        }

        public void Finish()
        {
            writer.WriteEndArray();
            writer.WriteEndObject();
            writer.Close();
        }
    }
}