
using EFCore.Data;
using EFCore.Models;
using Microsoft.EntityFrameworkCore;

#region  Adding

// using (var dbContext = new ApplicationDbContext())
// {
//     // Assuming students and projects have already been added

//     var studentProjects = new List<StudentProject>
//     {
//         new StudentProject { StudentId = 1, ProjectId = 1 }, // Akromjon Abdaliev assigned to AI Research
//         new StudentProject { StudentId = 1, ProjectId = 2 }, // Akromjon Abdaliev assigned to E-Commerce Platform
//         new StudentProject { StudentId = 2, ProjectId = 3 }, // Elif Erdogan assigned to Mobile App Development
//         new StudentProject { StudentId = 3, ProjectId = 4 }, // Can Gunes assigned to Game Design
//         new StudentProject { StudentId = 4, ProjectId = 1 }, // Aylin Kurt assigned to AI Research
//         new StudentProject { StudentId = 4, ProjectId = 5 }, // Aylin Kurt assigned to Data Analysis
//         new StudentProject { StudentId = 5, ProjectId = 3 }  // Omer Sahin assigned to Mobile App Development
//     };

//     dbContext.StudentProjects.AddRange(studentProjects);
//     dbContext.SaveChanges();
//     Console.WriteLine("Student-Project relationships added successfully.");
// }
#endregion
#region GettingAll
// using (var dbContext = new ApplicationDbContext())
// {
//     var students = dbContext.Students.ToList();
//     Console.WriteLine($"Student List: \n");

//     foreach (var student in students)
//     {
//         Console.WriteLine($"Full Name: {student.FirstName} {student.LastName}");

//     }
//     Console.ReadKey();

// }
#endregion
#region GetOne
// using (var dbContext = new ApplicationDbContext())
// {
//     var student = dbContext.Students.Single(s => s.StudentId == 1); // student with ID-1 
//     Console.WriteLine($"Full Name: {student.FirstName} {student.LastName}");

// }
#endregion
#region Update
// using (var dbContext = new ApplicationDbContext())
// {
//     var student = dbContext.Students.Single(s => s.StudentId == 1); // student with ID-1
//     Console.WriteLine($"Full Name: {student.FirstName} {student.LastName}");
//     student.FirstName = "Muberra";
//     student.LastName = "Karakaya";
//     dbContext.SaveChanges();
//     Console.WriteLine($"Full Name: {student.FirstName} {student.LastName}");

// }
#endregion
#region Delete
// using (var dbContext = new ApplicationDbContext())
// {
//     var student = dbContext.Students.Single(std => std.StudentId == 6);

//     if (student != null)
//     {
//         dbContext.Students.Remove(student);
//         dbContext.SaveChanges();
//         Console.WriteLine($"Student has been deleted successfully");

//     }
// }
#endregion
#region Eager Loading 'Include'
// using (var dbContext = new ApplicationDbContext())
// {
//     var students = dbContext.Students.Include(s => s.StudentDetails).ToList();
//     foreach (var student in students)
//     {
//         Console.WriteLine($"Id: {student.StudentId}\t Name: {student.FirstName}\t Address: {student.StudentDetails.Address}");
//     }
// }
#endregion
#region Eager Loading 'ThenInclude'
// using (var dbContext = new ApplicationDbContext())
// { // Many-to-Many relationship
//     var projects = dbContext.Projects
//         .Include(s => s.StudentProjects)
//         .ThenInclude(s => s.Student).ToList();

//     foreach (var project in projects)
//     {
//         Console.WriteLine($"Project Name: {project.Name}");
//         foreach (var std in project.StudentProjects)
//         {
//             Console.WriteLine($"Student Name: {std.Student.FirstName}");
//         }
//         Console.WriteLine($"");

//     }
// }
#endregion
#region Explicit Loading
using (var dbContext = new ApplicationDbContext())
{ //---------------------first way-------------------------//
    // Loading the main entity
    // var students = dbContext.Students.ToList();
    // foreach (var student in students)
    // {
    //     // Loading the related entity
    //     dbContext.Entry(student).Reference(s => s.StudentDetails).Load();
    //     Console.WriteLine($"Id: {student.StudentDetails.StudentId}\t Name: {student.FirstName}\t Address: {student.StudentDetails.Address}");
    // }
    //---------------------second way-----------------------//
    // One-to-Many relationship
    var advisors = dbContext.Advisors.ToList();
    foreach (var advisor in advisors)
    {
        Console.WriteLine($"\nAdvisor Name: {advisor.FirstName} {advisor.LastName}");
        dbContext.Entry(advisor).Collection(a => a.Students).Load();
        if (advisor.Students.Any())
        {
            Console.WriteLine($"Students: ");
            foreach (var std in advisor.Students)
            {
                Console.WriteLine($"{std.FirstName} {std.LastName}");
            }

        }
    }



}
#endregion

