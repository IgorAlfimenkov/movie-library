using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataObjects
{
    public class FilmDao : IFilmDao
    {
        static Database db = Database.GetInstance();

        public List<Film> GetFilmsByGenre(string genreName)
        {
            List<Film> sortedfilms = new List<Film>();
            foreach (Film film in db.Films)
            {
                foreach (Genre genre in film.genres)
                {
                    if (genre.Name.ToLower().Equals(genreName.ToLower()))
                    {
                        sortedfilms.Add(film);
                    }
                }
            }
            return sortedfilms;
        }

        public List<Film> GetFilmsByActor(string actorname)
        {
            List<Film> sortedfilms = new List<Film>();
            foreach (Film film in db.Films)
            {
                foreach (Actor actor in film.actors)
                {
                    if (actor.Name.ToLower().Equals(actorname.ToLower()))
                    {
                        sortedfilms.Add(film);
                    }
                }
            }
            return sortedfilms;
        }

        public List<Film> GetFilmsByYear(int year)
        {
            List<Film> sortedfilms = new List<Film>();
            foreach (Film film in db.Films)
            {
                if (film.Year.Equals(year))
                {
                    sortedfilms.Add(film);
                }
            }
            return sortedfilms;
        }

        public List<Film> GetBestFilms()
        {
            List<Film> sortedfilms = new List<Film>();
            foreach (Film film in db.Films)
            {
                if (film.Rating > 8.4)
                {
                    sortedfilms.Add(film);
                }
            }
            return sortedfilms;
        }

        public Film GetFilm(string filmname)
        {
            foreach (Film film in db.Films)
            {
                if (film.Name.ToLower().Equals(filmname.ToLower()))
                {
                    return film;
                }
            }
            return null;
        }

        public List<Film> GetAllFilms()
        {
            return db.Films;
        }

        public void Insert(Film film)
        {
            db.Insert(film);
        }
        public void Delete(Film film)
        {
            db.Delete(film);
        }
        public void Insert(Film film, Genre genre)
        {
            db.Insert(film, genre);
        }

        public void Insert(Film film, Actor actor)
        {
            db.Insert(film, actor);
        }



        public void Delete(Film film, Genre genre)
        {
            db.Delete(film, genre);
        }

        public void Delete(Film film, string actorname)
        {
            db.Delete(film, actorname);
        }
        public void Save(List<Film> films)
        {
            db.Save(films);
        }
        public void SaveFilm(string filename, Film film)
        {
            //db.SaveFilm(filename, film);
        }
    }
}
