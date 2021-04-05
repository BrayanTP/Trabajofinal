using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Trabajofinal
{
    class valid
    {
        public bool vacio(string texto)
        {
            if (texto.Equals(""))
            {
                Console.SetCursorPosition(55, 25); Console.WriteLine("No puede quedar vacio, por favor insertar una opción");
                return true;
            }
            else
                return false;
        }

        public bool sino(string texto)
        {
            texto.ToLower(); 

            if (texto.Equals("s") || texto.Equals("n"))
                return true;
            else
            {
                Console.WriteLine(" La entrada debe ser s o n ");
                return false;
            }
        }



        public bool tipoNum(string texto)
        {
            Regex regla = new Regex("[0-9]{1,9}(\\.[0-9]{0,2})?$");

            if (regla.IsMatch(texto))
                return true;
            else
            {
                Console.SetCursorPosition(55, 25); Console.WriteLine("Por favor introducir solo numeros");
                return false;
            }
        }




        public bool tipoText(string texto)
        {
            Regex regla = new Regex("^[a-zA-Z ]*$");

            if (regla.IsMatch(texto))
                return true;
            else
            {
                Console.SetCursorPosition(55, 25); Console.WriteLine("Escribir Solo en Texto");
                return false;
            }

        }

        public bool tipoMail(string texto)
        {
            Regex regla = new Regex("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*");
            if (regla.IsMatch(texto))
                return true;
            else
            {
                Console.SetCursorPosition(55, 25); Console.WriteLine("Ingresar una dirección de correo valida");
                return false;
            }
        }
    }
}
