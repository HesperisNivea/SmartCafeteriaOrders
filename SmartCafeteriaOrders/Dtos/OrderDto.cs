namespace SmartCafeteriaOrders.Dtos;

public class OrderDto
{
    public int Id { get; set; }
    public float TotalPrice { get; set; } 
    public ICollection<int> ProductIds { get; set; } = new List<int>();
}