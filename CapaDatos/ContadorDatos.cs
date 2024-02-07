using CapaEntidades;
using CapaUtilidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace CapaDatos
{
    public class ContadorDatos : IGenerica<TBContador>
    {
        public bool add(TBContador entidad)
        {
            try
            {
                using (var db = new DBSY_A_Y_M_CONSULTORESEntities())
                {
                    db.TBContador.Add(entidad);
                    db.SaveChanges();
                    return true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        public bool deleteById(string id)
        {
            try
            {
                using (var db = new DBSY_A_Y_M_CONSULTORESEntities())
                {
                    var contador = db.TBContador.FirstOrDefault(c => c.IdentificacionContadorFK == id);
                    if (contador != null)
                    {
                        contador.Estado = false;
                        db.Entry<TBContador>(contador).State = EntityState.Modified;
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el contador con la identificación especificada.");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al eliminar el contador: " + ex.Message);
                return false;
            }
        }

        public List<TBContador> loadAll()
        {
            try
            {
                using (var db = new DBSY_A_Y_M_CONSULTORESEntities())
                {
                    return db.TBContador.Include(c => c.TBPersona).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al cargar todos los contadores: " + ex.Message);
                return null;
            }
        }

        public TBContador loadById(string id)
        {
            try
            {
                using (var db = new DBSY_A_Y_M_CONSULTORESEntities())
                {
                    return db.TBContador.Include(c => c.TBPersona)
                                        .FirstOrDefault(c => c.IdentificacionContadorFK == id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al cargar el contador: " + ex.Message);
                return null;
            }
        }

        public bool updateById(TBContador entidad)
        {
            try
            {
                using (var db = new DBSY_A_Y_M_CONSULTORESEntities())
                {
                    db.Entry<TBContador>(entidad).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al actualizar el contador: " + ex.Message);
                return false;
            }
        }
    }
}
