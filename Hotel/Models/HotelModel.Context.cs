﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBHotelContextEntities : DbContext
    {
        public DBHotelContextEntities()
            : base("name=DBHotelContextEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ChiTietDichVu> ChiTietDichVus { get; set; }
        public virtual DbSet<ChiTietPhuThu> ChiTietPhuThus { get; set; }
        public virtual DbSet<datphong> datphongs { get; set; }
        public virtual DbSet<dichvu> dichvus { get; set; }
        public virtual DbSet<hoadon> hoadons { get; set; }
        public virtual DbSet<loainguoidung> loainguoidungs { get; set; }
        public virtual DbSet<loaiphong> loaiphongs { get; set; }
        public virtual DbSet<nguoidung> nguoidungs { get; set; }
        public virtual DbSet<phong> phongs { get; set; }
        public virtual DbSet<phuthu> phuthus { get; set; }
        public virtual DbSet<the> thes { get; set; }
    }
}
