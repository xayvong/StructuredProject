using CKK.Logic.Interfaces;
using CKK.Logic.Models;
using CKK.Persistance.Interfaces;
using CKK.Persistance.Models;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace CKK.MockClient
{
    class Program
    {
        private static IShoppingCart cart = new ShoppingCart(new Customer());
        private static IStore store = new FileStore();
        static void Main(string[] args)
        {
            if(store is ILoadable file)
            {
                file.Load();
            }
            Console.WriteLine("Welcome to Corey's Knick Knacks!");
            var input = "";
            while (input != "5")
            {
                Console.WriteLine(GetMenu());
                input = Console.ReadLine();
                Console.Clear();
                switch (input)
                {
                    case "1":
                        ShowShoppingCartItems();
                        break;
                    case "2":
                        AddProductToCart();
                        break;
                    case "3":
                        RemoveFromCart();
                        break;
                    case "4":
                        CheckOut();
                        break;
                    case "5":

                        break;
                }
            }

            Console.WriteLine("Thanks for coming!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();


        }
        public static void ShowShoppingCartItems()
        {
            Console.WriteLine("------------------");
            if (cart.GetProducts().Count <= 0)
            {
                Console.WriteLine("There is nothing in your Shopping Cart!");
                Console.WriteLine("------------------");
                return;
            }
            Console.WriteLine("The Items in your shopping cart are:");
            var count = 0;
            foreach (var item in cart.GetProducts())
            {
                Console.WriteLine($"{count++}) {item}");
            }
            Console.WriteLine("------------------");
        }

        public static void ShowStoreItems()
        {
            if(store is ILoadable fileStore)
            {
                fileStore.Load();
            }
            Console.WriteLine("------------------");
            if(store.GetStoreItems().Count <= 0)
            {
                Console.WriteLine("There is nothing in your store!");
                Console.WriteLine("------------------");
                return;
            }
            Console.WriteLine("The items in your store are:");
            var count = 0;
            foreach (var item in store.GetStoreItems())
            {
                Console.WriteLine($"{count++}) {item}");
            }
            Console.WriteLine("------------------");
        }

        public static void AddProductToCart()
        {
            ShowStoreItems();
            Console.WriteLine("Which Item would you like to add?");
            var input = int.Parse(Console.ReadLine());
            var selectedItem = store.GetStoreItems()[input];
            cart.AddProduct(selectedItem.GetProduct(), 1);
            Console.Clear();
            Console.WriteLine("Item Added.");
        }

        public static void RemoveFromCart()
        {
            Console.WriteLine("The items in your cart are: ");
            Console.WriteLine("------------------");
            var count = 0;
            foreach(var item in cart.GetProducts())
            {
                Console.WriteLine($"{count++}) {item}");
            }
            Console.WriteLine("------------------");
            Console.WriteLine("Which one would you like to remove?");
            var input = int.Parse(Console.ReadLine());
            cart.RemoveProduct(cart.GetProducts()[input].GetProduct().GetId(), 1);
        }


        public static void CheckOut()
        
        {
            byte[] buffer = new byte[8192];
            
            try
            {
                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPEndPoint remoteEndPoint = new(ipAddress, 11000);

                Socket senderSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    senderSocket.Connect(remoteEndPoint);
                    Console.WriteLine($"Connected to Server...");
                    byte[] msg = JsonSerializer.SerializeToUtf8Bytes<object>(cart);
                    int bytesSent = senderSocket.Send(msg);

                    int bytesRec = senderSocket.Receive(buffer);
                    //Write the message that is sent from the server.
                    Console.WriteLine(Encoding.ASCII.GetString(buffer));                    
                } catch (ArgumentNullException ane)
                {
                    Console.WriteLine($"ArgumentNullException : {ane}");
                } catch (SocketException se)
                {
                    Console.WriteLine($"SocketException : {se}");
                }catch (Exception e)
                {
                    Console.WriteLine($"Unexpected exception : {e}");
                }
            }catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }


        public static string GetMenu()
        {
            return
                "What would you like to do?\n" +
                "1. View Shopping Cart\n" +
                "2. Add To Shopping Cart\n" +
                "3. Remove Product From Shopping Cart\n" +
                "4. CheckOut\n" +
                "5. Exit";
        }
    }
}
