//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserProfileDetail
    {
        public int ProfileDetailId { get; set; }
        public int ProfileId { get; set; }
        public int ModuleId { get; set; }
        public Nullable<bool> CreateStatus { get; set; }
        public Nullable<bool> EditStatus { get; set; }
        public Nullable<bool> DeleteStatus { get; set; }
        public Nullable<bool> PrintStatus { get; set; }
        public Nullable<bool> ViewStatus { get; set; }
    }
}