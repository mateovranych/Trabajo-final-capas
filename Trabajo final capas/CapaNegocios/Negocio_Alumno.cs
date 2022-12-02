using CapaDatos;
using CapaNegocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaNegocios
{
    public class Negocio_Alumno
    {
        //Método para listar alumnos
        public static DataTable Listar()
        {
            //Generar una instancia a la clase Datos_Alumnos
            Datos_Alumno datos = new Datos_Alumno();
            return datos.Listar();
        }
        //Método para buscar a los alumnos
        public static DataTable Buscar(string valor)
        {
            Datos_Alumno datos = new Datos_Alumno();
            return datos.Buscar(valor);
        }
        //Método para insertar los alumnos
        public static string Insertar(string Nombre, String Apellido,int Edad)
        {
            //1-Realizo la referencia hacia la clase Datos_Alumnos y la clase Alumno
            Datos_Alumno datos = new Datos_Alumno();
            Alumno obj = new Alumno(); //Me conecto a la clase entidad
            //2-La informacion de las variables del método insertar de la capa negocios debo
            //asignarlo a las variables de la clase alumno
            obj.Nombre = Nombre;
            obj.Apellido = Apellido;
            obj.Edad = Edad;
            return datos.Insertar(obj);


        }

        //Método para actualizar a los alumnos
        public static string Actualizar(int Id,string Nombre, String Apellido, int Edad)
        {          
            Datos_Alumno datos = new Datos_Alumno();
            Alumno obj = new Alumno(); 
            obj.Id = Id;
            obj.Nombre = Nombre;
            obj.Apellido = Apellido;
            obj.Edad = Edad;
            return datos.Actualizar(obj);
        }

        //Método para eliminar a los alumnos
        public static string Eliminar(int Id)
        {
            Datos_Alumno datos = new Datos_Alumno();
            return datos.Eliminar(Id);
        }
        //Método para activar los alumnos
        public static string Activar(int Id)
        {
            Datos_Alumno datos = new Datos_Alumno();
            return datos.Activar(Id);
        }
        //Método para desactivar a los alumnos
        public static string Desactivar(int Id)
        {
            Datos_Alumno datos = new Datos_Alumno();
            return datos.Desactivar(Id);
        }
    }
}
