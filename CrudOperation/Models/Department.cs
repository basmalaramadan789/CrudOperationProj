using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudOperation.Models
{
    [Table("Departments",Schema ="HR")]
    public class Department
    {
        

       
        [Display(Name ="ID")]
        public int Id { get; set; }


        [Required ]
        [Display(Name = "Department Name")]
        [Column (TypeName = "varchar(200)")]
        public string DepartmentName { get; set; }=String.Empty; 



    }
}
