using System;
using WebSocketSharp;

namespace WebSocketSharpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using ()
            {

            }

            var ws = new WebSocket("ws://simple-websocket-server-echo.glitch.me/");

            ws.Connect();
            ws.Send("Hello Server!");

            ws.OnMessage += WsOnMessage;

            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }

        private static void WsOnMessage(object? sender, MessageEventArgs e)
        {
            Console.WriteLine("Received from the server: " + e.Data);
        }
    }
}
