//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TodoApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class todolist
    {
        public int TodoId { get; set; }
        public string TodoText { get; set; }
        public string TodoNote { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> TodoDate { get; set; }
        public int CategoryId { get; set; }
    }
}
