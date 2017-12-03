using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IJMRP.Models
{
    public class ClassJoinUs
    {
        [Required(ErrorMessage="select value")]
        public string Type { get; set; }

         
        [Required(ErrorMessage = "Enter value")]

        public string Name { get; set; }
        public string Academic_Position { get; set; }
        public string Department { get; set; }
        public string Institution_Affliation_Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Postal_Code { get; set; }
       
        [Required(ErrorMessage = "Enter value")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]

        [DataType(DataType.PhoneNumber)]

        public string Phone { get; set; }
        public string Publications { get; set; }
                [Required(ErrorMessage = "Enter value")]
                [DataType(DataType.EmailAddress)]

        public string Email { get; set; }

    }
}