using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IJMRP.Models
{

    [MetadataType(typeof(MetaData_Logintable))]
    public partial class tblUserLogin
    {

    }
    public class MetaData_Logintable
    {
        public string U_USERID { get; set; }
        public string U_USERNAME { get; set; }
        public string U_MOBILE { get; set; }
        public string U_EMAIL { get; set; }
        public string U_PASSWORD { get; set; }
        public string U_ROLE { get; set; }
    }
}