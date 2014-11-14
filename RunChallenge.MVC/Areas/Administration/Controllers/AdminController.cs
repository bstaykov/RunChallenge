namespace RunChallenge.MVC.Areas.Administration.Controllers
{
    using RunChallenge.MVC.Controllers;
    using System.Web.Mvc;

    [Authorize(Roles = "Admin")]
    public abstract class AdminController :BaseController
    {
        //public AdminController(IRunChallengeData data)
        //{

        //}
    }
}