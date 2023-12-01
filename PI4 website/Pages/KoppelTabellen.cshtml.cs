using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PI4_website.Data;
using PI4_website.Models;

namespace PI4_website.Pages
{
    public class KoppelTabellenModel : PageModel
    {
        public Onderwerpen Onderwerp { get; set; }

        private readonly OnderwerpenContext _ctx;
        public KoppelTabellenModel(OnderwerpenContext ctx)
        {
            _ctx = ctx;
        }
        public async void OnGetAsync(int id)
        {
            Onderwerp = await _ctx.Onderwerpen.Where(s => s.OnderwerpID == id)
                .Include(s => s.Koppelingen)
                .ThenInclude(i => i.Video)
                .FirstOrDefaultAsync();
        }


        public ActionResult OnPost(int id, Onderwerpen Onderwerp)
        {
            if (default == Onderwerp.OnderwerpID)
            {
                _ctx.Onderwerpen.Add(Onderwerp);
            }
            else
            {
                _ctx.Attach(Onderwerp).State = EntityState.Modified;

            }
            _ctx.SaveChanges();
            return RedirectToPage("./Onderwerpen");
        }
        


    }
}
