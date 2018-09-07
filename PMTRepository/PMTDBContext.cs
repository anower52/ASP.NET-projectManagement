using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMTRepository
{
   public class PMTDBContext : DbContext
    {
        public DbSet<User_Info> UserInfo { get; set; }
        public DbSet<Project_Info> ProjectInfo { get; set; }
        public DbSet<Assign_Project> AssignProjects { get; set; }
        public DbSet<Assign_Task> AssignTasks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
    }
}
