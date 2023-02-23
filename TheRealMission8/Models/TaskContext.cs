using Microsoft.EntityFrameworkCore;

namespace TheRealMission8.Models
{
    public class TaskContext : DbContext
    {
        //constructor
        public TaskContext(DbContextOptions<TaskContext> tasks) : base(tasks)
        {
            //leave blank for  now
        }

        public DbSet<TaskResponse> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category
                {
                    CategoryID = 1,
                    CategoryName = "Home"
                },
                new Category
                {
                    CategoryID = 2,
                    CategoryName = "Work"
                },
                new Category
                {
                    CategoryID = 3,
                    CategoryName = "School"
                },
                new Category
                {
                    CategoryID = 4,
                    CategoryName = "Church"
                });


            mb.Entity<TaskResponse>().HasData(

                new TaskResponse
                {
                    TaskID = 1,
                    Task = "Mission 8",
                    Due = "2/24/2023",
                    Quadrant = 1,
                    Completed = false,
                    CategoryID= 3
                },
                new TaskResponse
                {
                    TaskID = 1,
                    Task = "Mission 9",
                    Due = "2/29/2023",
                    Quadrant = 1,
                    Completed = false,
                    CategoryID = 3
                },
                new TaskResponse
                {
                    TaskID = 1,
                    Task = "Mission 7",
                    Due = "2/21/2023",
                    Quadrant = 1,
                    Completed = true,
                    CategoryID= 3
                }
             );
        }
    }
}
