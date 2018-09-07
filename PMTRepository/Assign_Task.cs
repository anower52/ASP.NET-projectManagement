using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMTRepository
{
   public class Assign_Task
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "REQUIRED")]
        public int ProjectId { get; set; }
        [Required(ErrorMessage = "REQUIRED")]
        public int GUserId { get; set; }
        [Required(ErrorMessage = "REQUIRED")]
        public int RUserId { get; set; }
        [Required(ErrorMessage = "REQUIRED")]
        public string TaskName { get; set; }
        [Required(ErrorMessage = "REQUIRED")]
        public DateTime DueDate { get; set; }
        [Required(ErrorMessage = "REQUIRED")]
        public string Priority { get; set; }
    }
}
