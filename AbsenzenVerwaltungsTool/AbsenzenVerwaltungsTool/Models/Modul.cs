//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AbsenzenVerwaltungsTool.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Modul
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Modul()
        {
            this.Absenzs = new HashSet<Absenz>();
        }
    
        public int modul_id { get; set; }
        public string Bezeichnung { get; set; }
        public int lehrer_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Absenz> Absenzs { get; set; }
        public virtual Lehrer Lehrer { get; set; }
    }
}
