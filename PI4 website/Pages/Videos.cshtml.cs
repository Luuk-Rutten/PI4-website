using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PI4_website.Data;
using PI4_website.Models;

namespace PI4_website.Pages
{
    public class VideosModel : PageModel
    {

        public ICollection<Video> VideoCollectie { get; set; } = null!;


        private OnderwerpenContext _ctx;

        public VideosModel(OnderwerpenContext ctx)
        {
            _ctx = ctx;
        }



        public void OnGet()
        {
            VideoCollectie = _ctx.Videos.ToList();

        }

        public async Task<IActionResult> OnGetDelete(int? id)
        {
            if (null == id)
            {
                return NotFound();
            }

            var videos = await _ctx.Videos.FindAsync(id);

            _ctx.Videos.Remove(videos);

            await _ctx.SaveChangesAsync();

            return RedirectToPage();

        }
        public async Task OnPostAsync()
        {
            var searchString = Request.Form["searchString"];

            VideoCollectie = await _ctx.Videos.Where(x => x.Name
            .Contains(searchString))
            .ToListAsync();
        }
    }
}
