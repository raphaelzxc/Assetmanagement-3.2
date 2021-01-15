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



namespace Asssetmanagement3._2.Pages.MakatiLaptop
{
    public class EditModel : PageModel
    {
        private readonly Asssetmanagement3._2.Data.Laptop1Context _context;

        public EditModel(Asssetmanagement3._2.Data.Laptop1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Laptop Laptop { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Laptop = await _context.Laptop.FirstOrDefaultAsync(m => m.ID == id);

            if (Laptop == null)
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

            _context.Attach(Laptop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                TempData["Referrers"] = "Edited";
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LaptopExists(Laptop.ID))
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

        private bool LaptopExists(int id)
        {
            return _context.Laptop.Any(e => e.ID == id);
        }
    }
}
