namespace RunChallenge.MVC.Models.Workouts
{
    using System;

    public class WorkoutItemModel
    {
        public string UserName { get; set; }

        public  float Distance { get; set; }

        public TimeSpan Time { get; set; }

        public string Location { get; set; }

        public DateTime Date { get; set; }

        public string Comment { get; set; }
    }
}