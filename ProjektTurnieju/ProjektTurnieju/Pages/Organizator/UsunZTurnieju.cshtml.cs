using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using ProjektTurnieju.Models;

namespace ProjektTurnieju.Pages.Organizator
{
    public class UsunZTurniejuModel : PageModel
    {
        private readonly ProjektTurnieju.Data.TurniejDBContext _context;

        public UsunZTurniejuModel(ProjektTurnieju.Data.TurniejDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Turniej Turniej { get; set; } = default!;
        [BindProperty]
        public Druzyna Druzyna { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int id, int idTurnieju)
        {

            var turniej = await _context.Turniej.Include(Turniej => Turniej.Druzyny).FirstOrDefaultAsync(m => m.Id == idTurnieju);
            var druzyna = await _context.Druzyny.FirstOrDefaultAsync(m => m.Id == id);

            Druzyna = druzyna;
            Turniej = turniej;

            if (Turniej.Druzyny == null)
            {
                Turniej.Druzyny = new List<Druzyna>();
            }
            Turniej.Druzyny.Remove(Druzyna);

            _context.Attach(Druzyna).State = EntityState.Modified;
            _context.Attach(Turniej).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return RedirectToPage("/Organizator/EditTurniej", Turniej);
        }
    }
}
