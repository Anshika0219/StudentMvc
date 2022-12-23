using Microsoft.EntityFrameworkCore;
using StudentInformation.Models;

namespace StudentInformation.Data
{
    public class InfoDbContext : DbContext
    {
        public InfoDbContext(DbContextOptions<InfoDbContext> options) : base(options)
        { 
        }
        public DbSet<StudentInfo> studentInfos { get; set; }
    }
}
