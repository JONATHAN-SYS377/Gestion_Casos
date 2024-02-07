using CapaEntidades;
using CapaUtilidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace CapaDatos
{
    public class ColaboradorDatos : IGenerica<TBColaborador>
    {
        public bool add(TBColaborador entidad)
        {
            try
            {
                using (var db = new DBSY_A_Y_M_CONSULTORESEntities())
                {
                    db.TBColaborador.Add(entidad);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al agregar el colaborador: " + ex.Message);
                return false;
            }
        }
        public bool deleteById(string id)
        {
            try
            {
                using (var db = new DBSY_A_Y_M_CONSULTORESEntities())
                {
                    var colaborador = db.TBColaborador.Include(c => c.TBPersona)
                                        .FirstOrDefault(c => c.IdentificacionColaboradorFK == id);
                    if (colaborador != null)
                    {
                        colaborador.Estado = false;
                        db.Entry(colaborador).State = EntityState.Modified;
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el colaborador con la identificación especificada.");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al eliminar el colaborador: " + ex.Message);
                return false;
            }
        }

        public List<TBColaborador> loadAll()
        {
            try
            {
                using (var db = new DBSY_A_Y_M_CONSULTORESEntities())
                {
                    return db.TBColaborador.Include(c => c.TBPersona).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al cargar todos los colaboradores: " + ex.Message);
                return null;
            }
        }

        public TBColaborador loadById(string id)
        {
            try
            {
                using (var db = new DBSY_A_Y_M_CONSULTORESEntities())
                {
                    return db.TBColaborador.Include(c => c.TBPersona)
                                        .FirstOrDefault(c => c.IdentificacionColaboradorFK == id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al cargar el colaborador: " + ex.Message);
                return null;
            }
        }

        public bool updateById(TBColaborador entidad)
        {
            try
            {
                using (var db = new DBSY_A_Y_M_CONSULTORESEntities())
                {
                    db.Entry<TBColaborador>(entidad).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al actualizar el colaborador: " + ex.Message);
                return false;
            }
        }
    }
}
