namespace Models;

public class Order
{
    int Id {get; set;}
    int CustomerId {get; set;}
    bool IsPacked {get; set;} 
    bool IsSent {get; set;} 
    bool IsDelivered {get; set;}
}