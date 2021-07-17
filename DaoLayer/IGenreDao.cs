using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataObjects
{
    public interface IGenreDao
    {
        List<Genre> GetGenres();
        List<Genre> GetGenresByFilm(string filmname);
        List<Genre> GetGenresByFilm(Film film);
    }
}
