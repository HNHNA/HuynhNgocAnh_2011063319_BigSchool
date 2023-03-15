using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BigSchool.Models
{
    public class Category
    {
        // dung byte vi khong gian luu tru [0-255] 
        public byte  Id { get; set; }
        [Required]
        [StringLength(255)]
        public String Name { get; set; }
    }
}