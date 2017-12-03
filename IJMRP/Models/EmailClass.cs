using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IJMRP.Models
{
    public class EmailClass
    {
       
            //public string To { get; set; }
        [Required(ErrorMessage="Please Enter Subject ")]
            public string Subject { get; set; }
                [Required(ErrorMessage = "Please Enter Msg Body ")]

            public string Body { get; set; }
                [Required(ErrorMessage = "Please Enter Your Email Id ")]

            public string sender { get; set; }
                [Required(ErrorMessage = "Please Enter Your Name ")]

            public string name { get; set; }
        
    }
}