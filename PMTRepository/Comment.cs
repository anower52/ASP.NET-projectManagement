using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMTRepository
{
   public class Comment
    {
        [Key]
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int TaskId { get; set; }
        public string Commentedby { get; set; }
        public string Comments { get; set; }
        public DateTime Date { get; set; }
    }
}
