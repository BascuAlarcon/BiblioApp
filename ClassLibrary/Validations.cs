using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BibliotecaEntidades;
using BibliotecaBLL;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace ClassLibrary
{
    public class Validations
    {
        #region variables
          
        #endregion

        #region Methods (public)

        public static bool validarUsuario(string rut, string emailadress, ref bool esValido)
        {
            if (esValido)
            {
                ValidaRut(rut, ref esValido);
            }
            if (esValido)
            {
                IsValid(emailadress, ref esValido);
            }
            if (esValido)
            {
                existenciaUsuario(rut, ref esValido);
            }   
            return esValido;
        }

        /// <summary>
        /// Metodo de validación de rut con digito verificador
        /// dentro de la cadena
        /// </summary>
        /// <param name="rut">string</param>
        /// <returns>booleano</returns> 

        public static bool ValidaRut(string rut, ref bool esValido)
        {
            rut = rut.Replace(".", "").ToUpper();
            Regex expresion = new Regex("^([0-9]+-[0-9K])$");
            string dv = rut.Substring(rut.Length - 1, 1);
            if (!expresion.IsMatch(rut))
            {
                esValido = false;
                return false;
            }
            char[] charCorte = { '-' };
            string[] rutTemp = rut.Split(charCorte);
            if (dv != Digito(int.Parse(rutTemp[0])))
            {
                return false;
            }
            esValido = true;
            return true;
        }

        public static bool IsValid(string emailaddress, ref bool esValido)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                esValido = true;
                return true;
            }
            catch (FormatException)
            {
                esValido = false;
                return false;
            }
        }

        public static bool existenciaUsuario(string rut, ref bool esValido)
        {
            rut = rut.Replace(".", "");
            rut = rut.Replace("-", "");
            int rutInt = Convert.ToInt32(rut);
            UsuarioBLL bll = new UsuarioBLL();
            int id = bll.BuscarExistenciaUsuario(rutInt); 
            if (id > 0)
            {
                esValido = false;
                return true;
            }
            else
            {
                esValido = true;
                return false;
            }
        }

        public static bool BuscarExistenciaCategoria(int id)
        {
            CategoriaBLL bll = new CategoriaBLL();
            return bll.BuscarExistenciaCategoria(id) > 0 ? true : false ;
        }

        public static bool BuscarExistenciaAutor(int id)
        {
            AutorBLL bll = new AutorBLL();
            return bll.BuscarExistenciaAutor(id) > 0 ? true : false;
        }
        
        #endregion

        #region methos (private)

        /// <summary>
        /// método que calcula el digito verificador a partir
        /// de la mantisa del rut
        /// </summary>
        /// <param name="rut"></param>
        /// <returns></returns>
        private static string Digito(int rut)
        {
            int suma = 0;
            int multiplicador = 1;
            while (rut != 0)
            {
                multiplicador++;
                if (multiplicador == 8)
                    multiplicador = 2;
                suma += (rut % 10) * multiplicador;
                rut = rut / 10;
            }
            suma = 11 - (suma % 11);
            if (suma == 11)
            {
                return "0";
            }
            else if (suma == 10)
            {
                return "K";
            }
            else
            {
                return suma.ToString();
            }
        }

        #endregion

    }
}
