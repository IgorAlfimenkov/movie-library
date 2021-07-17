using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XmlConfiguration;
using System.Xml.Linq;
using System.Xml.Serialization;
using BusinessObjects;

namespace DataObjects
{
    [Serializable]
    [XmlInclude(typeof(Film))]
    public class Database
    {
        public Database()
        {

        }
        public static string filename { get; set; }
        static Database instance;


        public List<Actor> Actors = new List<Actor>();
        public List<Genre> Genres = new List<Genre>();
        public List<Film> Films = new List<Film>();

        public Database(string filename)
        {
            if (filename == null)
            {
                filename = "data.xml";
            }
            else
            {
                Database.filename = filename;
                Films = new List<Film>();
                Actors = new List<Actor>();
                Genres = new List<Genre>();
                Read(filename);
            }
        }

        private void Read(string filename)
        {
            XDocument xdoc = XDocument.Load(filename);
            foreach (XElement film in xdoc.Element("Database").Elements("Film"))
            {
                Film f = new Film();
                f.Name = film.Element("Name").Value;
                f.Company = film.Element("Company").Value;
                f.Year = Convert.ToInt32(film.Element("Year").Value);
                f.Description = film.Element("Description").Value;
                f.Duration = Convert.ToInt32(film.Element("Duration").Value);
                f.Rating = Convert.ToDouble(film.Element("Rating").Value);
                f.Poster = film.Element("Poster").Value;
                f.Trailer = film.Element("Trailer").Value;
                foreach (XElement genre in film.Elements("Genre"))
                {
                    Genre g = new Genre();
                    g.Name = genre.Element("Name").Value;
                    f.genres.Add(g);
                    if (!this.Genres.Contains(g)) this.Genres.Add(g);
                }
                foreach (XElement actor in film.Elements("Actor"))
                {
                    Actor a = new Actor();
                    a.Name = actor.Element("Name").Value;
                    f.actors.Add(a);
                    if (!this.Actors.Contains(a)) this.Actors.Add(a);
                }
                Films.Add(f);
            }

        }
        public static Database GetInstance()
        {
            if (instance == null) return new Database(filename);
            return instance;
        }

        public void Insert(Film film)
        {
            //Films.Add(film);
            if (!Films.Contains(film))
            {
                Films.Add(film);
            }

        }


        public void Insert(Film film, Genre genre)
        {
            int rep = 0;
            foreach (Film f in this.Films)
            {
                if (f.Name.Equals(film))
                {
                    foreach (Genre g in f.genres)
                    {
                        if (g.Name.ToLower().Equals(genre.Name.ToLower()))
                        {
                            rep++;
                        }
                    }
                    if (rep == 0)
                    {
                        film.genres.Add(genre);
                    }
                }
            }

        }

        public void Insert(Film film, Actor actor)
        {
            int rep = 0;
            foreach (Film f in this.Films)
            {
                if (f.Name.Equals(film))
                {
                    foreach (Actor a in f.actors)
                    {
                        if (a.Name.ToLower().Equals(actor.Name.ToLower()))
                        {
                            rep++;
                        }
                    }
                    if (rep == 0)
                    {
                        film.actors.Add(actor);
                    }
                }
            }

        }

        public void Delete(Film film)
        {
            this.Films.Remove(film);
        }
        public void Save(List<Film> Allfilms)
        {

            XmlDocument xdoc = new XmlDocument();
            xdoc.Load("data.xml");
            XmlElement xRoot = xdoc.DocumentElement;
            xRoot.RemoveAll();
            xdoc.Save("data.xml");
            foreach (Film f in Allfilms)
            {
                XmlElement Film = xdoc.CreateElement("Film");

                XmlElement Name = xdoc.CreateElement("Name");
                XmlText nameText = xdoc.CreateTextNode(f.Name);
                Name.AppendChild(nameText);
                Film.AppendChild(Name);

                XmlElement Company = xdoc.CreateElement("Company");
                XmlText companyText = xdoc.CreateTextNode(f.Company);
                Company.AppendChild(companyText);
                Film.AppendChild(Company);

                XmlElement Year = xdoc.CreateElement("Year");
                XmlText yearText = xdoc.CreateTextNode(Convert.ToString(f.Year));
                Year.AppendChild(yearText);
                Film.AppendChild(Year);

                XmlElement Description = xdoc.CreateElement("Description");
                XmlText descriptionText = xdoc.CreateTextNode(f.Description);
                Description.AppendChild(descriptionText);
                Film.AppendChild(Description);

                XmlElement Duration = xdoc.CreateElement("Duration");
                XmlText durationText = xdoc.CreateTextNode(Convert.ToString(f.Duration));
                Duration.AppendChild(durationText);
                Film.AppendChild(Duration);

                XmlElement Rating = xdoc.CreateElement("Rating");
                XmlText ratingText = xdoc.CreateTextNode(Convert.ToString(f.Rating));
                Rating.AppendChild(ratingText);
                Film.AppendChild(Rating);

                XmlElement Poster = xdoc.CreateElement("Poster");
                XmlText posterText = xdoc.CreateTextNode(f.Poster);
                Poster.AppendChild(posterText);
                Film.AppendChild(Poster);

                XmlElement Trailer = xdoc.CreateElement("Trailer");
                XmlText trailerText = xdoc.CreateTextNode(f.Trailer);
                Trailer.AppendChild(trailerText);
                Film.AppendChild(Trailer);

                foreach (Genre g in f.genres)
                {
                    XmlElement Genre = xdoc.CreateElement("Genre");
                    XmlElement gName = xdoc.CreateElement("Name");
                    XmlText gNameText = xdoc.CreateTextNode(g.Name);
                    gName.AppendChild(gNameText);
                    Genre.AppendChild(gName);
                    Film.AppendChild(Genre);
                }

                foreach (Actor a in f.actors)
                {
                    XmlElement Actor = xdoc.CreateElement("Actor");
                    XmlElement aName = xdoc.CreateElement("Name");
                    XmlText aNameText = xdoc.CreateTextNode(a.Name);
                    aName.AppendChild(aNameText);
                    Actor.AppendChild(aName);
                    Film.AppendChild(Actor);
                }
                xRoot.AppendChild(Film);
                xdoc.Save("data.xml");
            }
        }
        public void Delete(Film film, Genre genre)
        {
            foreach (Film f in this.Films)
            {
                if (f.Name.Equals(film))
                {
                    foreach (Genre g in f.genres)
                    {
                        if (g.Name.ToLower().Equals(genre.Name.ToLower()))
                        {
                            f.genres.Remove(g);
                        }
                    }
                }
            }
        }

        public void Delete(Film film, Actor actor)
        {
            foreach (Film f in Films)
            {
                if (f.Name.Equals(film))
                {
                    foreach (Actor a in f.actors)
                    {
                        if (a.Name.ToLower().Equals(actor.Name.ToLower()))
                        {
                            f.actors.Remove(a);
                        }
                    }
                }
            }
        }

        public void Delete(Film film, string actorname)
        {
            foreach (Actor a in film.actors)
            {
                if (a.Name == actorname)
                {
                    film.actors.Remove(a);
                }
            }
        }

        private void Clear(string filname)
        {
            XDocument xDoc = XDocument.Load(filname);
            foreach (XElement f in xDoc.Element("Database").Elements("Film"))
            {
                f.RemoveAll();
                f.Remove();
            }
        }

        public void SaveCatalog(string filename, Database db)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Database));

            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, db);
            }
        }

        public List<Film> SortByYearOldToHNew()
        {
            List<Film> sortedfilms = new List<Film>();
            Films.Sort(Film.FilmComparer);
            foreach (Film f in Films)
            {
                sortedfilms.Add(f);
            }
            return sortedfilms;
        }

        public List<Film> SortByYearNewToOld()
        {
            List<Film> sortedfilms = new List<Film>();
            Films.Sort();
            foreach (Film f in Films)
            {
                sortedfilms.Add(f);
            }
            return sortedfilms;
        }

        public List<Film> SortByRatingFromLow()
        {
            List<Film> sortedfilms = new List<Film>();
            Films.Sort(Film.FilmComparer1);
            foreach (Film f in Films)
            {
                sortedfilms.Add(f);
            }
            return sortedfilms;
        }

        public List<Film> SortByRatingFromHigh()
        {
            List<Film> sortedfilms = new List<Film>();
            Films.Sort(Film.FilmComparer2);
            foreach (Film f in Films)
            {
                sortedfilms.Add(f);
            }
            return sortedfilms;
        }
    }
}
