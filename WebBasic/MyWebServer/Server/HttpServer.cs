namespace MyWebServer.Server
{
    using MyWebServer.Server.Http;
    using MyWebServer.Server.Routing;
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;

    public class HttpServer
    {
        private readonly IPAddress ipAddress;
        private readonly int port;
        private readonly TcpListener listener;
        public HttpServer(string ipAddres, int port, Action<IRoutingTable> routingTable)
        {
            // local host IP address
            this.ipAddress = IPAddress.Parse(ipAddres);
            // port
            this.port = port;

            this.listener = new TcpListener(ipAddress, port);
        }
        public HttpServer(int port, Action<IRoutingTable> routingTable)
            :this("127.0.0.1",port,routingTable)
        {
            this.port = port;
        }
        public HttpServer(Action<IRoutingTable> routingTable) 
            : this(9090,routingTable)
        {

        }

        public async Task Start()
        {

            listener.Start();

            Console.WriteLine($"Server started on port {port}....");
            Console.WriteLine("Listening for requests ....");
            while (true)
            {

                var connection =await listener.AcceptTcpClientAsync();

                Console.WriteLine("Connected...");

                var networkStream = connection.GetStream();

                var requestText = await ReadRequest(networkStream);

                Console.WriteLine(requestText);
                
              // var request = HttpRequest.Parse(requestText);

                


                await this.WriteResponse(networkStream);

                connection.Close();
            }
        }

        private async Task<string> ReadRequest(NetworkStream networkStream)
        {
            var requestBuilder = new StringBuilder();
            var bufferLength = 1024;
            var buffer = new byte[bufferLength];

            var totalBytes = 0;
            do
            {
                var bytesRead = await networkStream.ReadAsync(buffer, 0, bufferLength);
                totalBytes += bytesRead;
                if (totalBytes > 10 * 1024)
                {
                    throw new InvalidOperationException("Request is too large");
                }

                requestBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));

            } while (networkStream.DataAvailable);

            return requestBuilder.ToString();
        }

        private async Task WriteResponse(NetworkStream networkStream)
        {
            var content = @"
<html>
    <head><link rel=""icon"" href="" data:,"" /></head>
            <body>
Hello from server!
</body>
</html>";
            var contentLenght = Encoding.UTF8.GetByteCount(content);

            string response = $@"HTTP/1.1 200 OK
Date: {DateTime.UtcNow.ToString("r")}
Server: My Web Server
Content-Length: {contentLenght}
Content-Type: text/html

{content}";

            var responseBytes = Encoding.UTF8.GetBytes(response);

            await networkStream.WriteAsync(responseBytes);
        }

    }
}
