//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFSPConsoleApp1.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TaEmployee
    {
        public int CoId { get; set; }
        public string CoUserID { get; set; }
        public string CoFirstName { get; set; }
        public string CoLastName { get; set; }
        public Nullable<System.DateTime> CoCreated { get; set; }
        public Nullable<System.DateTime> CoUpdated { get; set; }
        public string CoRole { get; set; }
        public string CoAddressLine1 { get; set; }
        public string CoAddressLine2 { get; set; }
        public string CoAddressLine3 { get; set; }
        public string CoDesignation { get; set; }
        public string CoDepartment { get; set; }
        public Nullable<bool> CoActive { get; set; }
    }
}
