using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Asssetmanagement3._2.Data;
using Asssetmanagement3._2.Models;

using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;


namespace Asssetmanagement3._2.Pages.MakatiDesktop
{
    public class EditModel : PageModel
    {

        
        private readonly Asssetmanagement3._2.Data.Desktop2Context _context;

       

        public EditModel(Asssetmanagement3._2.Data.Desktop2Context context)
        {
            _context = context;
          
        }

        

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Desktop).State = EntityState.Modified;  

            try
            {
                
                {
                    

                    await _context.SaveChangesAsync();
                    TempData["Referrers"] = "Edited";
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DesktopExists(Desktop.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DesktopExists(int id)
        {
            return _context.Desktop.Any(e => e.ID == id);
        }
    }
}
