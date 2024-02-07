using CapaEntidades;
using CapaUtilidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Windows.Forms;

namespace CapaDatos
{
    public class PersonaDatos : IGenerica<TBPersona>
    {
        public bool add(TBPersona entidad)
        {
            try
            {
                using (var db = new DBSY_A_Y_M_CONSULTORESEntities())
                {
                    db.TBPersona.Add(entidad);
                    db.SaveChanges();
                    return true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al agregar la persona: " + ex.Message);
                return false;
            }
        }

        public bool deleteById(string id)
        {
            try
            {
                using (var db = new DBSY_A_Y_M_CONSULTORESEntities())
                {
                    var persona = db.TBPersona.FirstOrDefault(p => p.Identificacion == id);
                    if (persona != null)
                    {
                        persona.Estado = false;
                        db.Entry<TBPersona>(persona).State = EntityState.Modified;
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("No se encontró la persona con la identificación especificada.");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al eliminar la persona: " + ex.Message);
                return false;
            }
        }

        public List<TBPersona> loadAll()
        {
            try
            {
                using (var db = new DBSY_A_Y_M_CONSULTORESEntities())
                {
                    return db.TBPersona.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al cargar todas las personas: " + ex.Message);
                return null;
            }
        }

        public TBPersona loadById(string id)
        {
            try
            {
                using (var db = new DBSY_A_Y_M_CONSULTORESEntities())
                {
                    return db.TBPersona.FirstOrDefault(p => p.Identificacion == id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al cargar la persona: " + ex.Message);
                return null;
            }
        }

        public bool updateById(TBPersona entidad)
        {
            try
            {
                using (var db = new DBSY_A_Y_M_CONSULTORESEntities())
                {
                    db.Entry(entidad).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al actualizar la persona: " + ex.Message);
                return false;
            }
        }
    }
}
