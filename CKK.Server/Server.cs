using CKK.Logic.Interfaces;
using CKK.Logic.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace CKK.Server
{
    class Server
    {
        private static Queue<Order> ShoppingQueue = new();
        public static void StartListening()
        {
            byte[] buffer = new byte[8192];

            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress iPAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(iPAddress, 11000);

            Socket listenerSocket = new(iPAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);


            try
            {
                listenerSocket.Bind(localEndPoint);
                listenerSocket.Listen();

                while(true)
                {
                    Console.WriteLine($"Waiting for a connection on {iPAddress}:11000...");
                    Socket handler = listenerSocket.Accept();
                    Order order = null;
                    byte[] msg = null;
                    while(true)
                    {
                        int bytesRecieved = handler.Receive(buffer);
                        var utf8Reader = new Utf8JsonReader(buffer);
                        try
                        {
                            var json = (JsonElement)JsonSerializer.Deserialize<object>(ref utf8Reader);
                            order = json.ToObject<Order>();
                        //    order = new OrderSummary(cart);
                            msg = Encoding.Default.GetBytes($"Successfully added order to the Queue. There are :'{ShoppingQueue.Count}' orders ahead of you.");
                        }
                        catch(Exception)
                        {
                            try
                            {
                                var json = (JsonElement)JsonSerializer.Deserialize<object>(ref utf8Reader);
                                order = json.ToObject<Order>();
                                msg = Encoding.Default.GetBytes($"Successfully added order to the Queue. There are : '{ShoppingQueue.Count}' orders ahead of you.");
                            }catch (Exception)
                            {
                                Console.WriteLine("Object failed to deserialize.");
                                msg = Encoding.Default.GetBytes("Object Failed to be processed.");
                            }                            
                        }
                        break;
                    }
                    if (order != null)
                    {
                        ShoppingQueue.Enqueue(order);
                        Console.WriteLine($"Order Recieved!");
                        Console.WriteLine($"There are a total of {ShoppingQueue.Count} Orders in queue. ");
                    }
                    else
                    {
                        Console.WriteLine("Failed to Add ShoppingCart");
                    }
                    handler.Send(msg);
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();

                }
            }catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nPress ENTER to continue...");
            Console.Read();
        }

        static void Main(string[] args)
        {
            StartListening();
        }
    }

    static class JsonExtension
    {
        public static T ToObject<T>(this JsonElement element)
        {
            var json = element.GetRawText();
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
