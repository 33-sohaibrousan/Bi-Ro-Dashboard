//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BoSoDashboard.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<bool> IsPlay { get; set; }
        public string GameImg { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> Raiting { get; set; }
    
        public virtual User User { get; set; }
    }
}
