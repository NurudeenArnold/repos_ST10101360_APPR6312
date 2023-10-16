using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class MonetaryDonations
    {
        [Key]
        public int MDonID { get; set; }
        public DateTime Date { get; set; }
        public Double Amount { get; set; }
        public String DonorName { get; set; }
        public MonetaryDonations()
        {
            // Parameterless constructor
        }
        public MonetaryDonations(int mDonID, DateTime date, double amount, string donorName)
        {
            MDonID = mDonID;
            Date = date;
            Amount = amount;
            DonorName = donorName;
        }
    }
}
