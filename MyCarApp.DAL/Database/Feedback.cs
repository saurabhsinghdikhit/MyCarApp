//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyCarApp.DAL.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Feedback
    {
        public System.Guid FeedbackId { get; set; }
        public string Name { get; set; }
        public Nullable<System.Guid> CategoryId { get; set; }
        public string Description { get; set; }
    
        public virtual FeedbackCategory FeedbackCategory { get; set; }
    }
}