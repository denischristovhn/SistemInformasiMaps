using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemMaps.Model; // Adjust the namespace for your DbContext if needed

namespace SistemMaps.Pages
{
    public class FormNamaLokasiModel : PageModel
    {
        private readonly AppDbContext _context;

        public FormNamaLokasiModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string NamaLokasi { get; set; }

        [BindProperty]
        public string Alamat { get; set; }

        [BindProperty]
        public double Latitude { get; set; }

        [BindProperty]
        public double Longitude { get; set; }

        public string Message { get; set; }

        public void OnGet()
        {
            // Handle any logic for when the page is first loaded if needed
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // If model is invalid, stay on the current page
            }

            // Create a new Formulir object to store location data
            var formulir = new Formulir
            {
                NamaLokasi = NamaLokasi ,
                Alamat = Alamat,
                latitude = Latitude,
                longitude = Longitude
            };

            // Add the new location to the database
            _context.Formulirs.Add(formulir);
            _context.SaveChanges();

            // Provide feedback to the user
            Message = "Location added successfully!";
            return Page(); // Stay on the same page after form submission
        }
    }
}