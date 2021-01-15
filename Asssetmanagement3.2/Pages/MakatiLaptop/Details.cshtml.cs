using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Asssetmanagement3._2.Data;
using Asssetmanagement3._2.Models;

namespace Asssetmanagement3._2.Pages.MakatiLaptop
{
    public class DetailsModel : PageModel
    {
        private readonly Asssetmanagement3._2.Data.Laptop1Context _context;

        public DetailsModel(Asssetmanagement3._2.Data.Laptop1Context context)
        {
            _context = context;
        }

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
    }
}
