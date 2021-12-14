using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleASP.Models
{
    //https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-6.0
    public class Student
    {
        [Required(ErrorMessage ="StudentID harus diisi")]
        [StringLength(8)]
        [Display(Name ="Nim")]
        public string StudentID { get; set; }
        
        [Required(ErrorMessage ="LastName harus diisi")]
        [Display(Name ="Nama Belakang")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage ="FirstName harus diisi")]
        [Display(Name ="Nama Depan")]
        public string FirstName { get; set; }
        
        [Display(Name ="Tanggal Masuk")]
        public DateTime EnrollmentDate { get; set; }
    }
    
}