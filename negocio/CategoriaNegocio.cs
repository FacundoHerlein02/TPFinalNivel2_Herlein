using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class CategoriaNegocio
    {
        AccesoDatos datos;
        public List<Categoria> listar()
        {
            List<Categoria> ListaCategorias = new List<Categoria>();
            try
            {
                datos = new AccesoDatos();
                datos.SetearConsulta("Select Id,Descripcion from CATEGORIAS");
                datos.EjecutarLectura();
                while(datos.Lector.Read())
                { 
                    Categoria aux= new Categoria();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion=(string)datos.Lector["Descripcion"];
                    ListaCategorias.Add(aux);
                }
                return ListaCategorias;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
