using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Asssetmanagement3._2.Models
{
    public class Desktop : Entity
    {

        public string Department { get; set; }

        public string CurrentUser { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Processor { get; set; }

        public string RAM { get; set; }

        public string Remarks { get; set; }

        public string SerialNumber { get; set; }

        public string MonitorBrand { get; set; }

        public string MonitorSerialNumber { get; set; }

        public string Imgname { get; set; }

        public string  Imgpath { get; set; }


    }
}
