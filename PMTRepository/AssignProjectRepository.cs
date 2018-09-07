using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMTRepository
{
    public class AssignProjectRepository
    {
        public void assign_project(int projectId, int userId)
        {
            PMTDBContext context = new PMTDBContext();
            Assign_Project a = new Assign_Project();
            a.ProjectId = projectId;
            a.UserId = userId;
            context.AssignProjects.Add(a);
            context.SaveChanges();

        }
    }
}
