using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMTApp
{
    public class AssignToProject
    {
        public int Id { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public int Duration { get; set; }
        public string Status { get; set; }
        public string AssignTo { get; set; }
    }
}