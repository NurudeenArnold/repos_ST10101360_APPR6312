using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Disasters
    {
        [Key]
        public int DisID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public String Location { get; set; }
        public String Description { get; set; }
        public String AidType { get; set; }
        public Disasters()
        {
            // Parameterless constructor
        }

        public Disasters(int disID, DateTime startDate, DateTime endDate, string location, string description, string aidType)
        {
            DisID = disID;
            StartDate = startDate;
            EndDate = endDate;
            Location = location;
            Description = description;
            AidType = aidType;
        }
    }
}
