using System;

namespace EFCore.Models;

public class StudentDetails
{
    public int Id { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public int StudentId { get; set; } //Foreign Key
    public Student Student { get; set; }
}
