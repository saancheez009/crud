using UD10.DAL;
using UD10.Entities;

namespace BL
{
    public static class HandlerPersonaBL
    {
        /// <summary>
        /// Función que llama a la DAL y devuelve el número de filas afectadas al borrar 
        /// la persona que recibe como parámetro y aplica las normas de negocio.
        /// // Post Condición: Mi salida es 0 Cuando no haya id, -1 error de la BL, 1 conseguido borrar
        /// </summary>
        /// <param name="id">Id de la persona</param>
        /// <returns>Devuelve el número de filas afectadas</returns>
        public static int deletePersonaBL(int id)
        {
            int numFilasAfectadas = 0;
            DateTime fechaActual = DateTime.Now;

            // Si el dia de la semana es miércoles se devuelve un 0, ya que no se puede borrar ese día
            if (fechaActual.DayOfWeek == DayOfWeek.Tuesday)
            {
                numFilasAfectadas = -1;
            }
            else
            {
                numFilasAfectadas = HandlerPersona.deletePersonaDAL(id);
            }
            return numFilasAfectadas;
        }

        public static int editPersonaBL(clsPersona per) {
            int numFilasAfectadas = HandlerPersona.editPersonaDAL(per);

            return numFilasAfectadas;
        }

        public static string nombreDepartamentoIdBL(int id) {
            return HandlerPersona.nombreDepartamentoId(id);
        }
    }
}
