using System;
using System.Collections.Generic;
using System.Text;

namespace entidades
{
    public class Numero
    {
        private double numero;



        public double SetNumero {

            set
            {
                if(value is double || value is int)
                {

                    this.numero = (double)value;

                }
                
       

            }

        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////CONSTRUCTORES


        public Numero(double N) { this.numero = N; }

        public Numero(string N) {this.numero = this.ValidarNumero(N);}
        

        public Numero() : this(0.0){}



        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////METODOS

        private double ValidarNumero(string strNumero)
        {
            double returnNum;

            if (double.TryParse(strNumero, out returnNum) == false) returnNum = 0;

            return returnNum;
        }

        public string BinarioDecimal(string binario)
        {
            
            int len = binario.Length;
            int num = 0, stringCount = 0;
            char[] _binario = new char[len];

            _binario = binario.ToCharArray();



            for (int i = len - 1, j = 0; i >= 0; i--,j++)
            {

                
                

                if (binario[i] == '0' || binario[i] == '1')
                {
                    num += (int)(int.Parse(binario[i].ToString()) * Math.Pow(2, j));
                }
                else return "valor invalido";
                    

            }

            return Convert.ToString(num);
        }

        public string DecimalBinario(string _decimal)
        {
            string auxBinario = "", binario = "";

            double _Decimal = 0;
            int numero;

            if (double.TryParse(_decimal, out _Decimal) == true)
            {

                numero = (int)_Decimal;

                while (numero != 0)
                {
                    if (numero % 2 == 0)
                    {
                        auxBinario += "0";
                    }
                    else
                    {
                        auxBinario += "1";
                    }
                    numero = numero / 2;

                   
                }
         

            }
            else return "0";

            if(_Decimal >= 0)
            {
                binario = "0";
            }
            else
            {
                binario = "1";
            }

            for(int i = auxBinario.Length -1; i >= 0; i--)
            {
                binario += auxBinario[i];
            }

            
            return binario;
        }

        public string DecimalBinario(double _decimal)
        {
            return this.DecimalBinario("" + _decimal); 
        }

        public string show() { return ""+this.numero; }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////SOBRECARGAS


        public static double operator +(Numero numero1, Numero numero2){return numero1.numero + numero2.numero;}

        public static double operator -(Numero numero1, Numero numero2) { return numero1.numero - numero2.numero; }

        public static double operator /(Numero numero1, Numero numero2) { return numero1.numero / numero2.numero; }

        public static double operator *(Numero numero1, Numero numero2) { return numero1.numero * numero2.numero; }



        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
