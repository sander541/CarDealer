using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipWebApplication.Models
{
    public class SparePart
    {
        [Key]
        public int SparePartID { get; set; }
        public string SparePartName { get; set; }
        public int SparePartCode { get; set; }
        public CarMark CarMark { get; set; }

    }

}
