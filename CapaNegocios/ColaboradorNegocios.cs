using CapaDatos;
using CapaEntidades;
using CapaUtilidades.Interfaces;
using System;
using System.Collections.Generic;

namespace CapaNegocios
{
    public class ColaboradorNegocios : IGenerica<TBColaborador>
    {
        private ColaboradorDatos ColaboradorDatos = new ColaboradorDatos();

        public bool add(TBColaborador entidad)
        {
            return ColaboradorDatos.add(entidad);
        }

        public bool deleteById(string id)
        {
            return ColaboradorDatos.deleteById(id);
        }

        public List<TBColaborador> loadAll()
        {
            return ColaboradorDatos.loadAll();
        }

        public TBColaborador loadById(string id)
        {
            return ColaboradorDatos.loadById(id);
        }

        public bool updateById(TBColaborador entidad)
        {
            return ColaboradorDatos.updateById(entidad);
        }
    }
}
