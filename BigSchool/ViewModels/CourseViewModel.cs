using BigSchool.Models;
using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BigSchool.ViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }

        [Required]  
        public string Place { get; set; }
        [Required]
        [FutureDate] // Rang buoc gia tri ngay thang phai lon hon ngay hien tai va dung dinh dang dd/M/yyyy
        public string Date { get; set; }
        [Required]
        [ValidTime] // Rang buoc gia tri gio phai dung dinh dang HH:mm
        public string Time { get; set; }
        [Required]
        public byte Category { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public DateTime GetDateTime() 
        { 
            return DateTime.Parse(string.Format("{0} {1}",Date,Time));
        }
        public string Heading { get; set; }

        public string Action
        {
            get { return (Id != 0) ? "Update" : "Create"; }
        }
    }

}