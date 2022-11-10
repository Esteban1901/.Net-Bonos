using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace BLL
{
    public class InscripcionBLL
    {
        List<Inscripcion> inscripciones = new List<Inscripcion>();

        //CRUD
        public void Add(Inscripcion inscripcion)
        {
            inscripciones.Add(inscripcion);
        }
        public List<Inscripcion> GetAll()
        {
            return inscripciones;
        }
    }
}
