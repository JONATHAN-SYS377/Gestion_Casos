using CapaEntidades;
using CapaUtilidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace CapaDatos
{
    public class InstitucionesDatos : IGenerica<TBInstitucion>
    {
        public bool add(TBInstitucion entidad)
        {
            try
            {
                using (var db = new DBSY_A_Y_M_CONSULTORESEntities())
                {
                    db.TBInstitucion.Add(entidad);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al agregar la institución: " + ex.Message);
                return false;
            }
        }

        public bool deleteById(string id)
        {
            try
            {
                using (var db = new DBSY_A_Y_M_CONSULTORESEntities())
                {
                    var institucion = db.TBInstitucion.FirstOrDefault(i => i.Codigo == Convert.ToInt32(id));
                    if (institucion != null)
                    {
                        institucion.Estado = false;
                        db.Entry<TBInstitucion>(institucion).State = EntityState.Modified;
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("No se encontró la institución con el código especificado.");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al eliminar la institución: " + ex.Message);
                return false;
            }
        }

        public List<TBInstitucion> loadAll()
        {
            try
            {
                using (var db = new DBSY_A_Y_M_CONSULTORESEntities())
                {
                    return db.TBInstitucion.Include("TBContador").ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al cargar todas las instituciones: " + ex.Message);
                return null;
            }
        }

        public TBInstitucion loadById(string id)
        {
            try
            {
                using (var db = new DBSY_A_Y_M_CONSULTORESEntities())
                {
                    return db.TBInstitucion.FirstOrDefault(i => i.Codigo == Convert.ToInt32(id));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al cargar la institución: " + ex.Message);
                return null;
            }
        }

        public bool updateById(TBInstitucion entidad)
        {
            try
            {
                using (var db = new DBSY_A_Y_M_CONSULTORESEntities())
                {
                    db.Entry<TBInstitucion>(entidad).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al actualizar la institución: " + ex.Message);
                return false;
            }
        }
    }
}
