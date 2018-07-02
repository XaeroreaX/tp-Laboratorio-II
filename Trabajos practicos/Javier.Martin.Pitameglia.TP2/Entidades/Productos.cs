using System;
using System.Collections.Generic;
using System.Text;

namespace Productos
{


    #region enumerados

    public enum EMarca { Serenisima, Campagnola, Arcor, Ilolay, Sancor, Pepsico, }

    public enum ETipo { Entera, Descremada }



    #endregion

    public abstract class Producto
    {
        #region Fields

        protected string _codigoDeBarra;

        protected ConsoleColor _colorPrimarioEmpaque;

        protected EMarca _marca;

        #endregion




        #region Propeties

        public abstract short CantidadCalorias { get; }

        #endregion

        #region Methods

        public virtual string Mostrar()
        {
            string SHOW = "\nCODIGO DE BARRA:" + this._codigoDeBarra + "\n";
            SHOW += "MARCA:" + this._marca.ToString()+"\n";
            SHOW += "COLOR DE EMPAQUE:" + this._marca.ToString()+"\n";
            SHOW += "------------------------\n";



            return SHOW;
        }


        #region Constructor

        public Producto(string codigoDeBarra, EMarca marca, ConsoleColor colorPrimarioEmpaque)
        {
            this._codigoDeBarra = codigoDeBarra;
            this._marca = marca;
            this._colorPrimarioEmpaque = colorPrimarioEmpaque;

        }
        #endregion

        #endregion

        #region Operators

        public static implicit operator string(Producto p)
        {


            return p.Mostrar();
        }


        public static bool operator ==(Producto p1, Producto p2)
        {
            bool returnAux = false;

            if ((object)p1 == null || (object)p2 == null) return returnAux;

            if (p1._codigoDeBarra == p2._codigoDeBarra) returnAux = true;


            return returnAux;
        }

        public static bool operator !=(Producto p1, Producto p2)
        {
            bool returnAux = false;

            if ((object)p1 == null || (object)p2 == null) return returnAux;

            returnAux = !(p1 == p2);

            return true;
        }




        #endregion



    }


    public class Dulce : Producto
    {




        #region Propeties

        public override short CantidadCalorias
        {
            get
            {
                return 80;
            }

        }

        #endregion

        #region Methods

            #region Constructor

            public Dulce(EMarca marca, string codigo, ConsoleColor color) : base(codigo, marca, color) { }


            #endregion

        public override string Mostrar()
        {
            string show = "DULCE"+base.Mostrar();

            show += "\nCALORIAS : " + this.CantidadCalorias + "\n";
            show += "------------------------\n";

            return show;
        }

        #endregion




    }


    public class Snack : Producto
    {

        #region Propeties

        public override short CantidadCalorias
        {
            get
            {
                return 104;
            }
        }

        #endregion

        #region Methods

        #region Constructor

        public Snack(EMarca marca, string codigo, ConsoleColor color) : base(codigo, marca, color) { }


        #endregion

        public override string Mostrar()
        {
            string show = "SNACK"+base.Mostrar();

            show += "\nCALORIAS : " + this.CantidadCalorias + "\n";
            show += "------------------------\n";

            return show;
        }

        #endregion
    }


    public class Leche : Producto
    {


        #region Fields

        private ETipo _tipo;

        #endregion


        #region Propeties

        public override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }

        #endregion

        #region Methods

            #region Constructor

            public Leche(EMarca marca, string codigo, ConsoleColor color) : this(marca: marca, codigo: codigo, color: color, tipo: ETipo.Entera) { }

            public Leche(EMarca marca, string codigo, ConsoleColor color, ETipo tipo)
                : base(codigo, marca, color) 
            {
                this._tipo = tipo;
            }

        #endregion

        public override string Mostrar()
        {
            string show = "LECHE"+base.Mostrar();

            show += "\nCALORIAS : " + this.CantidadCalorias + " TIPO:"+this._tipo.ToString()+"\n";
            show += "------------------------\n";

            return show;
        }

        #endregion

    }
}




