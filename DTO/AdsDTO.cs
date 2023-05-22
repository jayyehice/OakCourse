﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DTO
{
    public class AdsDTO
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "please fill the name area")]
        public string Name { get; set; }
        public string ImagePath { get; set; }

        [Required(ErrorMessage = "please fill the link area")]
        public string Link { get; set; }

        [Required(ErrorMessage = "please fill the imagesize area")]
        public string Imagesize { get; set; }

        [Display(Name = "Ads Image")]
        public HttpPostedFileBase AdsImage { get; set; }
    }
}
