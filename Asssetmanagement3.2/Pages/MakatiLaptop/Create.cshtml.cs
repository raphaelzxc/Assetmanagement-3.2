using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Asssetmanagement3._2.Data;
using Asssetmanagement3._2.Models;

namespace Asssetmanagement3._2.Pages.MakatiLaptop
{
    public class CreateModel : PageModel
    {
        private readonly Asssetmanagement3._2.Data.Laptop1Context _context;

        public CreateModel(Asssetmanagement3._2.Data.Laptop1Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Laptop Laptop { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
                
            }
            
            _context.Laptop.Add(Laptop);
            await _context.SaveChangesAsync();
            TempData["Referrer"] = "SaveRegister";

            return RedirectToPage("./Index");
        }

    }
}
