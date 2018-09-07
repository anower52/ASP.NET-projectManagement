using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMTRepository
{
   public class Project_Info
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "REQUIRED")]
        public string ProjectName { get; set; }
        [Required(ErrorMessage = "REQUIRED")]
        public string CodeName { get; set; }
        [Required(ErrorMessage = "REQUIRED")]
        public string Description { get; set; }
        [Required(ErrorMessage = "REQUIRED")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "REQUIRED")]
        public DateTime EndDate { get; set; }
        public int Duration { get; set; }
        [Required(ErrorMessage = "REQUIRED")]
        public string Status { get; set; }
    }
}
