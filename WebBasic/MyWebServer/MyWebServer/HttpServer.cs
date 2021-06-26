namespace MyWebServer
{
    using MyWebServer.Http;
    using MyWebServer.Routing;
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

        private readonly RoutingTable routingTable;

        public HttpServer(string ipAddres, int port, Action<IRoutingTable> routingTableConfiguration)
        {
            // local host IP address
            this.ipAddress = IPAddress.Parse(ipAddres);
            // port
            this.port = port;

            this.listener = new TcpListener(ipAddress, port);

            this.routingTable = new RoutingTable();
            routingTableConfiguration(this.routingTable);
        }
        public HttpServer(int port, Action<IRoutingTable> routingTable)
            : this("127.0.0.1", port, routingTable)
        {
            this.port = port;
        }
        public HttpServer(Action<IRoutingTable> routingTable)
            : this(9090, routingTable)
        {

        }

        public async Task Start()
        {

            listener.Start();

            Console.WriteLine($"Server started on port {port}....");
            Console.WriteLine("Listening for requests ....");
            while (true)
            {

                var connection = await listener.AcceptTcpClientAsync();

                Console.WriteLine("Connected...");

                var networkStream = connection.GetStream();

                var requestText = await ReadRequest(networkStream);

              //  Console.WriteLine(requestText);

                var request = HttpRequest.Parse(requestText);

                var response = this.routingTable.ExecuteResponse(request);


                await this.WriteResponse(networkStream,response);

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

        private async Task WriteResponse(NetworkStream networkStream, HttpResponse response)
        {
            

            var responseBytes = Encoding.UTF8.GetBytes(response.ToString());

            await networkStream.WriteAsync(responseBytes);
        }

    }
}
