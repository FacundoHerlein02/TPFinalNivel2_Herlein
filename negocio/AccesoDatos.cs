using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace negocio
{
    public class AccesoDatos
    {
        //Propiedades
        SqlConnection conexion;
        SqlCommand comando;
        SqlDataReader lector;
        public SqlDataReader Lector
        {
            get { return lector; }
        }
        //Constructor de la clase
        public AccesoDatos()
        {
            //pasa cadena de conexion
            conexion= new SqlConnection("server=(local)\\SQLEXPRESS ;database=CATALOGO_DB ; integrated security= true");
            //Instancia el comando
            comando = new SqlCommand();
        }
        //Configura la consulta a realizar
        public void SetearConsulta(string consulta)
        {
            comando.CommandType= System.Data.CommandType.Text;
            comando.CommandText= consulta;
        }
        //Ejecuta la lectura y la almacena en el dataReader
        public void EjecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();                
                lector=comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void EjecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Añade parametros al comando
        public void SetearParametros(string nombre,object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        public void CerrarConexion()
        {   
            //Cierra el lector
            if(Lector!=null)
            {
                lector.Close();
            }
            //Cierra la conexion
            conexion.Close();
        }

    }
}
