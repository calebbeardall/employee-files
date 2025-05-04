using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmployeeFilesApp.Models;

[Index("DepartmentId", Name = "IX_FileRecords_DepartmentId")]
[Index("EmployeeId", Name = "IX_FileRecords_EmployeeId")]
public partial class FileRecord
{
    [Key]
    public int FileId { get; set; }

    public string FileName { get; set; } = null!;

    public string FileType { get; set; } = null!;

    [Column("FileSizeMB")]
    public float FileSizeMb { get; set; }

    public int EmployeeId { get; set; }

    public int DepartmentId { get; set; }

    [ForeignKey("DepartmentId")]
    [InverseProperty("FileRecords")]
    public virtual Department Department { get; set; } = null!;

    [ForeignKey("EmployeeId")]
    [InverseProperty("FileRecords")]
    public virtual Employee Employee { get; set; } = null!;
}
