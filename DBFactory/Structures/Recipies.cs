using DBFactory.Structures;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace DBFactory.Structures
{
    public class Recipe
    {
        [Key]
        public int ID { get; private set; }
        public string Name { get; set; }
        public int GroupId { get; set; }
        public ImageExtension FinishedMealImage { get; set; }

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
