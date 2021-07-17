using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace ServiceLayer
{
    public interface IService
    {
        List<Genre> GetGenres();
        List<Genre> GetGenresByFilm(Film film);
        List<Genre> GetGenresByFilm(string filmane);
        List<Film> GetFilmsByActor(string actorname);
        List<Film> GetAllFilms();
        ///Films
        Film GetFilm(string filmaname);
        List<Film> GetFilmsByGenre(string genrename);
        List<Film> GetBestFilms();
        List<Film> GetFilmsByYear(int year);
        //List<Actor> GetActors();
        List<Actor> GetActorsByfilm(Film film);
        void SaveFilm(string filename, Film film);
        void Save(List<Film> films);
        void Insert(Film film);
        void InsertGenreInFilm(Film film, Genre genre);
        void InsertActorInActor(Film film, Actor actor);
        void DeleteFilm(Film film);
        void DeleteGenreFromFilm(Film film, Genre genre);
        void DeleteActorFromFilm(Film film, string actorname);
    }
}
