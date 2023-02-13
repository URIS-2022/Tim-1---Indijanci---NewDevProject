using Licitacija.Services.Gateway;
using Licitacija.Services.Gateway.Services;
using Licitacija.Services.Gateway.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);

SD.IdentityAPIBase = builder.Configuration["ServiceUrls:IdentityAPI"];
// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
    options.DefaultChallengeScheme = "oidc";
}).AddCookie("Cookies", c => {
    c.ExpireTimeSpan = TimeSpan.FromMinutes(10);
    c.AccessDeniedPath = "/api/User/AccessDenied";
})
.AddOpenIdConnect("oidc", options =>
{
    options.Authority = SD.IdentityAPIBase;
    options.GetClaimsFromUserInfoEndpoint = true;
    options.ClientId = "licitacija";
    options.ClientSecret = "2124cf1f-bffd-444f-92bb-a6b78d0e3894";
    options.ResponseType = "code";
    options.TokenValidationParameters.NameClaimType = "name";
    options.TokenValidationParameters.RoleClaimType = "role";
    options.Scope.Add("licitacija");
    options.SaveTokens = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<IUserService, UserService>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
