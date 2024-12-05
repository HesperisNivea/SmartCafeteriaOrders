namespace SmartCafeteriaOrders.Repository.Entities;

public class OrderEntity
{
    public int Id { get; set; }
    public float TotalPrice { get; set; } 
    public ICollection<ProductSignatureEntity> ProductIds { get; set; } = new List<ProductSignatureEntity>();
}