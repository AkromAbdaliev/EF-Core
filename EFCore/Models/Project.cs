using System;

namespace EFCore.Models;

public class Project
{
    public int ProjectId { get; set; }
    public string Name { get; set; }
    public ICollection<StudentProject> StudentProjects { get; set; } // Collection navigation property
}
