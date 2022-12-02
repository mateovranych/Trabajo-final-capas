using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; //agregando la libreria necesaria para poder trabajar con los metodos del SQL

namespace CapaDatos
{
    internal class Conexion
    {
        //DELCARAMOS LAS VARIABLES
        private string Base;
        private string Servidor;
        private bool Seguridad; //nos permitira establecer el metodo de autenticacion de windows para conectarnos a SQL
        private static Conexion con = null; //Estoy creando un objeto de tipo conexion

        public Conexion()
        {
            this.Base = "Datos";
            this.Servidor = "MATEO";
            this.Seguridad = true;
            
        }
        //método publico para devolver el string de conexion
        public SqlConnection crearConexion()
        {
            //variable de tipo SQLCONNECTION
            SqlConnection cadena = new SqlConnection();
            try
            {
                //crear cadena de conexion
                cadena.ConnectionString = "Server" + this.Servidor + "; Database=" + this.Base + ";";

            }catch(Exception ex) {
                cadena = null;
                throw ex; // mostramos un mensaje con el error establecido
            
            }
            return cadena;
        }
        public static Conexion crearInstancia()
        {
            if(con == null)
            {
                con = new Conexion();
            }
            return con;
        }

    }
}
