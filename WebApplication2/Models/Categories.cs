using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Categories
    {
        [Key]
        public int CateID { get; set; }
        public String Name { get; set; }
        public Categories()
        {
            // Parameterless constructor
        }

        public Categories(int cateID, string name)
        {
            CateID = cateID;
            Name = name;
        }
    }
}
