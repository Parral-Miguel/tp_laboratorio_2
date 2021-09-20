using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Operandos
{
    public class Operando
    {
        private double numero;

        public Operando()
        {
            this.numero = 0;
        }

        public Operando(string strNumero)
        {
            this.Numero = strNumero;
        }

        public Operando(double numero)
        {
            this.numero = numero;
        }

        static public double ValidarOperando(string strNumero)
        {
            if (strNumero == null)
            {
                return 0;
            }
            
            if (Regex.IsMatch(strNumero, "^[+-]?([0-9]+,?[0-9]*|,[0-9]+)$"))
            {
                return double.Parse(strNumero);
            }
                return 0;
        }

        public string Numero
        {
            set
            {
                this.numero = Operando.ValidarOperando(value);
            }
        }

        static bool EsBinario(string binario)
        {
            return (Regex.IsMatch(binario, "^[01]+$"));

        }

        static public string BinarioDecimal(string binario)
        {
            if (EsBinario(binario))
            {
                return Convert.ToString(Convert.ToInt32(binario, 2));   
            }

                return "Valor invalido";
        }

        static public string DecimalBinario(string numero)
        {
            bool conversion = Int32.TryParse(numero, out int parseado);

            if (conversion)
            {
                return DecimalBinario((double)parseado);
            }
                return "Valor invalido";
        }

        static public string DecimalBinario(double numero)
        {
            return Convert.ToString((int)numero, 2);
        }

        static public double operator +(Operando n1, Operando n2)
         {
            return (n1.numero + n2.numero);
        }

        static public double operator -(Operando n1, Operando n2)
        {
            return (n1.numero - n2.numero);
        }


        static public double operator *(Operando n1, Operando n2)
        {
            return (n1.numero * n2.numero);
        }

        static public double operator /(Operando n1, Operando n2)
        {
            if (n2.numero == 0)
            {
                return double.MinValue;
            }
                return (n1.numero / n2.numero);
        }
    }

}
