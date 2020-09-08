using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    [Table("EmpDetails")]
    public class Emp
    {
        [Key]
        public int EId { get; set; }
        public string EName { get; set; }
        public string EDesig { get; set; }
        public DateTime EDOJ { get; set; }

    }
}