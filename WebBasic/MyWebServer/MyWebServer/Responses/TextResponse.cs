namespace MyWebServer.Responses
{
    using MyWebServer.Common;
    using MyWebServer.Http;
    using System.Text;

    public class TextResponse : ContetnResponse
    {
        public TextResponse(string text)
            : base(text, "text/plain; charset=UTF-8")
        {

        }
    }
}