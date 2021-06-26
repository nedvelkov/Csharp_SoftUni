using MyWebServer.Common;

namespace MyWebServer.Http
{
   public  class HttpHeader
    {
        public HttpHeader(string name,string value)
        {
            Guard.AgaintsNull(name, nameof(name));
            Guard.AgaintsNull(value, nameof(value));

            this.Name = name;
            this.Value = value; 
        }
        public string Name { get; init; }
        public string Value { get; init; }

        public override string ToString()
        {
            return $"{this.Name}: {this.Value}";
        }
    }
}
