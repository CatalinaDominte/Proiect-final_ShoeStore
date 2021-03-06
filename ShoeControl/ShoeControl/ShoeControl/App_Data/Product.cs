//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShoeControl.App_Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.ArchiveProducts = new HashSet<ArchiveProduct>();
            this.Inventories = new HashSet<Inventory>();
        }
    
        public int ProductsId { get; set; }
        public string ModelId { get; set; }
        public string ProductsName { get; set; }
        public int Suppliers { get; set; }
        public int Category { get; set; }
        public int StoreLocation { get; set; }
        public string ProductsDescription { get; set; }
        public int UnitsInStock { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<decimal> FinalPrice { get; set; }
        public string Size { get; set; }
        public string AvaibleColours { get; set; }
        public System.DateTime EntryDate { get; set; }
        public byte[] Picture { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArchiveProduct> ArchiveProducts { get; set; }
        public virtual Category Category1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual StoreLocation StoreLocation1 { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
