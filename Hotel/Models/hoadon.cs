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
    
    public partial class hoadon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public hoadon()
        {
            this.ChiTietDichVus = new HashSet<ChiTietDichVu>();
            this.ChiTietPhuThus = new HashSet<ChiTietPhuThu>();
        }
    
        public int ID_HD { get; set; }
        public Nullable<int> ID_DP { get; set; }
        public string phuongthucthanhtoan { get; set; }
        public string trangthaihd { get; set; }
        public Nullable<int> tongtien { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDichVu> ChiTietDichVus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietPhuThu> ChiTietPhuThus { get; set; }
        public virtual datphong datphong { get; set; }
    }
}
