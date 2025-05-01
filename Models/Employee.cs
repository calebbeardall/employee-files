using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeeFilesApp.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }


        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public ICollection<FileRecord> Files { get; set; }
    }
}
