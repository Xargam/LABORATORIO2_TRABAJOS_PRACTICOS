using System;
using System.IO;
using Excepciones;

namespace Archivos
{
	public class Texto : IArchivo<string>
	{
		#region MetodosIArchivo
		public bool Guardar(string archivo, string datos)
		{
			try
			{
				using (StreamWriter textArch = new StreamWriter(archivo))
				{
					textArch.WriteLine(datos);
				}
			}
			catch (Exception e)
			{
				throw new ArchivosException(e);
			}
			return true;
		}
		public bool Leer(string archivo, out string datos)
		{
			datos = "";
			try
			{
				using (StreamReader textArch = new StreamReader(archivo))
				{
					datos = textArch.ReadToEnd();
				}
			}
			catch (Exception e)
			{
				throw new ArchivosException(e);
			}
			return true;
		} 
		#endregion
	}
}
