using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMTApp
{
   public class customTask
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string GUserName { get; set; }
        public string RUserName { get; set; }
        public string TaskName { get; set; }
        public DateTime DueDate { get; set; }
        public string Priority { get; set; }
    }
}
