using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asssetmanagement3._2.Models
{
    public abstract class Entity
    {
        public int ID { get; set; }
        public string CreatedByUser { get; set; }


        [DisplayFormat(DataFormatString ="{0:MM/dd/yyyy}")]
        public DateTime CreatedDate { get; set; }

        public string ModifiedByUser { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ModifiedDate { get; set; }
    }
}
