using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IJMRP.Models
{
    [MetadataType(typeof(MetadatCurrentIsuue))]
    public partial class tblCurrentIssue
    { }
    public class MetadatCurrentIsuue
    {
        public int CURENTISSUE_ID { get; set; }
                [Required(ErrorMessage = "Enter Value please")]

        public string CURENTISSUE_GROUP { get; set; }

                [Required(ErrorMessage = "Enter Value please")]

        public string CURENTISSUE_NAME { get; set; }
                [Required(ErrorMessage = "Enter Value please")]

        public string CURENTISSUE_AUTHOR { get; set; }
                [Required(ErrorMessage = "Enter Value please")]

        public string CURENTISSUE_ABSTRACT { get; set; }
                [Required(ErrorMessage = "Enter Value please")]

        public string CURENTISSUE_ARCHIVE_ID { get; set; }
        public string CURENTISSUE_FILEPATH { get; set; }
                [Required(ErrorMessage = "Enter Value please")]

        public Nullable<System.DateTime> CURENTISSUE_DATE { get; set; }
    }
}