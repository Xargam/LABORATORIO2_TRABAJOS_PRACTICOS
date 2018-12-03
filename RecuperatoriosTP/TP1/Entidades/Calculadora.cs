namespace Entidades
{
    public static class Calculadora
    {
        #region Metodos
        /// <summary>
        /// Realiza una de las cuatro operaciones aritméticas entre dos objetos Numero y devuelve el resultado como double.
        /// Si el operador no es (+ , - , * ó /) realizará la operación por defecto (SUMA).
        /// </summary>
        /// <param name="num1">Operando 1.</param>
        /// <param name="num2">Operando 2.</param>
        /// <param name="operador">Operador aritmético en formato string.</param>
        /// <returns>Devuelve un valor de tipo double o double.minValue en caso de division por 0.</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0;
            operador = Calculadora.ValidarOperador(operador);
            if ( !object.Equals(null,num1) && !object.Equals(null, num2))
            {
                switch (operador)
                {
                    case "+":
                        resultado = num1 + num2;
                        break;
                    case "-":
                        resultado = num1 - num2;
                        break;
                    case "*":
                        resultado = num1 * num2;
                        break;
                    case "/":
                        resultado = (num2 * new Numero(1) == 0)? double.MinValue : num1 / num2;
                        break;
                }
            }
            return resultado;
        }
        /// <summary>
        /// Verifica que un string contenga un operador aritmético válido para una de las cuatro operaciones básicas:
        /// (+,-,*,/) y retorna dicho operador. En caso de error devuelve "+" (Operador por defecto).
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>Devuelve un valor de tipo string.</returns>
        private static string ValidarOperador(string operador)
        {
            return (operador != "+" && operador != "-" && operador != "*" && operador != "/") ? "+" : operador;
        }
        #endregion
    }
}
