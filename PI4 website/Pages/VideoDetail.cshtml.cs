using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PI4_website.Data;
using PI4_website.Models;
using System.Linq;

namespace PI4_website.Pages
{
    public class VideoDetailModel : PageModel
    {

        [BindProperty]
        public int OnderwerpID { set; get; }
        public List<SelectListItem> OnderwerpList { set; get; }
        public Onderwerpen Onderwerp { get; set; }
        public Video Videos { get; set; } = new Video();

        public KoppelTabel KoppelTabel { get; set; }
   
        private readonly OnderwerpenContext _ctx;
        public VideoDetailModel(OnderwerpenContext ctx)
        {
            _ctx = ctx;
        }

        public async void OnGetAsync(int id)
        {
            Videos = await _ctx.Videos.Where(s => s.VideoID == id)
           .Include(x => x.Koppelingen)
           .ThenInclude(i => i.Onderwerpen)
           .FirstOrDefaultAsync();

            OnderwerpList = await _ctx.Onderwerpen
                .Select(a => new SelectListItem
                {
                    Value = a.OnderwerpID.ToString(),
                    Text = a.Name
                })
                .ToListAsync();
            
            foreach (var v in Videos.Koppelingen)
            {
                
                _ctx.Videos.Add(v.Video);

            }

      }

        public ActionResult Onpost()
        {
            _ctx.Attach(Videos).State = EntityState.Modified;
            _ctx.SaveChanges();
            return RedirectToPage();

        }

        public ActionResult OnPostOnderwerpToevoegen(Video Videos, int id, KoppelTabel KoppelTabel)
        {
            
            string GeselecteerdOnderwerp = Request.Form["OndId"];
                       
            if (!GeselecteerdOnderwerp.Equals (KoppelTabel.Onderwerpen))
            {
                KoppelTabel.OnderwerpID = Convert.ToInt16(GeselecteerdOnderwerp);
                KoppelTabel.VideoID = id;
                _ctx.Attach(KoppelTabel).State = EntityState.Added;
                _ctx.SaveChanges();
                return RedirectToPage();
            }

            else
            {
                return RedirectToPage();
            }

        }
    }
}
