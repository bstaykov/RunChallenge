namespace RunChallenge.Web.Infrastructure
{
    using Html;
    
    public class HtmlSanitizerAdapter : ISanitizer
    {
        public string Sanitize(string html)
        {
            var sanitiser = new HtmlSanitizer();
            var result = sanitiser.Sanitize(html);
            return result;
        }
    }
}
