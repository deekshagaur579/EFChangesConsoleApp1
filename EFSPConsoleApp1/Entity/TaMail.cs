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
    
    public partial class TaMail
    {
        public int CoId { get; set; }
        public string CoUserId { get; set; }
        public string CoMailType { get; set; }
        public Nullable<System.DateTime> CoMailSubject { get; set; }
        public Nullable<System.DateTime> CoSent { get; set; }
    }
}
