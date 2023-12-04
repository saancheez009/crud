
using UD10.DAL;
using UD10.Entities;

namespace BL
{
    public static class ListaPersonasBL
    {
        /// <summary>
        /// Función que devuelve un listado de personas obtenido de la DAL y aplicando las reglas de
        /// negocio.
        /// </summary>
        /// <returns>Lista con personas</returns>
        public static List<clsPersona> listadoCompletoPersonasBL() {

            return ListaPersonas.listadoCompletoPersonas();
        }

        /// <summary>
        /// Función que devuelve una persona de la capa DAL y aplica
        /// las reglas de negocio
        /// </summary>
        /// <param name="id">Id de la persona</param>
        /// <returns>Devuelve una persona</returns>
        public static clsPersona getPersonaIdBL(int id) {
            return ListaPersonas.getPersonaId(id);
        }
    }
}
