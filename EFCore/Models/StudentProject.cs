using System;

namespace EFCore.Models;
//Junction/Bridge table
public class StudentProject
{
    public int StudentId { get; set; }
    public Student Student { get; set; } // Reference navigation property
    public int ProjectId { get; set; }
    public Project Project { get; set; } // Reference navigation property
}
