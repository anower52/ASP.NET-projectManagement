using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMTRepository
{
    public class ProjectRepository :IProjectRepository
    {
        PMTDBContext context = new PMTDBContext();
        public List<Project_Info> all_project()
        {
            return context.ProjectInfo.ToList();
        }

        public List<Assign_Task> all_task()
        {
            return context.AssignTasks.ToList();
        }
        public Project_Info project(int id)
        {
            return context.ProjectInfo.SingleOrDefault(u => u.Id == id);
        }
        public int Insert(Project_Info project)
        {
            context.ProjectInfo.Add(project);
            return context.SaveChanges();
        }
        public int Delete(int id)
        {
            Project_Info ProjectToDelete = context.ProjectInfo.SingleOrDefault(u => u.Id == id);
            context.ProjectInfo.Remove(ProjectToDelete);
            return context.SaveChanges();
        }
        public int Update(Project_Info project)
        {
            Project_Info ProjectToUpdate = context.ProjectInfo.SingleOrDefault(u => u.Id == project.Id);
            ProjectToUpdate.ProjectName = project.ProjectName;
            ProjectToUpdate.CodeName = project.CodeName;
            ProjectToUpdate.Description = project.Description;
            ProjectToUpdate.StartDate = project.StartDate;
            ProjectToUpdate.EndDate = project.EndDate;
            ProjectToUpdate.Duration = project.Duration;
            ProjectToUpdate.Status = project.Status;
            return context.SaveChanges();
        }
    }
}
