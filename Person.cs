using System;

namespace Members
{
    public class Persons
    {
        public DateTime startDate { get; set;}
        public DateTime endDate { get; set;}

        public Persons(DateTime startDate, DateTime endDate)
        {
            this.startDate = startDate;
            this.endDate = endDate;
        }

        public virtual void Input()
        {
            Console.WriteLine("Enter start date: ");
            startDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter end date: ");
            endDate = DateTime.Parse(Console.ReadLine());
        }

        public virtual void Display()
        {
            Console.WriteLine("Start Date: " + startDate);
            Console.WriteLine("End Date: " + endDate);
        }
    }   
}