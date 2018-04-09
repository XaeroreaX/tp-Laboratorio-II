using System;

namespace entidades
{
    public class Calculadora
    {

        public static double Operar(Numero numero1, Numero numero2, string operador)
        {
            double returnResultado = 0.0;


            operador = Calculadora.ValidarOperador(operador);
           

            switch (operador)
            { 
                case "+":
                    returnResultado = numero1 + numero2;
                    break;

                case "-":
                    returnResultado = numero1 - numero2;
                    break;

                case "/":
                    returnResultado = numero1 / numero2;
                    break;

                case "*":
                    returnResultado = numero1 * numero2;
                    break;

            }


            return returnResultado;
        }


        private static string ValidarOperador(string operador)
        {

            if (operador == "+") return operador;

            if (operador == "-") return operador;

            if (operador == "/") return operador;

            if (operador == "*") return operador;

            return "+";

        }
    }


}
