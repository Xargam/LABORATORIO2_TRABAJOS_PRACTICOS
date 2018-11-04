using Excepciones;
using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
	public class Xml<T> : IArchivo<T>
	{
		#region MetodosIArchivo
		public bool Guardar(string archivo, T datos)
		{
			try
			{
				XmlTextWriter xmlTextWriter = new XmlTextWriter(archivo, Encoding.UTF8);
				XmlSerializer serializer = new XmlSerializer(typeof(T));
				serializer.Serialize(xmlTextWriter, datos);
				xmlTextWriter.Close();
			}
			catch (Exception e)
			{
				throw new ArchivosException(e);
			}
			return true;
		}
		public bool Leer(string archivo, out T datos)
		{
			try
			{
				XmlTextReader xmlTextReader = new XmlTextReader(archivo);
				XmlSerializer DeSerializer = new XmlSerializer(typeof(T));
				datos = (T)DeSerializer.Deserialize(xmlTextReader);
				xmlTextReader.Close();
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
