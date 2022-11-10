using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Inscripcion
    {
        public Profesion Profe { get; set; }
        public Experiencia Exp { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string BonoExp { get; set; }
        public string BonoEdad { get; set; }
        public int AñoActual { get; set; }
        public int Edad { get; set; }
        public double Sueldo { get; set; }
        public override string ToString()
        {
            return this.Nombre + " \n" + this.Edad +" \n"+ this.Profe +" \n"+ this.Exp +" \n"+ this.BonoExp +" \n"+ this.BonoEdad +" \n"+ this.Sueldo;
        }
    }
    }

