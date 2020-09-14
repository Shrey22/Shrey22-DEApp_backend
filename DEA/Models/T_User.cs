//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DEA.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_User()
        {
            this.T_OTP_Details = new HashSet<T_OTP_Details>();
            this.T_PasswordHistoryLog = new HashSet<T_PasswordHistoryLog>();
        }
    
        public int User_id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string MobileNo { get; set; }
        public Nullable<int> Class { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public bool IsOnline { get; set; }
        public bool IsLocked { get; set; }
        public Nullable<int> Role_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_OTP_Details> T_OTP_Details { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_PasswordHistoryLog> T_PasswordHistoryLog { get; set; }
        public virtual T_Roles T_Roles { get; set; }
    }
}
