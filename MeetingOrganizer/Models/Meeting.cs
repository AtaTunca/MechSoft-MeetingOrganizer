//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MeetingOrganizer.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Meeting
    {
        public int MeetingID { get; set; }
        public string MeetingSubject { get; set; }
        public System.TimeSpan StartingTime { get; set; }
        public System.TimeSpan EndingTime { get; set; }
        public string Participants { get; set; }
        public System.DateTime Date { get; set; }
    }
}
