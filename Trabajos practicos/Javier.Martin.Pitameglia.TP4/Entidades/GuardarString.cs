using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardarString
    {

        public static string Guardar(this string texto, string archivo)
        {

            string message = "OK";
            
            try
            { 
                StreamWriter file = new StreamWriter(archivo);
            
                file.WriteLine(texto);

                file.Close();
            }


            #region Catch

            catch (UnauthorizedAccessException EX)
            {
                message = EX.Message;

            }

            catch(ArgumentException EX)
            {
                message = EX.Message;
            }

            catch (DirectoryNotFoundException EX)
            {
                message = EX.Message;
            }

            catch (PathTooLongException EX)
            {
                message = EX.Message;
            }

            catch (IOException EX)
            {
                message = EX.Message;
            }

            catch (System.Security.SecurityException EX)
            {
                message = EX.Message;
            }

            catch (ObjectDisposedException EX)
            {
                message = EX.Message;
            }

            catch (Exception EX)
            {
                message = EX.Message;
            }
            #endregion

            return message;
        }

    }
}
