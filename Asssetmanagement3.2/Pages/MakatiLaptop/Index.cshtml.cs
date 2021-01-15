using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Asssetmanagement3._2.Data;
using Asssetmanagement3._2.Models;
using OfficeOpenXml;
using System.IO;

namespace Asssetmanagement3._2.Pages.MakatiLaptop
{
    public class IndexModel : PageModel
    {
        private readonly Asssetmanagement3._2.Data.Laptop1Context _context;

        public IndexModel(Asssetmanagement3._2.Data.Laptop1Context context)
        {
            _context = context;
        }

        public IList<Laptop> Laptop { get;set; }

        public async Task OnGetAsync(string searchString)
        {
            var Laptops = from m in _context.Laptop
                          select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                Laptops = Laptops.Where(s => s.CurrentUser.Contains(searchString));
            }
            Laptop = await Laptops.ToListAsync();
        }

        public async Task<IActionResult> OnPostExportExcelAsync()
        {

            var myBUs = await _context.Laptop.ToListAsync();
            // above code loads the data using LINQ with EF (query of table), you can substitute this with any data source.
            var stream = new MemoryStream();

            using (var package = new ExcelPackage(stream))
            {
                var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                workSheet.Cells.LoadFromCollection(myBUs, true);
                package.Save();
            }
            stream.Position = 0;

            string excelName = $"LaptopUser-{DateTime.Now}.xlsx";
            // above I define the name of the file using the current datetime.

            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName); // this will be the actual export.
        }
    }
}
