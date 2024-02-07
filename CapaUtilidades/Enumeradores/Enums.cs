using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaUtilidades.Enumeradores
{
    public class Enums
    {
        public enum TipoIdentificacion
        {
            CEDULA = 0,
            PASAPORTE = 1,
            DIMEX = 2
        }

        public enum TipoUsuario
        {
            Tramitador = 0,
            Contador = 1,
            Admi = 2
        }

        public enum TipoInstitucion
        {
            Escuela = 1,
            Colegio = 2,
        }

        public enum DiaSemana
        {
            Lunes = 1,
            Martes = 2,
            Miércoles = 3,
            Jueves = 4,
            Viernes = 5
        }
    }
}
