using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Alumno
    {
        //Se podia encapsular en esta ocasión pero por error del código lo hice directamente
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public bool Estado { get; set; }
        //sirven para enviar y recibir información
    }
}
