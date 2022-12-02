using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; //ME PERMITE UTILIZAR EL METODO DATATABLE
using System.Data.SqlClient; //PARA UTILIZAR EL SQL
using CapaEntidad; //PARA USAR LA CAPA ENTIDAD

namespace CapaDatos
{
    public class Datos_Alumno
    {
        //METODOS PARA LISTAR LOS ELEMENTOS DE LA TABLA ALUMNO
        public DataTable Listar()
        {
            SqlDataReader resultado; //ESTE ELEMENTO NOS PERMITE LEER UNA SECUENCIA DE FILAS EN UNA TABLA DENTRO DEL SQL
            DataTable Tabla = new DataTable();
            SqlConnection conexion = new SqlConnection();
            try 
            {
                conexion = Conexion.crearInstancia().crearConexion();
                SqlCommand comando = new SqlCommand("listar_alumno", conexion);
                comando.CommandType= CommandType.StoredProcedure; //ES UN PROCEDIMIENTO DE ALMACENADO
                conexion.Open();
                resultado = comando.ExecuteReader();
                Tabla.Load(resultado); 
                return Tabla;

            }
            catch(Exception ex) //CONTROLA LOS ERROES
            {
                throw ex;
            }
            finally //ME VA A SERVIR PARA CERRAR LA CONEXION
            {
                if(conexion.State == ConnectionState.Open) conexion.Close(); //CERRAMOS LA CONEXION 

            }

        }

        //Metodo para buscar alumnos
        public DataTable Buscar(string valor)
        {
            SqlDataReader resultado; //ESTE ELEMENTO NOS PERMITE LEER UNA SECUENCIA DE FILAS EN UNA TABLA DENTRO DEL SQL
            DataTable Tabla = new DataTable();
            SqlConnection conexion = new SqlConnection();
            try 
            {
                conexion = Conexion.crearInstancia().crearConexion();
                SqlCommand comando = new SqlCommand("buscar_alumno", conexion);
                comando.CommandType = CommandType.StoredProcedure; //ES UN PROCEDIMIENTO DE ALMACENADO
                comando.Parameters.Add("@Valor", SqlDbType.VarChar).Value = valor; //ACA LE VOY A MANDAR EL PROCEDIMIENTO ALMACENADO
                conexion.Open();
                resultado = comando.ExecuteReader();
                Tabla.Load(resultado); 
                return Tabla;

            }
            catch (Exception ex) //CONTROLA LOS ERROES
            {
                throw ex;
            }
            finally //ME VA A SERVIR PARA CERRAR LA CONEXION
            {
                if (conexion.State == ConnectionState.Open) conexion.Close(); //CERRAMOS LA CONEXION 

            }
        }

        //Metodo para insertar alumnos
        public string Insertar(Alumno obj)
        {
            string respuesta = "";
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion = Conexion.crearInstancia().crearConexion();
                SqlCommand comando = new SqlCommand("insertar_alumno", conexion);
                comando.CommandType = CommandType.StoredProcedure; //ES UN PROCEDIMIENTO DE ALMACENADO
                comando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = obj.Nombre;
                comando.Parameters.Add("@Apellido", SqlDbType.VarChar).Value = obj.Apellido;
                comando.Parameters.Add("@Edad", SqlDbType.Int).Value = obj.Edad;//ACA LE VOY A MANDAR EL PROCEDIMIENTO ALMACENADO
                conexion.Open();
                respuesta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo ingresar el registro del alumno";            

            }
            catch (Exception ex) //CONTROLA LOS ERROES
            {
                respuesta =  ex.Message;
            }
            finally //ME VA A SERVIR PARA CERRAR LA CONEXION
            {
                if (conexion.State == ConnectionState.Open) conexion.Close(); //CERRAMOS LA CONEXION 

            }
            return respuesta; 

        }
        //Metodo para actualizar los datos del alumnos
        public string Actualizar(Alumno obj)
        {
            string respuesta = "";
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion = Conexion.crearInstancia().crearConexion();
                SqlCommand comando = new SqlCommand("actualizar_alumno", conexion);
                comando.CommandType = CommandType.StoredProcedure; //ES UN PROCEDIMIENTO DE ALMACENADO
                comando.Parameters.Add("@Id", SqlDbType.Int).Value = obj.Id;
                comando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = obj.Nombre;
                comando.Parameters.Add("@Apellido", SqlDbType.VarChar).Value = obj.Apellido;
                comando.Parameters.Add("@Edad", SqlDbType.Int).Value = obj.Edad;//ACA LE VOY A MANDAR EL PROCEDIMIENTO ALMACENADO
                conexion.Open();

                respuesta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo actualizar el registro del alumno";

            }
            catch (Exception ex) //CONTROLA LOS ERROES
            {
                respuesta = ex.Message;
            }
            finally //ME VA A SERVIR PARA CERRAR LA CONEXION
            {
                if (conexion.State == ConnectionState.Open) conexion.Close(); //CERRAMOS LA CONEXION 

            }
            return respuesta;
        }

        //Metodo par eliminar los registros de los alumnos
        public string Eliminar(int Id)
        {
            string respuesta = "";
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion = Conexion.crearInstancia().crearConexion();
                SqlCommand comando = new SqlCommand("eliminar_alumno", conexion);
                comando.CommandType = CommandType.StoredProcedure; //ES UN PROCEDIMIENTO DE ALMACENADO
                comando.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
                conexion.Open();

                respuesta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo eliminar el registro del alumno";

            }
            catch (Exception ex) //CONTROLA LOS ERROES
            {
                respuesta = ex.Message;
            }
            finally //ME VA A SERVIR PARA CERRAR LA CONEXION
            {
                if (conexion.State == ConnectionState.Open) conexion.Close(); //CERRAMOS LA CONEXION 

            }
            return respuesta;
        }
        //Metodo para activar el registro del alumno
        public string Activar(int Id)
        {
            string respuesta = "";
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion = Conexion.crearInstancia().crearConexion();
                SqlCommand comando = new SqlCommand("activar_alumno", conexion);
                comando.CommandType = CommandType.StoredProcedure; //ES UN PROCEDIMIENTO DE ALMACENADO
                comando.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
                conexion.Open();

                respuesta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo activar el registro del alumno";

            }
            catch (Exception ex) //CONTROLA LOS ERROES
            {
                respuesta = ex.Message;
            }
            finally //ME VA A SERVIR PARA CERRAR LA CONEXION
            {
                if (conexion.State == ConnectionState.Open) conexion.Close(); //CERRAMOS LA CONEXION 

            }
            return respuesta;   
        }
        //Metodo para desactivar el id del alumno
        public string Desactivar(int Id)
        {
            string respuesta = "";
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion = Conexion.crearInstancia().crearConexion();
                SqlCommand comando = new SqlCommand("desactivar_alumno", conexion);
                comando.CommandType = CommandType.StoredProcedure; //ES UN PROCEDIMIENTO DE ALMACENADO
                comando.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
                conexion.Open();

                respuesta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo desactivar el registro del alumno";

            }
            catch (Exception ex) //CONTROLA LOS ERROES
            {
                respuesta = ex.Message;
            }
            finally //ME VA A SERVIR PARA CERRAR LA CONEXION
            {
                if (conexion.State == ConnectionState.Open) conexion.Close(); //CERRAMOS LA CONEXION 

            }
            return respuesta;
        }

    }
    
}
