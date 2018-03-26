using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipWebApplication.Models
{
    public class CarMark
    {
        [Key]
        public int CarMarkID { get; set; }
        public string MarkName { get; set; }
    }
}
