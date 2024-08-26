using Microsoft.EntityFrameworkCore;
using web_api.Models;

namespace web_api.Data;

public class StudentContext : DbContext
{
    public StudentContext(DbContextOptions<StudentContext> opts)
        : base(opts)
    {
    }

    public DbSet<Student> Students { get; set; }
}
