using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Archivos;
using Excepciones;

namespace TestsUnitarios
{
	[TestClass]
	public class ValidacionExcepciones
	{
		/// <summary>
		/// Verifica que la excepción AlumnoRepetidoException sea lanzada correctamente tanto en Jornada como en Universidad.
		/// </summary>
		[TestMethod]
		public void VerificarAlumnoRepetidoException()
		{
		}
		/// <summary>
		/// Verifica que la excepción SinProfesorException sea lanzada correctamente.
		/// </summary>
		[TestMethod]
		public void VerificarSinProfesorException()
		{
		}
		/// <summary>
		/// Verifica que la excepción ArchivosException sea lanzada correctamente en las clases.
		/// </summary>
		[TestMethod]
		public void VerificarArchivosException()
		{
		}
	}
}
