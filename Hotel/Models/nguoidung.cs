//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hotel.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class nguoidung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public nguoidung()
        {
            this.datphongs = new HashSet<datphong>();
            this.thes = new HashSet<the>();
        }
    
        public int ID_ND { get; set; }
        public string tendn { get; set; }
        public string matkhau { get; set; }
        public Nullable<int> ID_LND { get; set; }
        public string hoten { get; set; }
        public string diachi { get; set; }
        public string sdt { get; set; }
        public string email { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<datphong> datphongs { get; set; }
        public virtual loainguoidung loainguoidung { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<the> thes { get; set; }
    }
}
