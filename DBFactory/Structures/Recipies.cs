using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFactory.Structures
{
    public class Recipe
    {
        public int ID { get; private set; }
        public string Name { get; set; }

        public Recipe()
        {

        }

        public Recipe(string Name)
        {
            this.Name = Name;
        }
    }
}
