using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Operandos;

namespace Calculador
{
    public class Calculadora
    {
        static private char ValidarOperador(char charOperador)
        {
            if (charOperador == '+' || charOperador == '/' || charOperador == '*' || charOperador == '-')

            {
                return charOperador;
            }

                return '+';      
        }

        static public double Operar(Operando n1, Operando n2, char charOperador)
        {
            charOperador = ValidarOperador(charOperador);
            double resultado = 0;

            switch (charOperador)
            {
                case '+':
                    {
                        resultado = n1 + n2;
                        break;
                    }

                case '-':
                    {
                        resultado = n1 - n2;
                        break;
                    }
                case '*':
                    {
                        resultado = n1 * n2;
                        break;
                    }
                case '/':
                    {
                        resultado = n1 / n2;
                        break;
                    }

            }

            return resultado; 
        }

    }
}
