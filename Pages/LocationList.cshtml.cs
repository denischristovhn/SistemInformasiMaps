using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemMaps.Model;
using System.Collections.Generic;
using System.Linq;

namespace SistemMaps.Pages
{
    public class LocationListModel : PageModel
    {
        private readonly AppDbContext _context;

        public LocationListModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Formulir> Locations { get; set; }

        public void OnGet()
        {
            // Fetch all the locations from the database
            Locations = _context.Formulirs.ToList();
        }

        public IActionResult OnPostDelete(int id)
        {
            // Find the location by Id
            var location = _context.Formulirs.FirstOrDefault(x => x.Id == id);
            if (location != null)
            {
                // Remove the location from the database
                _context.Formulirs.Remove(location);
                _context.SaveChanges();
            }

            // Redirect back to the same page to refresh the list
            return RedirectToPage();
        }
    }
}