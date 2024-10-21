using System;

namespace EFCore.Models;

public class Student
{
    public int StudentId { get; set; } //Priimary key
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public ICollection<StudentProject> StudentProjects { get; set; } // Collection navigation property

    // One-to-One relationship with StudentDetails
    public StudentDetails StudentDetails { get; set; } // Reference navigation to dependent

    // One-to-Many relationship with Advisor
    public int AdvisorId { get; set; } // foreign key
    public Advisor Advisor { get; set; } // navigation property to Advisor
}
