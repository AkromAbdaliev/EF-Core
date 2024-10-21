using System;

namespace EFCore.Models;

public class Advisor
{
    public int AdvisorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public long Salary { get; set; }

    // One-to-Many relationship with Student
    public ICollection<Student> Students { get; set; }

}
