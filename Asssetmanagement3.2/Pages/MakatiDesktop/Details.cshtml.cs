using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Asssetmanagement3._2.Data;
using Asssetmanagement3._2.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Asssetmanagement3._2.Pages.MakatiDesktop
{
    public class DetailsModel : PageModel
    {

        private readonly IWebHostEnvironment _iweb;
        private readonly Asssetmanagement3._2.Data.Desktop2Context _context;


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






        public DetailsModel(Asssetmanagement3._2.Data.Desktop2Context context, IWebHostEnvironment iweb)
        {
            _context = context;
            _iweb = iweb;
        }

        public Desktop Desktop { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Desktop = await _context.Desktop.FirstOrDefaultAsync(m => m.ID == id);

            if (Desktop == null)
            {
                return NotFound();
            }
            return Page();
        }

      
    }
}
