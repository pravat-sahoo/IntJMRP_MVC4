using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IJMRP.Models
{
    [MetadataType(typeof(MetadatArchive))]

    public partial class tblArchive
    {

    }
    
    public class MetadatArchive
    {
       
    [Required(ErrorMessage="Enter Value please")]
        public string ARCHIVE_DETAILS { get; set; }
        [Required(ErrorMessage = "Enter Value please")]

    public Nullable<System.DateTime> ARCHIVE_YEAR { get; set; }
        public string ARCHIVE_FILE { get; set; }
    }
    

}