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
    
    public partial class datphong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public datphong()
        {
            this.hoadons = new HashSet<hoadon>();
        }
    
        public int ID_DP { get; set; }
        public Nullable<int> ID_P { get; set; }
        public Nullable<int> ID_ND { get; set; }
        public Nullable<System.DateTime> ngayden { get; set; }
        public Nullable<System.DateTime> ngaydi { get; set; }
        public Nullable<int> tongtien { get; set; }
        public Nullable<System.DateTime> ngaydat { get; set; }
    
        public virtual nguoidung nguoidung { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hoadon> hoadons { get; set; }
        public virtual phong phong { get; set; }
    }
}