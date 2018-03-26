using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarDealershipWebApplication.Models;

namespace CarDealershipWebApplication.Models
{
    public class CarDealershipWebApplicationContext : DbContext
    {
        public CarDealershipWebApplicationContext (DbContextOptions<CarDealershipWebApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<CarDealershipWebApplication.Models.CarMark> CarMark { get; set; }

        public DbSet<CarDealershipWebApplication.Models.SparePart> SparePart { get; set; }
    }
}
