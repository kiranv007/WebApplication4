//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication4
{
    using System;
    using System.Collections.Generic;
    
    public partial class CarDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CarDetail()
        {
            this.BookingRequests = new HashSet<BookingRequest>();
        }
    
        public int CarID { get; set; }
        public string CarName { get; set; }
        public string CarModel { get; set; }
        public Nullable<decimal> CarPrice { get; set; }
        public Nullable<int> ShowroomID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookingRequest> BookingRequests { get; set; }
        public virtual BranchDetail BranchDetail { get; set; }
    }
}
