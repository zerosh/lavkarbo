using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFactory.Structures
{
    public class Recipe
    {
        [Key]
        public int ID { get; private set; }
        public string Name { get; set; }
        public int GroupId { get; set; }
        public byte[] Image { get; set; }
        public Recipe()
        {
        }

        public Recipe(string Name, int GroupId)
        {
            this.Name = Name;
            this.GroupId = GroupId;
        }
    }
}
