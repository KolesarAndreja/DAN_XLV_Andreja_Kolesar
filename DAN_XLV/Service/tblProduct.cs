//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAN_XLV.Service
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblProduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblProduct()
        {
            this.tblStoredProducts = new HashSet<tblStoredProduct>();
        }
    
        public int productId { get; set; }
        public string productName { get; set; }
        public int code { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
        public bool stored { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblStoredProduct> tblStoredProducts { get; set; }
    }
}
