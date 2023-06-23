using FXAPIV1.Endpoints.Products;

namespace FXAPIV1.Infra.Data;

public class QueryAllProductsSold
{
    private readonly IConfiguration configuration;

    public QueryAllProductsSold(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public async Task<IEnumerable<ProductSoldResponse>> Execute()
    {
        var db = new SqlConnection(configuration["ConnectionString:IWantDb"]);
        var query =
            @"select
	            p.Id,
	            p.Name,
	            count(*) Amount
            from
	            Orders o inner join OrderProducts op on o.id = op.OrdersId
	            inner join Products p on p.Id = op.ProductsId
            group by
	            p.Id, p.Name
            order by Amount desc;";
        return await db.QueryAsync<ProductSoldResponse>(query);
    }
}
