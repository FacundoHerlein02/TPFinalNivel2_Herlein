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
                string consulta = "Select A.Id,Codigo,Nombre,A.Descripcion ,M.Descripcion Marca,M.Id idMarca,C.Descripcion Categoría,C.Id idCategoria,ImagenUrl,Precio from ARTICULOS A,MARCAS M,CATEGORIAS C where A.IdMarca=M.Id And A.IdCategoria=C.Id";
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
                    aux.Marca.Id = (int)datos.Lector["idMarca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Descripcion=datos.Lector["Categoría"].ToString();
                    aux.Categoria.Id = (int)datos.Lector["idCategoria"];

                    //Si no es null lee la imagen
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["ImagenUrl"];
                    if(!(datos.Lector["Precio"] is DBNull))
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
        public void Agregar(Articulo NewArt)
        {
            datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("Insert Into ARTICULOS (Codigo,Nombre,Descripcion,IdMarca,IdCategoria,ImagenUrl,Precio) values(@codigo,@nombre,@descripcion,@idMarca,@idCategoria,@imagen,@precio)");
                datos.SetearParametros("@codigo",NewArt.Codigo);
                datos.SetearParametros("@nombre",NewArt.Nombre);
                datos.SetearParametros("@descripcion",NewArt.Descripcion);
                datos.SetearParametros("@idMarca",NewArt.Marca.Id);
                datos.SetearParametros("@idCategoria",NewArt.Categoria.Id);
                datos.SetearParametros("@imagen",NewArt.UrlImagen);
                datos.SetearParametros("@precio",NewArt.Precio);
                datos.EjecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.CerrarConexion();
            }
          
        }

        public List<Articulo> filtrar(string campo,string criterio, string filtro)
        {
            datos = new AccesoDatos();
            List<Articulo> lista=new List<Articulo>();
            string consulta = "Select A.Id,Codigo,Nombre,A.Descripcion ,M.Descripcion Marca,M.Id idMarca,C.Descripcion Categoría,C.Id idCategoria,ImagenUrl,Precio from ARTICULOS A,MARCAS M,CATEGORIAS C where A.IdMarca=M.Id And A.IdCategoria=C.Id And ";
            string CampoDB;
            try
            {
                if(String.IsNullOrEmpty(filtro))
                {
                    lista = listar(); //Lista sin filtrar
                }
                else
                {
                    switch (campo)
                    {
                        case "Categoría":
                            CampoDB = "C.Descripcion";
                            consulta = ValidarTexto(CampoDB, consulta, criterio, filtro);
                            break;
                        case "Código":
                            CampoDB = "Codigo";
                            consulta = ValidarTexto(CampoDB, consulta, criterio, filtro);
                            break;
                        case "Marca":
                            CampoDB = "M.Descripcion";
                            consulta = ValidarTexto(CampoDB, consulta, criterio, filtro);
                            break;
                        case "Nombre":
                            CampoDB = "Nombre";
                            consulta = ValidarTexto(CampoDB, consulta, criterio, filtro);
                            break;
                        case "Precio":
                            CampoDB = "Precio";
                            consulta = ValidarTexto(CampoDB, consulta, criterio, filtro);
                            break;
                    }

                    datos.SetearConsulta(consulta);
                    datos.EjecutarLectura();
                    while (datos.Lector.Read())
                    {
                        Articulo aux = new Articulo();
                        aux.Id = (int)datos.Lector["Id"];
                        aux.Codigo = datos.Lector["Codigo"].ToString();
                        aux.Nombre = datos.Lector["Nombre"].ToString();
                        aux.Descripcion = datos.Lector["Descripcion"].ToString();

                        aux.Marca = new Marca();
                        aux.Marca.Descripcion = datos.Lector["Marca"].ToString();
                        aux.Marca.Id = (int)datos.Lector["idMarca"];
                        aux.Categoria = new Categoria();
                        aux.Categoria.Descripcion = datos.Lector["Categoría"].ToString();
                        aux.Categoria.Id = (int)datos.Lector["idCategoria"];
                        if(!(datos.Lector["ImagenUrl"] is DBNull))
                            aux.UrlImagen = (string)datos.Lector["ImagenUrl"];
                        if (!(datos.Lector["Precio"] is DBNull))
                            aux.Precio = float.Parse(datos.Lector["Precio"].ToString());
                        //Añade a la lista
                        lista.Add(aux);
                    }
                }                
                return lista;
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
        private string ValidarTexto(string campoDB,string consulta,string criterio,string filtro)
        {
            if(campoDB=="Precio")
            {
                string filtroMondea = filtro.Replace(",", ".");
                switch(criterio)
                {
                    
                    case "Mayor a":
                        consulta += "Round(" + campoDB + ",2)" + " > " + filtroMondea;
                        break;
                    case "Menor a":
                        consulta += "Round(" + campoDB + ",2)" + " < " + filtroMondea;
                        break;
                    case "Igual a":
                        consulta += "Round("+campoDB+",2)" + "=" + filtroMondea;
                        break;
                }
            }
            else
            {
                switch (criterio)
                {
                    case "Comienza con":
                        consulta += campoDB + " Like '" + filtro + "%'";
                        break;
                    case "Termina con":
                        consulta += campoDB + " Like '%" + filtro + "'";
                        break;
                    case "Contiene":
                        consulta += campoDB + " Like '%" + filtro + "%'";
                        break;
                }
            }
                        
            return consulta;
        }
        public void modificar(Articulo articulo)
        {
            datos= new AccesoDatos();
            try
            {
                datos.SetearConsulta("Update ARTICULOS Set Codigo=@codigo ,Nombre=@nombre,Descripcion=@descripcion,IdMarca=@idMarca,IdCategoria=@idCategoria,ImagenUrl=@imagen,Precio=@precio Where Id=@id");
                datos.SetearParametros("@codigo",articulo.Codigo);
                datos.SetearParametros("@nombre",articulo.Nombre);
                datos.SetearParametros("@descripcion",articulo.Descripcion);
                datos.SetearParametros("@idMarca",articulo.Marca.Id);
                datos.SetearParametros("@idCategoria",articulo.Categoria.Id);
                datos.SetearParametros("@imagen",articulo.UrlImagen);
                datos.SetearParametros("@precio",articulo.Precio);
                datos.SetearParametros("@id",articulo.Id);
                datos.EjecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
        public void eliminar(int id)
        {
            datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("Delete ARTICULOS where Id=@id");
                datos.SetearParametros("@id",id);
                datos.EjecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}
