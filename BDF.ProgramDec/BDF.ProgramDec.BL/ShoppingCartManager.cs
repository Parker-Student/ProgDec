using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BDF.ProgramDec.BL.Models;

namespace BDF.ProgramDec.BL
{
    public static class ShoppingCartManager
    {
        public static void Checkout(ShoppingCart cart)
        {

            Order order = new Order();
            order.CustomerId = 1;
            OrderManager.Insert(order, cart.Items);
            cart.Checkout();



            // For DVDCentral, do these things when you checkout
            // 1. Insert an tblOrder. Get the tblOrder.Id
            // 2. Loop through the Items, and insert a tblOrderItem record with the new Order.Id
            // 3. Remove the item from the cart.
        }
        public static void Add(ShoppingCart cart, Models.ProgDec progDec)
        {

            cart.Add(progDec);
        }

        public static void Remove(ShoppingCart cart, Models.ProgDec progDec)
        {
            cart.Remove(progDec);
        }



    }
}
