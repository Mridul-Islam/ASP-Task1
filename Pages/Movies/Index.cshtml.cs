using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

// add for made the search option ---- selectlist require this
using Microsoft.AspNetCore.Mvc.Rendering;
// add for use [bindproperty] and SupportsGet 
using Microsoft.AspNetCore.Mvc;
// use this for create LINQ query
using System.Linq;


namespace RazorPagesMovie.Pages.Movies
{
    #region snippet1
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;

        public IndexModel(RazorPagesMovie.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        #endregion
        public IList<Movie> Movie { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string MovieGenre { get; set; }


        public async Task OnGetAsync()
        {
            // code for seach movie by name
            var movies = from m in _context.Movie
                select m;
            if(!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            Movie = await movies.ToListAsync();


            // code for search movie by Genre
            IQueryable<string> genreQuery = from m in _context.Movie
                                                    orderby m.Genre
                                                    select m.Genre;
            if(!string.IsNullOrEmpty(MovieGenre)){
                movies = movies.Where(x => x.Genre == MovieGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());


            // Default code
            //Movie = await _context.Movie.ToListAsync();
        }
    }
}
