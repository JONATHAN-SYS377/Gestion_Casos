using CapaDatos;
using CapaEntidades;
using CapaUtilidades.Interfaces;
using System;
using System.Collections.Generic;

namespace CapaNegocios
{
    public class PersonaNegocios : IGenerica<TBPersona>
    {
        PersonaDatos PersonaDatos = new PersonaDatos();

        public bool add(TBPersona entidad)
        {
            return PersonaDatos.add(entidad);
        }

        public bool deleteById(string id)
        {
            return PersonaDatos.deleteById(id);
        }

        public List<TBPersona> loadAll()
        {
            return PersonaDatos.loadAll();
        }

        public TBPersona loadById(string id)
        {
            return PersonaDatos.loadById(id);
        }

        public bool updateById(TBPersona entidad)
        {
            return PersonaDatos.updateById(entidad);
        }
    }
}
