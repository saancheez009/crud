using BL;
using UD10.Entities;

namespace Ejercicios.Models.ViewModels
{
    public class clsListadoPersonasNombreDepartamento
    {
        /// <summary>
        /// Listado de personas obtenido en la capa BL
        /// </summary>
        public static List<clsPersona> ListadoPersonas = ListaPersonasBL.listadoCompletoPersonasBL();

        /// <summary>
        /// Función que devuelve el nombre del departamento
        /// </summary>
        /// <param name="idDepart">Id del departamento</param>
        /// <returns>Nombre del departamento</returns>
        public static string NombreDepartamentoId(int idDepart) {
            return HandlerPersonaBL.nombreDepartamentoIdBL(idDepart);
        }
    }
}
