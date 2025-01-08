using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class ArticuloNegocio
    {
        private AccesoDatos datos;
        //Lista los articulos y devuelve una lista
        public List<Articulo> listar()
        {
            List<Articulo> listaArticulos = new List<Articulo>();
            datos = new AccesoDatos();
            try
            {
                string consulta = "Select A.Id,Codigo,Nombre,A.Descripcion ,M.Descripcion Marca,C.Descripcion Categoría,ImagenUrl,Precio from ARTICULOS A,MARCAS M,CATEGORIAS C where A.IdMarca=M.Id And A.IdCategoria=C.Id";
                datos.SetearConsulta(consulta);
                datos.EjecutarLectura();
                while(datos.Lector.Read())
                {
                    Articulo aux= new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = datos.Lector["Codigo"].ToString();
                    aux.Nombre= datos.Lector["Nombre"].ToString();
                    aux.Descripcion= datos.Lector["Descripcion"].ToString();

                    aux.Marca= new Marca();
                    aux.Marca.Descripcion = datos.Lector["Marca"].ToString();
                    aux.Categoria = new Categoria();
                    aux.Categoria.Descripcion=datos.Lector["Categoría"].ToString();
                    
                    aux.UrlImagen = (string)datos.Lector["ImagenUrl"];
                    aux.Precio = float.Parse(datos.Lector["Precio"].ToString());
                    //Añade a la lista
                    listaArticulos.Add(aux);
                }
                return listaArticulos;
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
