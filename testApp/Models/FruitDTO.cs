using System;
using System.ComponentModel.DataAnnotations;

namespace testApp.Models
{
    public class FruitDTO : Freshness
    {
        public FruitDTO(int Id, string Name, double Price, bool InStock, DateTime DeliveredDate)
        {
            this.Id = Id;
            this.Name = Name;
            this.Price = Price;
            this.InStock = InStock;
            this.DeliveredDate = DeliveredDate;
        }

        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Price")]
        public double Price { get; set; }

        [Display(Name = "In stock")]
        public bool InStock { get; set; }

        [Display(Name = "Delivered")]
        public DateTime DeliveredDate { get; set; }

        [Display(Name = "Days in stock")]
        public int DaysPassed { get; set; }

        public override void ExpiredDate(DateTime date)
        {
            TimeSpan span = date.Subtract(this.DeliveredDate);
            this.DaysPassed = span.Days;
        }
    }
}
