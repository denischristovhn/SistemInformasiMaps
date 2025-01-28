using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemMaps.Model;
using SistemMaps.Model;

namespace SistemMaps.Pages
{
    public class EditLokasiModel : PageModel
    {
        private readonly AppDbContext _context;

        public EditLokasiModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Formulir Formulir { get; set; }

        public IActionResult OnGet(int id)
        {
            Formulir = _context.Formulirs.Find(id);
            if (Formulir == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Form validation failed, show the page with errors
            }

            var existingFormulir = _context.Formulirs.Find(Formulir.Id);
            if (existingFormulir == null)
            {
                return NotFound();
            }

            existingFormulir.NamaLokasi = Formulir.NamaLokasi;
            existingFormulir.Alamat = Formulir.Alamat;
            existingFormulir.latitude = Formulir.latitude;
            existingFormulir.longitude = Formulir.longitude;

            _context.SaveChanges();
            return RedirectToPage("/LocationList");
        }
    }


}