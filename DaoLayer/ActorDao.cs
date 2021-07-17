using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataObjects
{
    public class ActorDao : IActorDao
    {
        static Database db = Database.GetInstance();

        public List<Actor> GetActors()
        {
            return db.Actors;
        }

        public List<Actor> GetActorsByFilm(Film film)
        {
            return film.actors;
        }
    }
}
