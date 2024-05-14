using FXAPIV1.Domain.Users;

namespace FXAPIV1.Endpoints.Members;

public class AdminRootPost
{
    public static string Template => "/members/root";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };

    public record MemberRequest(string Email, string Password, string Name);

    public static Delegate Handle => Action;

    [Authorize(Policy = "EmployeeAdminRootPolicy")]
    public static async Task<IResult> Action(MemberRequest memberRequest,
        HttpContext http,
        UserCreator userCreator)
    {
        var userId = http.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;

        var userClaims = new List<Claim>
        {
            new Claim("EmployeePolicy", "10"),
            new Claim("Name", memberRequest.Name),
            new Claim("CreatedBy", userId),
        };

        (IdentityResult identity, string userId) result = await userCreator.CreateAdminRoot(memberRequest.Email, memberRequest.Password, userClaims);

        if (!result.identity.Succeeded)
            return Results.ValidationProblem(result.identity.Errors.ConvertToProblemDetails());

        return Results.Created($"/employees/{result.userId}", result.userId);
    }
}
