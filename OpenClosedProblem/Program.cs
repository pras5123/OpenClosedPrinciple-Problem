using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosedProblem
{
   class Program
    {
        private static void Main(string[] args)
        {
            OrderItem objItem1 = new OrderItem
            {
                Identifier = "Each",
                Quantity = 1
            };
            OrderItem objItem2 = new OrderItem
            {
                Identifier = "Weight",
                Quantity = 2
            };
            OrderItem objItem3 = new OrderItem
            {
                Identifier = "Spec",
                Quantity = 4
            };
            ShoppingCart objCart = new ShoppingCart();
            objCart.Add(objItem1);
            objCart.Add(objItem2);
            objCart.Add(objItem3);
            decimal k = objCart.TotalAmount();
        }
    }


    public class OrderItem
    {
        public string Identifier { get; set; }
        public int Quantity { get; set; }
    }

    public enum PaymentMethod
    {
        CreditCard
        ,
        Cheque
    }

    public class PaymentDetails
    {
        public PaymentMethod PaymentMethod { get; set; }
        public string CreditCardNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string CardholderName { get; set; }
    }

    public class ShoppingCart
    {
        private readonly List<OrderItem> _orderItems;

        public ShoppingCart()
            //When we create instance of ShoppingCart class, Order Item will be initialized so that value can be assigned to it.
        {
            _orderItems = new List<OrderItem>();
        }

        public IEnumerable<OrderItem> OrderItems
            //To make OrderItem class IEnumerable (i.e to include it inside foreach loop ) we need this
        {
            get { return _orderItems; }
        }

        public void Add(OrderItem orderItem) //This is required to add the Order Item
        {
            _orderItems.Add(orderItem);
        }

        public decimal TotalAmount()
        {
            decimal total = 0m;
            foreach (OrderItem orderItem in OrderItems)
            {
                //Price per Unit Strategy
                if (orderItem.Identifier.StartsWith("Each")) //Write a function in each class
                {
                    //>> (above + below) = > create an interface with method name
                    total += orderItem.Quantity*4m; //Create a separate class for this calculation
                } // >> Repeat creating the class for each if else statement
                // >> Create a new class and add all the created classes to the interface inside this class constructor  
                //Price per Kilogram Strategy
                else if (orderItem.Identifier.StartsWith("Weight"))
                {
                    total += orderItem.Quantity*3m/1000; //1 kilogram
                }
                //Special price Strategy (Buy 3 get 1 free)
                else if (orderItem.Identifier.StartsWith("Spec"))
                {
                    total += orderItem.Quantity*.3m;
                    int setsOfFour = orderItem.Quantity/4;
                    total -= setsOfFour*.15m; //discount on groups of 4 items
                }
            }
            return total;
        }
    }
}


/*
 The TotalAmount function counts the total price in the cart. You can imagine that shops use many different strategies to calculate prices:

    Price per unit
    Price per unit of weight, such as price per kilogram
    Special discount prices: buy 3, get 1 for free
    Price depending on the Customer’s loyalty: loyal customers get 10% off

 *Such pricing rules are probably changing a lot in a real word business. Meaning that programmer will need to revisit this if-else statement 
 quite often to extend it with new rules and modify the existing ones. 
 That type of code gets quickly out of hand.
 
  *It would be a lot better if this particular method didn’t have to be modified at all. In other words we’d like to 
  apply OCP so that we don’t need to extend this particular code every time there’s a change in the pricing rules.
 
 * Extending the if-else statements can introduce bugs and the application must be re-tested. We’ll need to test the ShoppingCart whereas we’re only 
 interested in testing the pricing rule(s). 
 * Also, the pricing logic is tightly coupled with the ShoppingCart domain. Therefore if we change the pricing logic in the ShoppingCart object we’ll need to test all other objects 
 * that depend on ShoppingCart even if they absolutely have nothing to do with pricing rules. A more intelligent solution is to separate out the pricing logic to different classes and
 * hide them behind an abstraction that ShoppingCart can refer to. The result is that you’ll have a higher number of classes but they are typically small and concentrate 
 on some very specific functionality. 
 * This idea refers back to the Single Responsibility Principle of the previous
 */