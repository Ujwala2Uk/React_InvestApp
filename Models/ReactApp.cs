using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace React_InvestApp.Models
{
    public partial class ReactApp
    {
        [Key]
        public int Id { get; set; }
        public string? Ename { get; set; }
        public string? Edescription { get; set; }
    }
}
