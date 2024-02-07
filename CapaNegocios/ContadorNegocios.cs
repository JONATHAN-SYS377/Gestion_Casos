using CapaDatos;
using CapaEntidades;
using CapaUtilidades.Interfaces;
using System;
using System.Collections.Generic;

namespace CapaNegocios
{
    public class ContadorNegocios : IGenerica<TBContador>
    {
        ContadorDatos contadorDatos = new ContadorDatos();

        public bool add(TBContador entidad)
        {
            return contadorDatos.add(entidad);
        }

        public bool deleteById(string id)
        {
            return contadorDatos.deleteById(id);
        }

        public List<TBContador> loadAll()
        {
            return contadorDatos.loadAll();
        }

        public TBContador loadById(string id)
        {
            return contadorDatos.loadById(id);
        }

        public bool updateById(TBContador entidad)
        {
            return contadorDatos.updateById(entidad);
        }
    }
}
