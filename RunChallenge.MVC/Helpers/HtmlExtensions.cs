namespace RunChallenge.MVC.Helpers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using System.Web.Routing;

    public static class HtmlExtensions
    {
        public static MvcHtmlString Submit(this HtmlHelper helper, string value = "Submit", object htmlAttributes = null)
        {
            var input = new TagBuilder("input");
            var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes) as IDictionary<string, string>;
            input.MergeAttributes(attributes);
            input.Attributes.Add("value", value);
            input.Attributes.Add("type", "submit");
            return new MvcHtmlString(input.ToString());
        }
    }
}