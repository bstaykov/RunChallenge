namespace RunChallenge.MVC
{
    using System.Web.Mvc;

    class ViewenginesConfiguration
    {
        internal static void RegisterViewEngines(ViewEngineCollection viewEngineCollection)
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }
    }
}
