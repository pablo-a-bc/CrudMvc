using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumnos
{
  public  class EAlumno
    {
        //valido con datanottation tanto el negocio y el modelo
        [Required(ErrorMessage = "Rut es obligatorio")]
        public string Rut { get; set; }
        [Required(ErrorMessage = "Nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Apellido es obligatorio")]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "Edad es obligatoria")]
        [Range(1, 109, ErrorMessage = "La edad debe ser entre 1 y 109")]
        public int Edad { get; set; }
        [Required(ErrorMessage = "Sexo es obligatoria")]
        [Range(1, 2, ErrorMessage = " 1 masculino 2 femenino , ninguno más")]
        public int Sexo { get; set; }
    }
}
