using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        #region Atributos
        private double numero;
        #endregion

        #region Propiedades
        /// <summary>
        /// Establece un numero en el atributo numero si y solo si la cadena que lo representa es transformable a double, 
        /// caso contrario asigna 0.
        /// </summary>
        private string SetNumero
        {
            set
            {
                this.numero = this.ValidarNumero(value);
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Genera una instancia de la clase Numero inicializada en 0.
        /// </summary>
        public Numero() : this(0)
        {
        }
        /// <summary>
        /// Genera una instancia de la clase Numero.
        /// </summary>
        /// <param name="numero">Numero en formato Double para inicializar la instancia.</param>
        public Numero(double numero) : this(numero.ToString())
        {
        }
        /// <summary>
        /// Genera una instancia de la clase Numero.
        /// </summary>
        /// <param name="strNumero">Numero en formato string para inicializar instancia.</param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Realiza una resta entre los numeros que almacenan dos instancias de Numero y 
        /// devuelve un double con el resultado.
        /// </summary>
        /// <param name="n1">Numero 1.</param>
        /// <param name="n2">Numero 2.</param>
        /// <returns>Devuelve un numero en formato double.</returns>
        public static double operator -(Numero n1 , Numero n2 )
        {
            return (n1.numero - n2.numero);
        }
        /// <summary>
        /// Realiza una suma entre los numeros que almacenan dos instancias de Numero y
        /// devuelve un double con el resultado.
        /// </summary>
        /// <param name="n1">Numero 1.</param>
        /// <param name="n2">Numero 2.</param>
        /// <returns>Devuelve un numero en formato double.</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return (n1.numero + n2.numero);
        }
        /// <summary>
        /// Realiza una multiplicacion entre los numeros que almacenan dos instancias de Numero y
        /// devuelve un double con el resultado.
        /// </summary>
        /// <param name="n1">Numero 1.</param>
        /// <param name="n2">Numero 2.</param>
        /// <returns>Devuelve un numero en formato double.</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return (n1.numero * n2.numero);
        }
        /// <summary>
        /// Realiza una division entre los numeros que almacenan dos instancias de Numero y
        /// devuelve un double con el resultado.
        /// </summary>
        /// <param name="n1">Numero 1.</param>
        /// <param name="n2">Numero 2.</param>
        /// <returns>Devuelve un numero en formato double.</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            return (n1.numero / n2.numero);
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Verifica que un numero en formato string puedan ser transformado a double y lo devuelve. 
        /// Caso contrario retorna 0.
        /// </summary>
        /// <param name="strNumero">Numero en formato string a verificar.</param>
        /// <returns>Devuelve un numero en formato double.</returns>
        private double ValidarNumero(string strNumero)
        {
            Double.TryParse(strNumero, out double resultado);
            return resultado;
        }
        /// <summary>
        /// Convierte la parte entera y postiva de un numero binario en formato string a un numero decimal y lo devuelve
        /// como string , caso contrario retorna "Valor invalido".
        /// </summary>
        /// <param name="binario">Numero binario a convertir a decimal.</param>
        /// <returns>Devuelve un numero de base 10 en formato string.</returns>
        public string BinarioDecimal(string binario)
        {
            string resultado = "Valor inválido";
            
            if (double.TryParse(binario,out double numDecimal ))
            {
                numDecimal = 0;
                //Preparo al metodo para recibir numeros con puntos y no fallar.
                binario = binario.Replace(".", "");
                binario = binario.Replace("-", "");
                binario = (binario.Contains(',')) ? binario.Remove(binario.IndexOf(',')) : binario;
                /*Primero se elimina la parte no entera del binario y luego evaluo si solo tiene unos y ceros para
                para cumplir con "Los métodos BinarioDecimal y DecimalBinario trabajaran con enteros positivos, 
                quedándose para esto con el valor absoluto y entero".*/
                if (binario.Trim('1','0') == string.Empty)
                {
                    for (int i = 0; i < binario.Length; i++)
                    {
                        numDecimal += Convert.ToDouble(binario[i].ToString()) * Math.Pow(2, binario.Length - 1 - i);
                    }
                    resultado = numDecimal.ToString();
                }
            }
            return resultado;
        }
        /// <summary>
        /// Convierte la parte entera y postiva de un numero decimal en formato double a un numero binario y lo devuelve
        /// como string , caso contrario retorna "Valor invalido".
        /// </summary>
        /// <param name="numero">Numero decimal en formato double a convertir a binario.</param>
        /// <returns>Devuelve un numero de base 2 en formato string.</returns>
        public string DecimalBinario(double numero)
        {
            return this.DecimalBinario(numero.ToString());
        }
        /// <summary>
        /// Convierte la parte entera y postiva de un numero decimal en formato string a un numero binario y lo devuelve
        /// como string , caso contrario retorna "Valor invalido".
        /// </summary>
        /// <param name="numero">Numero decimal en formato string a convertir a binario.</param>
        /// <returns>Devuelve un numero de base 2 en formato string.</returns>
        public string DecimalBinario(string numero)
        {
            string binario = "Valor inválido";
            if ( double.TryParse(numero , out double numDecimal ) )
            {
                numDecimal = Math.Abs(Math.Truncate(numDecimal));
                binario = (numDecimal == 0 )? "0": "";
                while (numDecimal > 0)
                {
                    binario = (numDecimal % 2) + binario;
                    numDecimal = Math.Truncate(numDecimal / 2);
                }
            }
            return binario;
        }
        #endregion
    }
}
