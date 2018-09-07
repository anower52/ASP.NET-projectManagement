using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMTRepository
{
    interface IProjectRepository
    {
        List<Project_Info> all_project();
        Project_Info project(int id);
        int Insert(Project_Info project);
        int Delete(int id);
        int Update(Project_Info project);
    }
}
