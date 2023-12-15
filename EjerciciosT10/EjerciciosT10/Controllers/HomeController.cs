using EjerciciosT10.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using DAL;

namespace EjerciciosT10.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            SqlConnection connection = new SqlConnection();
            ViewBag.ConnectionState = "No se ha podido conectar";

            try
            {
                connection.ConnectionString = "server=107-14\\SQLEXPRESS;database=persona;uid=usuario;pwd=usuario;trustServerCertificate=true";
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
                return View(ListaPersonas.listadoCompletoPersonas());
            }
            catch (SqlException ex)
            {
                ViewBag.Error = "Ha ocurrido un error al conectar con la BBDD. Vuelve a intentarlo más tarde";
                return View("Error");

            } // Añadir errorBL clsPersona
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
                return View(ListaPersonas.getPersonaId(id));
            }
            catch (SqlException ex)
            {
                ViewBag.Error = "Ha ocurrido un error al conectar con la BBDD. Vuelve a intentarlo más tarde";
                return View("Error");
            }

        }
    }
}