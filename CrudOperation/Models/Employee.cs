using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace CrudOperation.Models
{
    [Table("Employees",Schema ="HR")]
    public class Employee
    {
        
        [Display(Name ="ID")]
        public int ? EmployeeId { get; set; }


        [Required ]
        [Display (Name ="Name")]
        [Column(TypeName = "varchar(250)")]
        public string EmployeeName { get; set; } = "";


        [Display (Name ="Image User")]
        [Column(TypeName = "varchar(250)")]
        public  string? Image { get; set; }//?means not required


        [Display(Name = "Birth Date")]
        [DataType(DataType.Date )]
        public DateTime BirthDate { get; set; }


        [Display(Name = "Salary")]
        [Column(TypeName = "decimal(12,2)")]
        public decimal Salary { get; set; }


        [Display(Name = "Hiring Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd-MMMM-yyyy}")]
        public DateTime HiringDate { get; set; }


        [Required]
        [Display(Name = "National ID")]
        [MaxLength(14)]
        [MinLength(14)]
        [Column(TypeName = "varchar(14)")]
        public string NationalId { get; set; }


        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
       
        public Department? Department { get; set; }



    }
}
