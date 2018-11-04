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
		[TestMethod]
		public void TestMethod1()
		{
			try
			{
				Profesor uni;
				Console.WriteLine(10 + null); 
			}
			catch (Exception)
			{
				Assert.Fail();
			}
			
			
		}
	}
}
