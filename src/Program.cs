using Microsoft.AspNetCore.Diagnostics;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using FXAPIV1.Endpoints.Products;
using FXAPIV1.Endpoints.Clients;
using FXAPIV1.Endpoints.Orders;
using FXAPIV1.Domain.Users;

namespace FXAPIV1;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddSqlServer<ApplicationDbContext>(builder.Configuration["ConnectionString:IWantDb"]);

        builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
        {
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireDigit = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;
            options.Password.RequiredLength = 3;

        }).AddEntityFrameworkStores<ApplicationDbContext>();

        builder.Services.AddAuthorization(options =>
        {
            SwaggerActivate(options);
            options.AddPolicy("EmployeePolicy", p => p.RequireAuthenticatedUser().RequireClaim("EmployeeCode"));
            options.AddPolicy("Employee005Policy", p => p.RequireAuthenticatedUser().RequireClaim("Employee005Policy", "005"));
            options.AddPolicy("CpfPolicy", p => p.RequireAuthenticatedUser().RequireClaim("Cpf"));
        });

        builder.Services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateActor = true,
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ClockSkew = TimeSpan.Zero,
                ValidIssuer = builder.Configuration["JwtBearerTokenSettings:Issuer"],
                ValidAudience = builder.Configuration["JwtBearerTokenSettings:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(builder.Configuration["JwtBearerTokenSettings:SecretKey"]))
            };
        });

        builder.Services.AddScoped<QueryAllUsersWithClaimName>();
        builder.Services.AddScoped<QueryAllProductsSold>();
        builder.Services.AddScoped<UserCreator>();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        //DbLogActivate(builder);

        var app = builder.Build();
        app.UseAuthentication();
        app.UseAuthorization();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.MapMethods(CategoryPost.Template, CategoryPost.Methods, CategoryPost.Handle);
        app.MapMethods(CategoryGetAll.Template, CategoryGetAll.Methods, CategoryGetAll.Handle);
        app.MapMethods(CategoryPut.Template, CategoryPut.Methods, CategoryPut.Handle);
        app.MapMethods(CategoryRemove.Template, CategoryRemove.Methods, CategoryRemove.Handle);
        app.MapMethods(EmployeePost.Template, EmployeePost.Methods, EmployeePost.Handle);
        app.MapMethods(EmployeeGetAll.Template, EmployeeGetAll.Methods, EmployeeGetAll.Handle);
        app.MapMethods(TokenPost.Template, TokenPost.Methods, TokenPost.Handle);
        app.MapMethods(ProductPost.Template, ProductPost.Methods, ProductPost.Handle);
        app.MapMethods(ProductGetAll.Template, ProductGetAll.Methods, ProductGetAll.Handle);
        app.MapMethods(ProductGetShowcase.Template, ProductGetShowcase.Methods, ProductGetShowcase.Handle);
        app.MapMethods(ClientPost.Template, ClientPost.Methods, ClientPost.Handle);
        app.MapMethods(ClientGet.Template, ClientGet.Methods, ClientGet.Handle);
        app.MapMethods(OrderPost.Template, OrderPost.Methods, OrderPost.Handle);
        app.MapMethods(OrderGet.Template, OrderGet.Methods, OrderGet.Handle);
        app.MapMethods(ProductSoldGet.Template, ProductSoldGet.Methods, ProductSoldGet.Handle);
        app.UseExceptionHandler("/error");

        validateErros(app);
    }

    [Obsolete]
    private static void DbLogActivate(WebApplicationBuilder builder)
    {
        builder.WebHost.UseSerilog((context, configuration) =>
        {
            configuration
                .WriteTo.Console()
                .WriteTo.MSSqlServer(
                    context.Configuration["ConnectionString:IWantDb"],
                      sinkOptions: new MSSqlServerSinkOptions()
                      {
                          AutoCreateSqlTable = true,
                          TableName = "LogAPI"
                      });
        });
    }

    private static void SwaggerActivate(AuthorizationOptions options)
    {
        options.FallbackPolicy = new AuthorizationPolicyBuilder()
                       .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                       .RequireAuthenticatedUser()
                       .Build();
    }

    private static void validateErros(WebApplication app)
    {
        app.Map("/error", (HttpContext http) =>
        {
            var error = http.Features?.Get<IExceptionHandlerFeature>()?.Error;

            if (error != null)
            {
                if (error is SqlException)
                    return Results.Problem(title: "Database out", statusCode: 500);
                else if (error is BadHttpRequestException)
                    return Results.Problem(title: "Error to convert data to other type. See all the information sent", statusCode: 500);
            }

            return Results.Problem(title: "An error ocurred", statusCode: 500);
        });

        app.Run();
    }
}