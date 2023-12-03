using BL;
using Ejercicios.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using UD10.Entities;


namespace Ejercicios.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            SqlConnection connection = new SqlConnection();
            ViewBag.ConnectionState = "No se ha podido conectar";

            try
            {
                connection.ConnectionString = "server=yjimenezdb.database.windows.net;database=yjimenezdb;uid=prueba;pwd=fernandoG321;trustServerCertificate=true";
                connection.Open();
                ViewBag.ConnectionState = $"Conectado: {connection.State}";
            }
            catch (Exception ex)
            {
                ViewBag.ConnectionState = $"Error al conectar: {ex.Message}";
            }

            return View();
        }



        public ActionResult Listado()
        {
            try
            {
                return View(clsListadoPersonasNombreDepartamento.ListadoPersonas);
            }
            catch (SqlException ex)
            {
                ViewBag.Error = "Ha ocurrido un error al conectar con la BBDD. Vuelve a intentarlo más tarde";
                return View("Error");

            }
            catch (Exception ex)
            {
                ViewBag.Error = "Ha ocurrido un error de lógica";
                return View("Error");
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                return View(ListaPersonasBL.getPersonaIdBL(id));
            }
            catch (SqlException ex)
            {
                ViewBag.Error = "Ha ocurrido un error al conectar con la BBDD. Vuelve a intentarlo más tarde";
                return View("Error");
            }

        }

        [ActionName("Delete")]
        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            try
            {   
                int numeroFilas = HandlerPersonaBL.deletePersonaBL(id);
                if (numeroFilas == 0)
                {
                    ViewBag.Info = "No existe esa persona";
                }
                else if (numeroFilas == -1)
                {
                    ViewBag.Info = "Hoy es martes, por lo tanto no se puede borrar ninguna persona";
                }
                else
                {
                    ViewBag.Info = "La persona se ha borrado correctamente";
                }

                return View("Listado", clsListadoPersonasNombreDepartamento.ListadoPersonas);
            }
            catch
            {
                ViewBag.Error = "Ha ocurrido un error al conectar con la BBDD";
                return View("Error");
            }
        }

        public ActionResult Edit(int id)
        {
            try {
                return View(ListaPersonasBL.getPersonaIdBL(id));
            }
            catch (SqlException ex)
            {
                ViewBag.Error = "Ha ocurrido un error al conectar con la BBDD. Vuelve a intentarlo más tarde";
                return View("Error");
            }
        }

        [ActionName("Edit")]
        [HttpPost]
        public ActionResult EditPost(clsPersona per)
        {
            try
            {
                int numeroFilas = HandlerPersonaBL.editPersonaBL(per);

                if (numeroFilas == 0)
                {
                    ViewBag.Info = "No existe esa persona";
                } else
                {
                    ViewBag.Info = "La persona se ha borrado correctamente";
                }

                
                return View("Listado", clsListadoPersonasNombreDepartamento.ListadoPersonas);
            }
            catch (SqlException ex)
            {
                ViewBag.Error = "Ha ocurrido un error al conectar con la BBDD. Vuelve a intentarlo más tarde";
                return View("Error");
            }
        }

    }
}