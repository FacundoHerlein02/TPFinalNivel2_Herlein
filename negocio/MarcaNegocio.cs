using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class MarcaNegocio
    {
		AccesoDatos datos;
        public List<Marca> listar()
        {
			datos= new AccesoDatos();
			List<Marca>ListaMarcas= new List<Marca>();
			try
			{
				datos.SetearConsulta("Select Id,Descripcion from MARCAS");
				datos.EjecutarLectura();
				while (datos.Lector.Read())
				{
					Marca aux = new Marca();
					aux.Id = (int)datos.Lector["Id"];
					aux.Descripcion = (string)datos.Lector["Descripcion"];
					ListaMarcas.Add(aux);
				}
				return ListaMarcas;
			}
			catch (Exception ex)
			{

				throw ex;
			}
			finally 
			{
				datos.CerrarConexion();
			}
        }
    }
}
