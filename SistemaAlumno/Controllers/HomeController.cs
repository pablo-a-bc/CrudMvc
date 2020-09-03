using Alumnos;
using SistemaAlumno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaAlumno.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
            // return RedirectToAction("Index");
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(Alumno dato)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                { 
                AdmAlumno admAlumno = new AdmAlumno();
                EAlumno eAlumno = new EAlumno()
                {
                    Rut = dato.Rut,
                    Nombre = dato.Nombre,
                    Apellidos = dato.Apellidos,
                    Edad = dato.Edad,
                    Sexo = dato.Sexo



                };
                   if(admAlumno.Crear(eAlumno))
                    {
                        return View("Guardado");

                    }

                   
                    
                }
                else
                {
                    ViewBag.Mensaje = " ALUMNO NO INGRESADO (REVISE ADVERTENCIAS) ";
                }
                return View();

                
            }
            catch
            {

                
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(string id)
        {
            AdmAlumno admAlumno = new AdmAlumno();
            EAlumno alumno = admAlumno.Buscar(id);
            
            return View(alumno);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(Alumnos.EAlumno eAlumno)
        {

           
                try
            {
                // TODO: Add update logic here
                AdmAlumno admAlumno = new AdmAlumno();
              
                bool esAct = admAlumno.Actualizar(eAlumno);
                if(esAct)
                {
                    return View("Editado");
                
                }
                else
                {
                    
                    return View(eAlumno);
                    
                }
                
            
                }
            catch
            {
                ViewBag.Mensaje = "Error : Rut no puede ser cambiado es el id ";
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(string id)
        {
            
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, EAlumno eAlumno)
        {
            try
            {
                // TODO: Add update logic here
                AdmAlumno admAlumno = new AdmAlumno();
                EAlumno alumno = admAlumno.Buscar(id);

                bool borrarlo = admAlumno.Eliminar(id);
                if (borrarlo)
                {
                    return View("Borrado");
                }
                else
                {
                    return View();

                }

            }
            catch
            {
                return View();
            }
        }

        public ActionResult Buscar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Buscar(Alumnos.EAlumno eAlumno)
        {

           
            AdmAlumno admAlumno = new AdmAlumno();
            EAlumno alumno = admAlumno.Buscar(eAlumno.Rut);
              if (alumno != null)
                    {
         
            return View("Encontrado",alumno);
                }
              else
            {
               
                return View("NoFound");
                
            }

           
           



        }

        public ActionResult Encontrado()

        {  
                return View();

          
        }


        public ActionResult Mostrar()
        {
            AdmAlumno adm = new AdmAlumno();
            return View(adm.Mostrar());

        }
    }

    
}
