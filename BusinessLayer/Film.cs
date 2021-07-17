using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    [Serializable]
    public class Film : IComparable<Film>
    {
        public List<Genre> genres = new List<Genre>();
        public List<Actor> actors = new List<Actor>();
        public string Name { get; set; }
        public string Company { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public int Duration { get; set; }
        public string Poster { get; set; }
        public string Trailer { get; set; }

        public Film()
        {

        }


        public Film(Film film)
        {
            this.Name = film.Name;
            this.Company = film.Company;
            this.Year = film.Year;
            this.Description = film.Description;
            this.Duration = film.Duration;
            this.Rating = film.Rating;
            this.Poster = film.Poster;
            this.Trailer = film.Trailer;
            this.genres = film.genres;
            this.actors = film.actors;
        }

        public override string ToString()
        {
            return $"Film: {Name} Company: {Company} Year: {Year} Description: {Description}  \n";
        }

        //public int CompareTo(Film other)
        //{
        //    if (this.Year > other.Year)
        //    {
        //        return 1;
        //    }
        //    if (this.Year < other.Year)
        //    {
        //        return -1;
        //    }
        //    else return 0; 
        //}
        public static int FilmComparer(Film FilmA, Film FilmB)
        {
            if (FilmA.Year > FilmB.Year)
            {
                return 1;
            }
            if (FilmA.Year < FilmB.Year)
            {
                return -1;
            }
            return 0;
        }
        public int CompareTo(Film other)
        {
            if (this.Year > other.Year)
            {
                return -1;
            }
            if (this.Year < other.Year)
            {
                return 1;
            }
            else return 0;
        }

        public static int FilmComparer1(Film FilmA, Film FilmB)
        {
            if (FilmA.Rating > FilmB.Rating)
            {
                return 1;
            }
            if (FilmA.Rating < FilmB.Rating)
            {
                return -1;
            }
            return 0;
        }

        public static int FilmComparer2(Film FilmA, Film FilmB)
        {
            if (FilmA.Rating > FilmB.Rating)
            {
                return -1;
            }
            if (FilmA.Rating < FilmB.Rating)
            {
                return 1;
            }
            return 0;
        }
    }
}

