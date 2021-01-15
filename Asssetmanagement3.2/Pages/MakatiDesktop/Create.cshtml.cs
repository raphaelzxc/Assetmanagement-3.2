using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Asssetmanagement3._2.Data;
using Asssetmanagement3._2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;


namespace Asssetmanagement3._2.Pages.MakatiDesktop
{
    public class CreateModel : PageModel
    {

        private readonly IWebHostEnvironment _iweb;
        private readonly Asssetmanagement3._2.Data.Desktop2Context _context;

        public CreateModel(Asssetmanagement3._2.Data.Desktop2Context context,IWebHostEnvironment iweb)
        {
            _context = context;
            _iweb = iweb;
        }

        public IActionResult OnGet()
        {
            return Page();
        }


      


        [BindProperty]
        public Desktop Desktop { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Desktop.Add(Desktop);
            await _context.SaveChangesAsync();
            TempData["Referrer"] = "SaveRegister";
            return RedirectToPage("./Index");
        }
    }
}
