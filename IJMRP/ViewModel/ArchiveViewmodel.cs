using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IJMRP.Models;
using System.ComponentModel.DataAnnotations;

namespace IJMRP.ViewModel
{
    public class ArchiveViewmodel
    {  
        //[Required(ErrorMessage="enter value please")]
        public tblArchive singleArchive { get; set; }
        public List<tblArchive> ArchiveList { get; set; }
    }
}