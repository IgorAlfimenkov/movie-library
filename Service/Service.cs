using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using BusinessObjects;
using DataObjects;

namespace ServiceLayer
{
    public class Service : IService
    {
        static readonly IGenreDao genreDao = new GenreDao();
        static readonly IFilmDao filmDao = new FilmDao();
        static readonly IActorDao actorDao = new ActorDao();

        public List<Genre> GetGenres()
        {
            return genreDao.GetGenres();
        }

        public List<Actor> GetActors()
        {
            return actorDao.GetActors();
        }

        public List<Film> GetBestFilms()
        {
            return filmDao.GetBestFilms();
        }

        public List<Film> GetFilmsByYear(int year)
        {
            return filmDao.GetFilmsByYear(year);
        }

        public List<Genre> GetGenresByFilm(Film film)
        {
            return genreDao.GetGenresByFilm(film);
        }
        public List<Genre> GetGenresByFilm(string filmname)
        {
            return genreDao.GetGenresByFilm(filmname);
        }

        public Film GetFilm(string filmname)
        {
            return filmDao.GetFilm(filmname);
        }

        public List<Film> GetAllFilms()
        {
            return filmDao.GetAllFilms();
        }


        public List<Film> GetFilmsByGenre(string genrename)
        {
            return filmDao.GetFilmsByGenre(genrename);
        }

        public List<Actor> GetActorsByfilm(Film film)
        {
            return actorDao.GetActorsByFilm(film);
        }

        public void Insert(Film film)
        {
            filmDao.Insert(film);
        }

        public void InsertGenreInFilm(Film film, Genre genre)
        {
            filmDao.Insert(film, genre);
        }

        public void InsertActorInActor(Film film, Actor actor)
        {
            filmDao.Insert(film, actor);
        }

        public void DeleteFilm(Film film)
        {
            filmDao.Delete(film);
        }

        public void DeleteGenreFromFilm(Film film, Genre genre)
        {
            filmDao.Delete(film, genre);
        }

        public void DeleteActorFromFilm(Film film, string actorname)
        {
            filmDao.Delete(film, actorname);
        }
        public void Save(List<Film> films)
        {
            filmDao.Save(films);
        }
        public List<Film> GetFilmsByActor(string actorname)
        {
            return filmDao.GetFilmsByActor(actorname);
        }


        public void SaveFilm(string filename, Film film)
        {
            filmDao.SaveFilm(filename, film);
        }
    }
}
