using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Asssetmanagement3._2.Data;
using Asssetmanagement3._2.Models;

namespace Asssetmanagement3._2.Pages.MakatiDesktop
{
    public class DeleteModel : PageModel
    {
        private readonly Asssetmanagement3._2.Data.Desktop2Context _context;

        public DeleteModel(Asssetmanagement3._2.Data.Desktop2Context context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Desktop = await _context.Desktop.FindAsync(id);

            if (Desktop != null)
            {
                _context.Desktop.Remove(Desktop);
                await _context.SaveChangesAsync();
               
            }

            return RedirectToPage("./Index");
        }

        private IActionResult Json(object p)
        {
            throw new NotImplementedException();
        }
    }
}
