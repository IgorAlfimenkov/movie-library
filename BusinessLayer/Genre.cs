using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    [Serializable]
    public class Genre
    {
        public string Name { get; set; }

        public Genre()
        {

        }

        public Genre(Genre genre)
        {
            this.Name = genre.Name;
        }

        public override string ToString()
        {
            return $"Genre: {Name}";
        }
    }
}