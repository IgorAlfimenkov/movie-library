using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataObjects
{
    public interface IFilmDao
    {
        List<Film> GetFilmsByGenre(string genre);
        List<Film> GetFilmsByYear(int year);
        List<Film> GetBestFilms();
        List<Film> GetFilmsByActor(string actorname);
        Film GetFilm(string filmName);
        List<Film> GetAllFilms();

        void SaveFilm(string filename, Film film);
        void Save(List<Film> films);
        void Insert(Film filmname);
        /// new genre in film
        void Insert(Film film, Genre genre);
        /// new actor in film
        void Insert(Film film, Actor actor);
        /// Delete film by name
        void Delete(Film film);
        void Delete(Film film, Genre genre);
        void Delete(Film film, string actorname);
    }
}
