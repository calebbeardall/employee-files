using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeFilesApp.Models
{
    public class FileRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FileId { get; set; }

        public string FileName { get; set; }
        public string FileType { get; set; }
        public float FileSizeMB { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
