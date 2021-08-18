using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CKK.Online.Models;
using CKK.Logic.Models;
using System.Text.Json;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using CKK.DB.Interfaces;

namespace CKK.Online.Controllers
{
    public class ShopController : Controller
    {
        private readonly IUnitOfWork UOW;
        public ShopController(IUnitOfWork uow)
        {
            UOW = uow;
        }

        [HttpGet]
        [Route("/Shop/ShoppingCart")]
        public IActionResult Index()
        {
            var model = new ShopModel(UOW);
            return View("ShoppingCart",model);
        }

        //public IActionResult CheckOutCustomer([FromQuery]int orderId) 
        //{
        //    string statusMessage = "";


        //    byte[] buffer = new byte[8192];

        //    try
        //    {
        //        IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
        //        IPAddress ipAddress = ipHostInfo.AddressList[0];
        //        IPEndPoint remoteEndPoint = new(ipAddress, 11000);

        //        Socket senderSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

        //        try
        //        {
        //            //senderSocket.Connect(remoteEndPoint);
        //            var order = UOW.Orders.GetByIdAsync(orderId);
        //            string msg2 = JsonSerializer.Serialize<object>(order,new JsonSerializerOptions { WriteIndented = true });
        //            byte[] msg = JsonSerializer.SerializeToUtf8Bytes<object>(order);
        //            int bytesSent = senderSocket.Send(msg);

        //            int bytesRec = senderSocket.Receive(buffer);
        //            //Write the message that is sent from the server.
        //            statusMessage = Encoding.ASCII.GetString(buffer).Substring(0, 100);
        //        }
        //        catch (ArgumentNullException ane)
        //        {
        //            statusMessage = "An Error has occurred with the server connection! Please hit the back button and try again.\n";
        //            statusMessage += $"ArgumentNullException : {ane}";
        //        }
        //        catch (SocketException se)
        //        {
        //            statusMessage = "An Error has occurred with the server connection! Please hit the back button and try again.\n";
        //            statusMessage += $"SocketException : {se}";
        //        }
        //        catch (Exception e)
        //        {
        //            statusMessage = "An Error has occurred with the server connection! Please hit the back button and try again.\n";
        //            statusMessage += $"Unexpected exception : {e}";
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        statusMessage = "An Error has occurred with the server connection! Please hit the back button and try again.\n";
        //        statusMessage += e.ToString();
        //    }

        //    var model = new CheckOutModel { StatusMessage = statusMessage.Trim('\0') };
        //    return View("Checkout", model);            
        //}


        public IActionResult CheckOutCustomer([FromQuery] int orderId)
        {
            string statusMessage = "";

            var order = UOW.Orders.GetByIdAsync(1).Result;
            var temp = UOW.ShoppingCarts.GetProducts(order.ShoppingCartId);
            var inventoryList = UOW.Products.GetAllAsync().Result;

            foreach (var item in temp)
            {
                Product prod = new();
                prod = inventoryList.Where(x => x.Id == item.ProductId).FirstOrDefault();

                prod.Quantity -= item.Quantity;

                UOW.Products.UpdateAsync(prod);

            }
            
            //clear shopping cart
            UOW.ShoppingCarts.Ordered(order.ShoppingCartId);

            var model = new CheckOutModel { StatusMessage = statusMessage.Trim('\0') };
            return View("Checkout",model);
        }


        [HttpGet]
        [Route("Shop/ShoppingCart/Add/{productId}")]
        public IActionResult Add([FromRoute]int productId, [FromQuery]int quantity)
        {
            var order = UOW.Orders.GetByIdAsync(1).Result;
            var test = UOW.ShoppingCarts.AddtoCart(order.ShoppingCartId, productId, quantity);
            //UOW.Complete();
            var total = UOW.ShoppingCarts.GetTotal(order.ShoppingCartId).ToString("c");
            return Ok(total);
        }
    }
}
