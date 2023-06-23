namespace FXAPIV1.Endpoints.Orders;

public record OrderRequest(List<Guid> ProductIds, string DeliveryAddress);
