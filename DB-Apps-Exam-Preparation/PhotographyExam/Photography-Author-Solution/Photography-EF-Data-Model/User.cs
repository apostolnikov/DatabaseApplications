//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Photography_EF_Data_Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.Albums = new HashSet<Album>();
            this.Photographs = new HashSet<Photograph>();
        }
    
        public int Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public System.DateTime BirthDate { get; set; }
        public Nullable<int> EquipmentId { get; set; }
    
        public virtual ICollection<Album> Albums { get; set; }
        public virtual Equipment Equipment { get; set; }
        public virtual ICollection<Photograph> Photographs { get; set; }
    }
}
