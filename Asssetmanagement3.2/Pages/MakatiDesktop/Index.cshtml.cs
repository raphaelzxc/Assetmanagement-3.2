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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;


namespace Asssetmanagement3._2.Pages.MakatiDesktop
{
    public class IndexModel : PageModel
    {
        private readonly Asssetmanagement3._2.Data.Desktop2Context _context;
        private readonly IWebHostEnvironment _iweb;

        public IndexModel(Asssetmanagement3._2.Data.Desktop2Context context,IWebHostEnvironment iweb)
        {
            _context = context;
            _iweb = iweb;
        }

        public IList<Desktop> Desktop { get;set; }

        public async Task OnGetAsync(string searchString)
        {
            var Desktops = from m in _context.Desktop
                           select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                Desktops = Desktops.Where(s => s.CurrentUser.Contains(searchString));
               
            }

            Desktop = await Desktops.ToListAsync();
        }


        public async Task<IActionResult> OnPostAsync(IFormFile uploadfiles, Desktop img)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            string imgext = Path.GetExtension(uploadfiles.FileName);
            if (imgext == ".jpg" || imgext == ".png" || imgext == ".gif")
            {
                var imgsave = Path.Combine(_iweb.WebRootPath, "Images", uploadfiles.FileName);
                var stream = new FileStream(imgsave, FileMode.Create);
                await uploadfiles.CopyToAsync(stream);
                stream.Close();
                img.Imgname = uploadfiles.FileName;
                img.Imgpath = imgsave;
                await _context.Desktop.AddAsync(img);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }


        public async Task<IActionResult> OnPostExportExcelAsync()
        {

            var myBUs = await _context.Desktop.ToListAsync();
            // above code loads the data using LINQ with EF (query of table), you can substitute this with any data source.
            var stream = new MemoryStream();

            using (var package = new ExcelPackage(stream))
            {
                var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                workSheet.Cells.LoadFromCollection(myBUs, true);
                package.Save();
            }
            stream.Position = 0;

            string excelName = $"DesktopUser-{DateTime.Now}.xlsx";
            // above I define the name of the file using the current datetime.

            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName); // this will be the actual export.
        }


       


    }
}
