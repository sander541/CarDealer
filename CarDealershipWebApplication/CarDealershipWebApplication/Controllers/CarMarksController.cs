using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarDealershipWebApplication.Models;

namespace CarDealershipWebApplication.Controllers
{
    public class CarMarksController : Controller
    {
        private readonly CarDealershipWebApplicationContext _context;

        public CarMarksController(CarDealershipWebApplicationContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            List<CarMark> carmarks = _context.CarMark.OrderBy(c => c.MarkName).ToList();
            SelectList marks = new SelectList(carmarks, "CarMarkID", "MarkName");
            ViewBag.CarMarks = marks;
            List<SparePart> spareparts = _context.SparePart.ToList();
            SelectList parts = new SelectList(spareparts, "SparePartID", "SparePartName");
            ViewBag.SpareParts = new SelectList(new List<SparePart>(), "SparePartID", "SparePartName");
            return View(carmarks);
        }
        public ActionResult Modify()
        {
            List<CarMark> carmarks = _context.CarMark.OrderBy(c => c.MarkName).ToList();
            SelectList marks = new SelectList(carmarks, "CarMarkID", "MarkName");
            ViewBag.CarMarks = marks;
            List<SparePart> spareparts = _context.SparePart.ToList();
            SelectList parts = new SelectList(spareparts, "SparePartID", "SparePartName");
            ViewBag.SpareParts = new SelectList(new List<SparePart>(), "SparePartID", "SparePartName");
            return View(carmarks);
        }



        public ActionResult GetSpareParts(int id)
        {
            var CarMark = _context.CarMark.SingleOrDefault(p => p.CarMarkID == id);
            var SparePartList = new List<SparePart>();
            var sparePartList = _context.SparePart.ToList<SparePart>();
            foreach (var item in sparePartList)
            {
                var sparePart = _context.SparePart
                .FirstOrDefault(p => p.CarMark.CarMarkID == id);
                if (item.CarMark != null)
                {
                    SparePartList.Add(item);
                }
            }
            List<SparePart> parts;
            if (id == -1) parts = new List<SparePart>();
            else parts = _context.SparePart.ToList<SparePart>();
            return PartialView(SparePartList);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }

        [HttpPost]
        public ActionResult CreateMark([Bind("ID,MarkName")] CarMark carMark)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carMark);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(carMark);
        }


        [HttpPost]
        public ActionResult AddPart(int? id,[Bind("CarMarkID,SparePartId,SparePartName,SparePartCode,CarMark")] SparePart sparePart)
        {

            sparePart.CarMark = _context.CarMark.SingleOrDefault(m => m.CarMarkID == id);
            
                _context.Add(sparePart);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));

        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var carMark = _context.CarMark.FirstOrDefault(m => m.CarMarkID == id);
            var sparePart = _context.SparePart.FirstOrDefault(m => m.CarMark.CarMarkID == id);
            if (sparePart != null)
            {
                _context.SparePart.Remove(sparePart);
                _context.SaveChanges();
            }
            _context.CarMark.Remove(carMark);

            _context.SaveChanges();
            return RedirectToAction(nameof(Modify));
        }
    }
}
