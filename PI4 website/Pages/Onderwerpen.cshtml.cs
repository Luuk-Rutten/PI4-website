using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PI4_website.Data;
using PI4_website.Models;
using System.Collections;
using System.Collections.Generic;

namespace PI4_website.Pages
{
    public class OnderwerpenModel : PageModel
    {
        public ICollection<Onderwerpen> OnderwerpenCollectie { get; set; } = null!;

        private OnderwerpenContext _ctx;

        public OnderwerpenModel(OnderwerpenContext ctx)
        {
            _ctx = ctx;
        }


        public void OnGet()
        {
            OnderwerpenCollectie = _ctx.Onderwerpen.Include(s => s.Koppelingen).ThenInclude(i => i.Video).OrderBy(s => s.Name).ToList();
        }

       

        [BindProperty]
        public Onderwerpen OnderwerpProperty { get; set; }

        public ActionResult OnPost()
        {
            _ctx.Onderwerpen.Add(OnderwerpProperty);
            _ctx.SaveChanges();

            return RedirectToPage();
        }



            public async Task<IActionResult> OnGetDelete(int? id)
            {
                if (null == id)
                {
                    return NotFound();
                }

                var ondwrp = await _ctx.Onderwerpen.FindAsync(id);

                _ctx.Onderwerpen.Remove(ondwrp);

                await _ctx.SaveChangesAsync();

                return RedirectToPage();

            }
        

    }

  
    }
