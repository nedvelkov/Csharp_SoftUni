namespace MyWebServer.Responses
{
    public class HtmlResponse : ContetnResponse
    {
        public HtmlResponse(string text)
                    : base(text, "text/html; charset=UTF-8")
        {
        }
    }
}
