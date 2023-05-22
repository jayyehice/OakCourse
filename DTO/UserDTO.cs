using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.Web;

namespace DTO
{
    public class UserDTO
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "please fill username area")]
        public string Username { get; set; }

        [Required(ErrorMessage = "please fill password area")]
        public string Password { get; set; }

        [Required(ErrorMessage = "please fill Email area")]
        public string Email { get; set; }
        public string Imagepath { get; set; }

        [Required(ErrorMessage = "please fill Name area")]
        public string Name { get; set; }
        public bool isAdmin { get; set; }
        [Display(Name = "User Image")]
        public HttpPostedFileBase UserImage { get; set; }
    }
}
