

namespace BL.Manejadoras
{
    internal class HandlerPersonaBL
    {
        /// <summary>
        /// Función que llama a la DAL y devuelve el número de filas afectadas al borrar
        /// la persona que recibe como parámetro y aplica las normas de negocio
        /// Post condición: Mi salida es 0 : Cuando no haya id,-1 error de la BL, 1 conseguido borrar
        /// </summary>
        /// <param name="id">Id de la persona</param>
        /// <returns>Devuelve el número de filas afectadas</returns>
        public static int deletePersonaBL(int id)
        {

            int numFilasAfectadas = 0;
            DateTime fechaActual= DateTime.Now;
            //Si el dia de la semana es miercoles se devueve un 0, ya que no se puede borrar ese dia

            if(fechaActual.DayOfWeek== DayOfWeek.Wednesday)
            {
                numFilasAfectadas = -1;
            }
            else
            {
                numFilasAfectadas = HandlerPersonaBL.deletePersonaBL(id); 
            }
            
            return numFilasAfectadas;
        }
    }
}
