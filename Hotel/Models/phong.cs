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
    
    public partial class phong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public phong()
        {
            this.datphongs = new HashSet<datphong>();
        }
    
        public int ID_P { get; set; }
        public Nullable<int> ID_LP { get; set; }
        public string tenphong { get; set; }
        public string trangthai { get; set; }
        public Nullable<int> tang { get; set; }
        public string avatar_p { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<datphong> datphongs { get; set; }
        public virtual loaiphong loaiphong { get; set; }
    }
}