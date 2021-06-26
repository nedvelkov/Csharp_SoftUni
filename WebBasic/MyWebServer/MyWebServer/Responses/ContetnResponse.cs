namespace MyWebServer.Responses
{
    using System.Text;

    using MyWebServer.Common;
    using MyWebServer.Http;

    public class ContetnResponse : HttpResponse
    {
        public ContetnResponse(string text, string contentType)
            : base(HttpStatusCode.OK)
        {
            Guard.AgaintsNull(text);

            var contentLenght = Encoding.UTF8.GetByteCount(text).ToString();

            this.Headers.Add("Content-Type", contentType);
            this.Headers.Add("Content-Length", contentLenght);

            this.Content = text;
        }
    }
}
