using CapaDatos;
using CapaEntidades;
using CapaUtilidades.Interfaces;
using System;
using System.Collections.Generic;

namespace CapaNegocios
{
    public class InstitucionNegocios : IGenerica<TBInstitucion>
    {
        InstitucionesDatos institucionesDatos = new InstitucionesDatos();

        public bool add(TBInstitucion entidad)
        {
            return institucionesDatos.add(entidad);
        }

        public bool deleteById(string id)
        {
            return institucionesDatos.deleteById(id);
        }

        public List<TBInstitucion> loadAll()
        {
            return institucionesDatos.loadAll();
        }

        public TBInstitucion loadById(string id)
        {
            return institucionesDatos.loadById(id);
        }

        public bool updateById(TBInstitucion entidad)
        {
            return institucionesDatos.updateById(entidad);
        }
    }
}
