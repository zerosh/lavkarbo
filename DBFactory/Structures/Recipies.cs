using DBFactory.Structures;
using DBFactory.Structures.Utils;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace DBFactory.Structures
{
    public class Recipe
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public int GroupId { get; set; }
        public ImageExtension FinishedMealImage { get; set; }
        public bool Published { get; set; }
        public HTMLFormattedTextExtension ShortDescription { get; set; }

        public Recipe()
        {
            FinishedMealImage = new ImageExtension();
        }

        public Recipe(string Name, int GroupId)
        {
            this.Title = Name;
            this.GroupId = GroupId;
            FinishedMealImage = new ImageExtension();
        }
    }
}
