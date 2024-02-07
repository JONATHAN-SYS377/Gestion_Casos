//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CapaEntidades
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBInstitucion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBInstitucion()
        {
            this.TBEntregaCasos = new HashSet<TBEntregaCasos>();
            this.TBRevision = new HashSet<TBRevision>();
        }
    
        public int Codigo { get; set; }
        public int Circuito { get; set; }
        public int TipoFK { get; set; }
        public string NombreIntitucion { get; set; }
        public string CedulaJuridica { get; set; }
        public string CuentaLey { get; set; }
        public int ContadorFK { get; set; }
        public string Responsable { get; set; }
        public string Contacto { get; set; }
        public bool Estado { get; set; }
        public Nullable<int> CodigoAux { get; set; }
        public string DiaRuta { get; set; }
        public string TipoBanco { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string UserUltimaModificacion { get; set; }
        public System.DateTime FechaUltimaModificacion { get; set; }
    
        public virtual TBContador TBContador { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBEntregaCasos> TBEntregaCasos { get; set; }
        public virtual TBTipoInstitucion TBTipoInstitucion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBRevision> TBRevision { get; set; }
    }
}
