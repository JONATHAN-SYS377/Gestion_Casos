using CapaEntidades;
using CapaUtilidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace CapaDatos
{
    public class UsuarioDatos : IGenerica<TBUsuario>
    {
        public bool add(TBUsuario entidad)
        {
            try
            {
                using (var db = new DBSY_A_Y_M_CONSULTORESEntities())
                {
                    db.TBUsuario.Add(entidad);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al agregar el usuario: " + ex.Message);
                return false;
            }
        }

        public bool deleteById(string id)
        {
            try
            {
                using (var db = new DBSY_A_Y_M_CONSULTORESEntities())
                {
                    var usuario = db.TBUsuario.FirstOrDefault(u => u.IdentificacionUserFK == id);
                    if (usuario != null)
                    {
                        usuario.Estado = false;
                        db.Entry<TBUsuario>(usuario).State = EntityState.Modified;
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el usuario con la identificación especificada.");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al eliminar el usuario: " + ex.Message);
                return false;
            }
        }

        public List<TBUsuario> loadAll()
        {
            try
            {
                using (var db = new DBSY_A_Y_M_CONSULTORESEntities())
                {
                    return db.TBUsuario.Include(u => u.TBPersona).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al cargar todos los usuarios: " + ex.Message);
                return null;
            }
        }

        public TBUsuario loadById(string id)
        {
            try
            {
                using (var db = new DBSY_A_Y_M_CONSULTORESEntities())
                {
                    return db.TBUsuario.Include(u => u.TBPersona)
                                        .FirstOrDefault(u => u.IdentificacionUserFK == id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al cargar el usuario: " + ex.Message);
                return null;
            }
        }

        public bool updateById(TBUsuario entidad)
        {
            try
            {
                using (var db = new DBSY_A_Y_M_CONSULTORESEntities())
                {
                    db.Entry <TBUsuario>(entidad).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al actualizar el usuario: " + ex.Message);
                return false;
            }
        }
    }
}
