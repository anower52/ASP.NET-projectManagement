using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMTRepository
{
    public class User_Info
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "REQUIRED")]
        [DisplayName("User Full Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "REQUIRED")]
        public string UserEmail { get; set; }
        [Required(ErrorMessage = "REQUIRED")]
        [DisplayName("User Name")]
        [StringLength(200)]
        [Index(IsUnique = true)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "REQUIRED")]
        [DisplayName("User Password")]
        public string Password { get; set; }
        public int UserType { get; set; }
        [Required(ErrorMessage = "REQUIRED")]
        [DisplayName("Date of Birth")]
        public DateTime Dob { get; set; }
        [Required(ErrorMessage = "REQUIRED")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "REQUIRED")]
        public int IsActive { get; set; }
    }
}
