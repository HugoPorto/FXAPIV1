using FXAPIV1.Domain.Users;

namespace FXAPIV1.Endpoints.Members;

public class MemberPost
{
    public static string Template => "/members";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };

    public record MemberRequest(string Email, string Password, string Name);

    public static Delegate Handle => Action;

    [AllowAnonymous]
    public static async Task<IResult> Action(MemberRequest memberRequest,
        HttpContext http,
        UserCreator userCreator)
    {
        var userId = http.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

        var userClaims = new List<Claim>();

        if (userId == null)
        {
            userClaims = new List<Claim>
            {
                new Claim("MemberCode", "03"),
                new Claim("Name", memberRequest.Name),
                new Claim("CreatedBy", memberRequest.Name),
            };
        } else {
            userClaims = new List<Claim>
            {
                new Claim("MemberCode", "03"),
                new Claim("Name", memberRequest.Name),
                new Claim("CreatedBy", userId.Value),
            };
        }


        (IdentityResult identity, string userId) result = await userCreator.CreateMember(memberRequest.Email, memberRequest.Password, userClaims);

        if (!result.identity.Succeeded)
            return Results.ValidationProblem(result.identity.Errors.ConvertToProblemDetails());

        return Results.Created($"/employees/{result.userId}", result.userId);
    }
}
