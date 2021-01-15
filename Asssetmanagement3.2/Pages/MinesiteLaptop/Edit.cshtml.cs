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

namespace Asssetmanagement3._2.Pages.MinesiteLaptop
{
    public class EditModel : PageModel
    {
        private readonly Asssetmanagement3._2.Data.MinesiteContext _context;

        public EditModel(Asssetmanagement3._2.Data.MinesiteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LaptopMinesite LaptopMinesite { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LaptopMinesite = await _context.LaptopMinesite.FirstOrDefaultAsync(m => m.ID == id);

            if (LaptopMinesite == null)
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

            _context.Attach(LaptopMinesite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                TempData["Referrers"] = "Edited";
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LaptopMinesiteExists(LaptopMinesite.ID))
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

        private bool LaptopMinesiteExists(int id)
        {
            return _context.LaptopMinesite.Any(e => e.ID == id);
        }
    }
}
