using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumnos
{
    public class AdmAlumno
    {
        public bool Crear(EAlumno eAlumno)
        {   
            if (!string.IsNullOrEmpty(eAlumno.Rut)&&!string.IsNullOrEmpty(eAlumno.Nombre)&&!string.IsNullOrEmpty(eAlumno.Apellidos)&&(eAlumno.Edad > 0 && eAlumno.Edad < 110)&&(eAlumno.Sexo > 0 && eAlumno.Sexo <= 2))
            {
                RepositorioAlumno.listaAlumnos.Add(eAlumno);
               
                return true;
            }
            else
            {

                return false;
            }
           
        }

        public EAlumno Buscar(String rut)

        {


          

                EAlumno Ealumno = RepositorioAlumno.listaAlumnos.Find(u => u.Rut == rut);

            return Ealumno;


        }

     


        public bool Actualizar(EAlumno eAlumno)
        {
            var rut = Buscar(eAlumno.Rut);
         
      

            if (!string.IsNullOrEmpty(eAlumno.Rut) 
                && !string.IsNullOrEmpty(eAlumno.Nombre) 
                && !string.IsNullOrEmpty(eAlumno.Apellidos)
                && (eAlumno.Edad > 0 && eAlumno.Edad < 110) 
                && (eAlumno.Sexo > 0 && eAlumno.Sexo <= 2) 
                )
            {
                var index = RepositorioAlumno.listaAlumnos.IndexOf(rut);
                RepositorioAlumno.listaAlumnos[index] = eAlumno;

                RepositorioAlumno.listaAlumnos[RepositorioAlumno.listaAlumnos
                                            .FindIndex(u => u.Rut == rut.Rut)] = eAlumno;
                // valida que el rut sea el mismo .. si es false en home controller dara una excepcion
                //que no esta en la regla de validacion
                return true;
            }

            return false;
        }

        //ELIMINA UN ID DE LA LISTA DE ALUMNO
        public bool Eliminar(string id)
        {
            EAlumno rut = Buscar(id);
            if (rut != null) //vuelvo a validar un dato null
            {
                RepositorioAlumno.listaAlumnos.Remove(rut);
                return true;
             
            }

            else
            {
                return false;
            }
        }

        public List<EAlumno> Mostrar()
        {
            return RepositorioAlumno.listaAlumnos;
        }

    }
}
