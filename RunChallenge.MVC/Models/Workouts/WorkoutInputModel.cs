namespace RunChallenge.MVC.Models.Workouts
{
    using System.ComponentModel.DataAnnotations;
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    public class WorkoutInputModel :IValidatableObject
    {
        public WorkoutInputModel()
        {
            this.Km = 5;
            this.Meters = 0;
            this.Hours = 0;
            this.Minutes = 30;
            this.Seconds = 0;
            this.Location = "SofiaMaina";
            this.Comment = "GustoMaina";
            this.Day = DateTime.Now.Day;
            this.Month = DateTime.Now.Month;
            this.Year = DateTime.Now.Year;
        }

        [Required(ErrorMessage = "Km is required!")]
        [RegularExpression(@"^([0-9]|[1-9][0-9]|[1-9][0-9][0-9])$", ErrorMessage = "Invalid Km!")]
        public int Km { get; set; }

        [Required(ErrorMessage = "Meters is required!")]
        [RegularExpression(@"^([0-9]|[1-9][0-9]|[1-9][0-9][0-9])$", ErrorMessage = "Invalid Meters!")]
        public int Meters { get; set; }

        [Required(ErrorMessage = "Hours is required!")]
        [RegularExpression(@"^([0-9]|[1-9][0-9])$", ErrorMessage = "Invalid Hours!")]
        public int Hours { get; set; }

        [Required(ErrorMessage = "Minutes is required!")]
        [RegularExpression(@"^([0-9]|[1-5][0-9])$", ErrorMessage = "Invalid Minutes!")]
        //[Range(0, 57)]
        public int Minutes { get; set; }

        [Required(ErrorMessage = "Seconds is required!")]
        [RegularExpression(@"^([0-9]|[1-5][0-9])$", ErrorMessage = "Invalid Seconds!")]
        public int Seconds { get; set; }

        [Required(ErrorMessage = "Location is required!")]
        [RegularExpression(@"^[0-9a-zA-Z\. s]{5,20}$", ErrorMessage = "Invalid Location!")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Comment is required!")]
        [RegularExpression(@"^[0-9a-zA-Z\. s'!?]{5,100}$", ErrorMessage = "Invalid Comment!")]
        public string Comment { get; set; }

        ////[Required(ErrorMessage = "Date is required!")]
        ////[UIHint("DateTime")]
        //public DateTime Date { get; set; }

        [Required(ErrorMessage = "Year is required!")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Month is required!")]
        public int Month { get; set; }

        [Required(ErrorMessage = "Day is required!")]
        public int Day { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Km == 0 && Meters == 0)
            {
                yield return new ValidationResult("Distance cant be '0 km' and '0 meters' !", new [] {"Km", "Meters"});
            }

            if (Hours == 0 && Minutes == 0 && Seconds == 0)
            {
                yield return new ValidationResult("Time cant be 0h 0min 0sec!", new[] { "Hours", "Minutes", "Seconds" });
            }

            DateTime date;
            string dataString = Month + "/" + Day + "/" + Year;
            string format = "M/d/yyyy";
            if (!(DateTime.TryParseExact(dataString, format, new CultureInfo("en-US"), DateTimeStyles.None, out date)))
            {
                yield return new ValidationResult("Invalid date!", new[] { "Day", "Month", "Year" });
            } 
            // TODO addDays(1) !!!
            else if (date > DateTime.Now.AddDays(1))
            {
                yield return new ValidationResult("Future date!", new[] { "Day", "Month", "Year" });
            }
        }
    }
}