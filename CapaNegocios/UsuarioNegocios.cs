using CapaDatos;
using CapaEntidades;
using CapaUtilidades.Interfaces;
using System;
using System.Collections.Generic;

namespace CapaNegocios
{
    public class UsuarioNegocios : IGenerica<TBUsuario>
    {
        UsuarioDatos UsuarioDatos = new UsuarioDatos();

        public bool add(TBUsuario entidad)
        {
            return UsuarioDatos.add(entidad);
        }

        public bool deleteById(string id)
        {
            return UsuarioDatos.deleteById(id);
        }

        public List<TBUsuario> loadAll()
        {
            return UsuarioDatos.loadAll();
        }

        public TBUsuario loadById(string id)
        {
            return UsuarioDatos.loadById(id);
        }

        public bool updateById(TBUsuario entidad)
        {
            return UsuarioDatos.updateById(entidad);
        }
    }
}
