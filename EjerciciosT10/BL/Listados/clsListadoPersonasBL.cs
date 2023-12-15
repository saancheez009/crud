using DAL;
using Entities;

namespace BL.Listados
{
    public class clsListadoPersonasBL
    {
        public static List<clsPersona> listadoCompletoPersonasBL()
        {
            return ListaPersonas.listadoCompletoPersonas();
        }

        public static clsListadoPersonasBL getPersonaIdBL(int id)
        {
            return ListaPersonas.getPersonaIdBL(id);
        }
    }
}
