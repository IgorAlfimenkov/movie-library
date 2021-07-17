using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataObjects
{
    public class GenreDao : IGenreDao
    {
        static Database db = Database.GetInstance();

        public List<Genre> GetGenres()
        {
            return db.Genres;
        }

        public List<Genre> GetGenresByFilm(Film film)
        {
            return film.genres;
        }

        public List<Genre> GetGenresByFilm(string film)
        {
            List<Genre> genres = new List<Genre>();
            return genres;
        }
    }
}
