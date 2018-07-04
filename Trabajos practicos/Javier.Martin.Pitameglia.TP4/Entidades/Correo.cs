using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;




namespace Entidades
{

    public delegate void DelegadoEstado(object sender, EventArgs e);

    public enum EEstado { Ingresado, EnViaje, Entregado }


    public class Paquete : IMostrar<Paquete>
    {

        #region Fields

        private string _direccionEntrega;

        private EEstado _estado;

        private string _TrackingId;

        

        #endregion

        #region Propeties

        public string DireccionDeEntrega
        {
            get
            {
                return this._direccionEntrega;
            }

            set { this._direccionEntrega = value; }

        }

        public EEstado Estado
        {

            get { return this._estado; }

            set
            {


                
                this._estado = value;
                this.InformarEstado.Invoke(new object(), new EventArgs());


            }

        }

        public string TrackingID
        {
            get { return this._TrackingId; }
            set { this._TrackingId = value; }
        }

        #endregion

        #region Methods

        public event DelegadoEstado InformarEstado;


        public string MostrarDatos(IMostrar<Paquete> elemento)
        {

            Paquete algo =(Paquete) elemento;

            return String.Format("{0} ({1})\n", this.ToString(), this.Estado.ToString());
        }


        public void MockCicloDeVida()
        {
            while(this._estado != EEstado.Entregado)
            {

                Thread.Sleep(10000);

                if (this._estado == EEstado.EnViaje) this.Estado = EEstado.Entregado;

                if (this._estado == EEstado.Ingresado) this.Estado = EEstado.EnViaje;

                


            }


        }


        public override string ToString()
        {
            IMostrar<Paquete> This = this;

            

            return String.Format("{0} para {1}", this.TrackingID, this.DireccionDeEntrega);
        }



        #region Constructor

        public Paquete(string direccionEntrega, string trackingID)
        {

            this.DireccionDeEntrega = direccionEntrega;
            this.TrackingID = trackingID;
            this._estado = EEstado.Ingresado;

        }

        





        #endregion

        #endregion

        #region Operators

        public static bool operator ==(Paquete p1, Paquete p2)
        {
            bool returnAux = false;

            if((object)p1 != null && (object)p2 != null)
            {

                if (p1._TrackingId == p2._TrackingId) returnAux = true;

            }

            return returnAux;
        }

        public static bool operator !=(Paquete p1, Paquete p2)
        {

            bool returnAux = false;

            if ((object)p1 != null && (object)p2 != null)
            {

                returnAux = !(p1 == p2);

            }

            return returnAux;
        }


        #endregion



    }

   
    public class Correo : IMostrar<List<Paquete>>
    {

        #region Fields

        private List<Paquete> _paquetes;

        private List<Thread> _mockPaquetes;

        #endregion


        #region Propeties

        public List<Paquete> Paquetes
        {
            get { return this._paquetes; }

            set { this._paquetes = value; }

        }


        

        #endregion

        #region Methods


        public string MostrarDatos(IMostrar<List<Paquete>> elemento)
        {
            string MD = "";
            
            
            List<Paquete> elements = ((Correo)elemento).Paquetes;
            
            foreach(Paquete element in elements)
            {
                MD += element.MostrarDatos((IMostrar<Paquete>) element);
                
            }


            return MD;
        }


        public void FinEntregas()
        {


        }

        #region Constructor

        public Correo()
        {
            this.Paquetes = new List<Paquete>();
            this._mockPaquetes = new List<Thread>();
       
        }

        #endregion

        #endregion

        #region Operators

        public static Correo operator +(Correo c, Paquete p)
        {
            if((object) c != null && (object) p != null)
            {

                bool flag = false;

                for(int i = 0; i < c._paquetes.Count; i++)
                {
                    if(p == c._paquetes[i])
                    {
                        flag = true;
                        throw new TrackingIdRepetidoException("lero lero");
                        

                    }

                    
                }


                if (flag == false)
                {

                    c._paquetes.Add(p);

                    c._mockPaquetes.Add(new Thread(p.MockCicloDeVida));

                    c._mockPaquetes[c._mockPaquetes.Count - 1].Start();

                }

            }

            return c;
        }

        #endregion


    }

    



}



#region Fields



#endregion


#region Propeties


#endregion

#region Methods

#region Constructor

#endregion

#endregion

#region Operators


#endregion