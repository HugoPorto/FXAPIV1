namespace FXAPIV1.Endpoints.Categories
{
    public class CategoryRemove
    {
        public static string Template => "/categories/{id}";

        public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };

        public static Delegate Handle => Action;

        [Authorize(Policy = "EmployeePolicy")]
        public static IResult Action([FromRoute] Guid id, ApplicationDbContext context)
        {
            var category = context.Categories.Where(c => c.Id == id).FirstOrDefault();

            context.Categories.Remove(category);

            context.SaveChanges();

            return Results.Ok();
        }
    }
}
