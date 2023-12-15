using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
namespace DAL
{
    public static class ListaDepartamentos
    {
        /// <summary>
        /// Función que devuelve un listado de departamentos
        /// Precondición : Ninguna
        /// Postcondición : Ninguna
        /// </summary>
        /// <returns>Lista de departamentos</returns>
        public static List<clsDepartamento> listadoCompletoDepartamentos()
        {
            List<clsDepartamento> listadoDepartamento = new List<clsDepartamento>() {
                new clsDepartamento(1,"Finanzas"),
                new clsDepartamento(2,"Marketing"),
                new clsDepartamento(3,"RRHH"),
                new clsDepartamento(4,"Comida"),

            };

            return listadoDepartamento;

        }
    }
}
