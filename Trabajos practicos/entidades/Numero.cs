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
            int i = 0, j = 0, num = 0, stringCount = 0;
            char[] _binario = new char[len];

            _binario = binario.ToCharArray();



            for (i = len - 1; i >= 0; i--)
            {

                if(_binario[stringCount] == '1')
                {
                    num += 1;
                    
                    if(stringCount < (len - 2))

                    for(j = 2; j < len; j++)
                    {
                        
                        num += 2 * 2;
                    }
                }

            }

            return ""+num;
        }

        public string DecimalBinario(string _decimal)
        {
            string auxString = "";
            double _Decimal = 0;
            int _numero, count = 0;
            char[] _binario;

            if (double.TryParse(_decimal, out _Decimal) == true)
            {

                _numero = (int)_Decimal;

                while (_numero != 1)
                {
                    if (_numero % 2 == 0)
                    {
                        auxString += "0";
                    }
                    else
                    {
                        auxString += "1";
                    }
                    _numero = _numero / 2;

                    count++;
                }

                _binario = new char[count];
                auxString = "";

                for (int i = count - 1; i >= 0; i--)
                {
                    auxString += _binario[i];
                }


            }
            else auxString = "0";


            //auxString = "" + _numero;
            return auxString;
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
