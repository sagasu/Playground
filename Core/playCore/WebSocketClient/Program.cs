using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebSocketClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.ReadLine();

            using (var client = new ClientWebSocket())
            {
                var serviceUri = new Uri("ws://localhost:5000/send");
                var cts = new CancellationTokenSource();
                cts.CancelAfter(TimeSpan.FromSeconds(120));

                try
                {
                    await client.ConnectAsync(serviceUri, cts.Token);
                    var n = 0;
                    while (client.State == WebSocketState.Open)
                    {
                        Console.WriteLine("enter message");
                        var msg = Console.ReadLine();
                        if (!string.IsNullOrEmpty(msg))
                        {
                            var byteToSend = new ArraySegment<byte>(Encoding.UTF8.GetBytes(msg));
                            await client.SendAsync(byteToSend, WebSocketMessageType.Text, true, cts.Token);
                            var responseBuffer = new byte[1024];
                            var offset = 0;
                            var packet = 1024;
                            while (true)
                            {
                                var byteRecived = new ArraySegment<byte>(responseBuffer, offset, packet);
                                var response = await client.ReceiveAsync(byteRecived, cts.Token);
                                var responseMsg = Encoding.UTF8.GetString(responseBuffer, offset, response.Count);
                                Console.WriteLine(responseMsg);
                                if (response.EndOfMessage) break;
                            }
                        }
                    }
                }
                catch (WebSocketException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.ReadLine();
        }
    }
}
