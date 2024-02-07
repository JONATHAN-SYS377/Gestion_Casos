using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaUtilidades.Interfaces
{
    public interface IGenerica<Entity>
    {
        bool add(Entity entidad);

        Entity loadById(string id);

        bool deleteById(string id);

        bool updateById(Entity entidad);

        List<Entity> loadAll();


    }

}
