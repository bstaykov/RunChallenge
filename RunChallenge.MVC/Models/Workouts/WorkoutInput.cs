namespace RunChallenge.MVC.Models.Workouts
{
    using System.ComponentModel.DataAnnotations;
    using System;

    public class WorkoutInput
    {
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
        public int Minutes { get; set; }

        [Required(ErrorMessage = "Seconds is required!")]
        [RegularExpression(@"^([0-9]|[1-5][0-9])$", ErrorMessage = "Invalid Seconds!")]
        public int Seconds { get; set; }

        [Required(ErrorMessage = "Location is required!")]
        [RegularExpression(@"^[0-9a-zA-Z\. ]{5,20}$", ErrorMessage = "Invalid Location!")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Comment is required!")]
        [RegularExpression(@"^[0-9a-zA-Z\. '!?]{5,100}$", ErrorMessage = "Invalid Comment!")]
        public string Comment { get; set; }

        //[Required(ErrorMessage = "Date is required!")]
        ////[CustomValidation()]
        //public DateTime Date { get; set; }

        //[Required(ErrorMessage = "Year is required!")]
        //public int Year { get; set; }

        //[Required(ErrorMessage = "Month is required!")]
        //public int Month { get; set; }

        //[Required(ErrorMessage = "Day is required!")]
        //public int Day { get; set; }
    }
}