using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using Excepciones;

namespace Archivos
{
	public class Xml<T> : IArchivo<T>
	{
		#region MetodosIArchivo
		public bool Guardar(string archivo, T datos)
		{
			try
			{
				using (StreamWriter stremWriter = new StreamWriter(archivo))
				{
					XmlSerializer xml = new XmlSerializer(typeof(T));
					xml.Serialize(stremWriter, datos);
				}
			}
			catch (Exception e )
			{
				throw new ArchivosException(e);
			}
			return true;
		}
		public bool Leer(string archivo, out T datos)
		{
			try
			{
				using (StreamReader stremWriter = new StreamReader(archivo))
				{
					XmlSerializer xml = new XmlSerializer(typeof(T));
					datos = (T)xml.Deserialize(stremWriter);
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
