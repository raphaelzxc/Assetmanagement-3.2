using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Asssetmanagement3._2.Data;
using Asssetmanagement3._2.Models;

namespace Asssetmanagement3._2.Pages.MinesiteLaptop
{
    public class DeleteModel : PageModel
    {
        private readonly Asssetmanagement3._2.Data.MinesiteContext _context;

        public DeleteModel(Asssetmanagement3._2.Data.MinesiteContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LaptopMinesite = await _context.LaptopMinesite.FindAsync(id);

            if (LaptopMinesite != null)
            {
                _context.LaptopMinesite.Remove(LaptopMinesite);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
