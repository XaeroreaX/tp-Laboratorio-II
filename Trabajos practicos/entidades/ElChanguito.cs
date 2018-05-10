using System;
using System.Collections.Generic;
using System.Text;
using Productos;

namespace ElChanguito
{

    public enum ETipo { Dulce, Snack, Leche, Todos}

    public sealed class Changuito
    {

        #region Fields

        private int _epacioDisponible;

        private List<Producto> _productos;


        #endregion




        #region Methods


        public static string Mostrar(Changuito concecionaria, ETipo tipoDeChanguito)
        {

            string mostrar = "tenemos " + concecionaria._productos.Count + " lugares ocupados de un total de" + concecionaria._epacioDisponible + " disponible\n";

            foreach(Producto element in concecionaria._productos)
            {

                if(tipoDeChanguito == ETipo.Leche)
                {
                    if (element is Leche) mostrar += element.Mostrar();
                }

                if (tipoDeChanguito == ETipo.Snack)
                {
                    if (element is Snack) mostrar += element.Mostrar();
                }

                if (tipoDeChanguito == ETipo.Dulce)
                {
                    if (element is Dulce) mostrar += element.Mostrar();
                }

                if (tipoDeChanguito == ETipo.Todos)
                {
                    mostrar += element.Mostrar();
                }

            }

            return mostrar;
        }

        public override string ToString()
        {
            return Mostrar(this, ETipo.Todos);
        }

        #region Constructor

        public Changuito(int espacioDisponible)
        {
            this._epacioDisponible = espacioDisponible;

            this._productos = new List<Producto>();

        }

        public Changuito() : this(100) { }


        #endregion

        #endregion

        #region Operators

        public static Changuito operator +(Changuito miChanguito, Producto miProducto)
        {
            int count = 0; 
            if((object) miChanguito != null && (object)miProducto != null)
            {
                if(miChanguito._productos.Count <= miChanguito._epacioDisponible)
                {

                    foreach(Producto element in miChanguito._productos)
                    {

                        if (element == miProducto) break;

                        count++;
                    }

                    if(count == miChanguito._productos.Count)
                    {
                        miChanguito._productos.Add(miProducto);
                    }
                    else if(miChanguito._productos.Count > count)
                    {
                        miChanguito._productos[count] = miProducto;

                    }
                }
            }
            return miChanguito;
        }

        public static Changuito operator -(Changuito miChanguito, Producto miProducto)
        {

            return miChanguito;
        }

        #endregion


    }
}
