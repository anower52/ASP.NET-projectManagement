using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMTRepository
{
   public class Assign_Project
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "REQUIRED")]
        public int ProjectId { get; set; }
        [Required(ErrorMessage = "REQUIRED")]
        public int UserId { get; set; }
    }
}
