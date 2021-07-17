using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    [Serializable]
    public class Actor
    {
        public string Name { get; set; }
        public Actor()
        {

        }

        public Actor(Actor actor)
        {
            this.Name = actor.Name;
        }

        public override string ToString()
        {
            return $"Actor: {Name}";
        }
    }
}
