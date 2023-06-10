using Microsoft.EntityFrameworkCore;

namespace WebApplicationOkta1.Models
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
        }

        public DbSet<Task2137> Tasks { get; set; }
    }

}