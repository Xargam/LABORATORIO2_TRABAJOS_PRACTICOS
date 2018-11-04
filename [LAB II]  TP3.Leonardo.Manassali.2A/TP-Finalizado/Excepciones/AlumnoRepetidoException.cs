using System;
using System.Collections.Generic;
using System.Text;

namespace Excepciones
{
	public class AlumnoRepetidoException : Exception
	{
		#region Constructor
		public AlumnoRepetidoException() : base("Alumno repetido.")
		{
		}
		#endregion
	}
}
