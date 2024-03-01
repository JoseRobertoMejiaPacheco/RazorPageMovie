//Revisar errores


//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.ConstrainedExecution;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using RazorPageMovie.Data;
//using RazorPageMovie.Models;
//using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

//namespace RazorPageMovie.Pages.Movies
//{
//    public class IndexModel : PageModel
//    {
//        private readonly RazorPageMovie.Data.RazorPageMovieContextDb _context;

//        public IndexModel(RazorPageMovie.Data.RazorPageMovieContextDb context)
//        {
//            _context = context;
//            // Inicializa la propiedad Genres con una lista vacía para evitar la excepción
//            Genres = new SelectList(new List<string>());
//        }
//        public IList<Movie> Movie { get;set; } = default!;
//        //Cuando se especifica SupportsGet = true, indica que la propiedad debe ser enlazada desde la cadena de consulta(query string) de la solicitud GET.Por lo tanto, cuando se envía una solicitud GET al controlador y el modelo tiene propiedades decoradas con[BindProperty(SupportsGet = true)], ASP.NET Core enlazará automáticamente los valores de la cadena de consulta a esas propiedades.
//        [BindProperty(SupportsGet = true)]
//        public string? SearchString { get; set; }
//        [BindProperty(SupportsGet = true)]
//        public SelectList? Genres { get; set; }

//        [BindProperty(SupportsGet = true)]
//        public string? MovieGenre { get; set; }

//        public async Task OnGetAsync()
//        {
//            //Movie = await _context.Movie.ToListAsync();
//            var movies = from movie in _context.Movie select movie;
//            if (!string.IsNullOrEmpty(SearchString))
//            {
//                movies = movies.Where(s => s.Title.Contains(SearchString));

//            }
//            if  (_context.Movie != null)
//            {
//                Movie = await movies.ToListAsync();
//            }
//        }
//    }
//}


using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPageMovie.Data;
using RazorPageMovie.Models;

namespace RazorPageMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPageMovieContextDb _context;

        public IndexModel(RazorPageMovieContextDb context)
        {
            _context = context;

            // Inicializa la propiedad Genres con una lista vacía para evitar la excepción
            Genres = new SelectList(new List<string>());
        }

        public IList<Movie> Movie { get; set; } = new List<Movie>();

        // Especifica SupportsGet = true para permitir que esta propiedad sea enlazada desde la cadena de consulta (query string) de la solicitud GET
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? MovieGenre { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> genereQuery = from m in _context.Movie orderby m.Genre
                                       select m.Genre;

            IQueryable<Movie> movies = from m in _context.Movie
                                       select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(x => x.Genre == MovieGenre);
            }
            if (_context.Movie != null)
            {
                
                Genres = new SelectList(await genereQuery.Distinct().ToListAsync());
                Movie = await movies.ToListAsync();
            }

            
        }
    }
}
