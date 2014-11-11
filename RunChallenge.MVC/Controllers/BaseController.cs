using RunChallenge.Data;
using RunChallenge.Models;
using RunChallenge.MVC.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RunChallenge.MVC.Controllers
{
    [Log]
    public abstract class BaseController : Controller
    {


        ////protected RunChallengeData Data { get; set; }

        ////protected User CurrentUser { get; set; }  

        //[NonAction]
        //public void SystemSettings()
        //{

        //}

        //[ChildActionOnly] // action, can be called only by other actions
        //public void GetSome()
        //{

        //}
    }
}