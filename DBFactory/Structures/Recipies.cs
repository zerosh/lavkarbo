using DBFactory.Structures;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace DBFactory.Structures
{
    public class Recipe
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; }
        public ImageExtension FinishedMealImage { get; set; }
        public bool Published { get; set; }
        public string ShortDescription { get; set; }

        public Recipe()
        {
            FinishedMealImage = new ImageExtension();
        }

        public Recipe(string Name, int GroupId)
        {
            this.Name = Name;
            this.GroupId = GroupId;
            FinishedMealImage = new ImageExtension();
        }
    }
}
