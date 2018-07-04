using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        static SqlCommand _comando;

        static string _conexion;


        public static bool Insertar(Paquete p)
        {
            bool returnAux = true;


            try
            {
                SqlConnection sql = new SqlConnection(PaqueteDAO._conexion);

                PaqueteDAO._comando = new SqlCommand("INSERT INTO Paquete (_direccionEntrega, _estado, _TrackingId) VALUES ('" + p.DireccionDeEntrega + "','" + p.Estado + "'," + p.TrackingID + ")", sql);

                PaqueteDAO._comando.CommandType = System.Data.CommandType.Text;


                PaqueteDAO._comando.ExecuteNonQuery();


            }


            catch(Exception e)
            {

                returnAux = false;
                throw e;

            }

            return returnAux;
        }

        static PaqueteDAO()
        {

           PaqueteDAO._conexion = Properties.Settings.Default.ConnectionString;

        }


        public static string conexion { get; set; }
    }
}
