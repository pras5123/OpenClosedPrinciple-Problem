# OpenClosedPrinciple-Problem

# Problem Description 

Let's take an example of a Shopping cart where we need to calculate the price of each items.

When it comes to this calculation, shop might be running many different offers at different times.

So, under the method of calculating the total, we have several if else statements like below :

# 1 > Price per unit
# 2 > Price per unit of weight, such as price per kilogram
# 3 > Special discount prices: buy 3, get 1 for free
# 4 > Price depending on the Customer’s loyalty: loyal customers get 10% off

This will be equivalent to constructing 4 if else inside the class and it might change based on the seasonal offers.

We need to rewrite the class by using if else statements during different seasons

Extending the if-else statements can introduce bugs and the application must be re-tested. We’ll need to test the ShoppingCart whereas we’re only 
interested in testing the pricing rule(s)

Also, the pricing logic is tightly coupled with the ShoppingCart domain. Therefore if we change the pricing logic in the ShoppingCart object we’ll need to test all other objects that depend on ShoppingCart even if they absolutely have nothing to do with pricing rules. A more intelligent solution is to separate out the pricing logic to different classes and hide them behind an abstraction that ShoppingCart can refer to. The result is that you’ll have a higher number of classes but they are typically small and concentrate on some very specific functionality. 

Take a look at the code where this project violates open closed priciple.

Open closed priciple says class must be open for extension but closed for modification.

In our Solution project, we will see how it can be reconfigured to respect Open closed principles
