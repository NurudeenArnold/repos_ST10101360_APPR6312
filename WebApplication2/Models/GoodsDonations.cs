using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class GoodsDonations
    {
        [Key]
        public int GDonID { get; set; }
        public DateTime Date { get; set; }
        public int NumberOfItems { get; set; }
        public String Category { get; set; }
        public String Description { get; set; }
        public String DonorName { get; set; }
        public GoodsDonations()
        {
            // Parameterless constructor
        }
        public GoodsDonations(int gDonID, DateTime date, int numberOfItems, string category, string description, string donorName)
        {
            GDonID = gDonID;
            Date = date;
            NumberOfItems = numberOfItems;
            Category = category;
            Description = description;
            DonorName = donorName;
        }
    }
}
