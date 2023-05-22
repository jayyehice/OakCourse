using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace DTO
{
    public class AddressDTO
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "please fill the address area")]
        public string AddressContent { get; set; }

        [Required(ErrorMessage = "please fill the email area")]
        public string Email { get; set; }

        [Required(ErrorMessage = "please fill the phone area")]
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string Fax { get; set; }

        [Required(ErrorMessage = "please fill the map area")]
        public string LargeMapPath { get; set; }

        [Required(ErrorMessage = "please fill the map area")]
        public string SmallMapPath { get; set; }
    }
}
