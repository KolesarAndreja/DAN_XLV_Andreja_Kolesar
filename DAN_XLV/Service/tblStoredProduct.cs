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
    
    public partial class tblStoredProduct
    {
        public int storedId { get; set; }
        public Nullable<int> productId { get; set; }
    
        public virtual tblProduct tblProduct { get; set; }
    }
}
