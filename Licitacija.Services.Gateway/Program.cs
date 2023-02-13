using Licitacija.Services.Gateway;
using Licitacija.Services.Gateway.Services;
using Licitacija.Services.Gateway.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);

SD.IdentityAPIBase = builder.Configuration["ServiceUrls:IdentityAPI"];
SD.AdresaAPIBase = builder.Configuration["ServiceUrls:AdresaAPI"];
SD.UplataAPIBase = builder.Configuration["ServiceUrls:AdresaAPI"];
SD.PredradnjeNadmetanjaAPIBase = builder.Configuration["ServiceUrls:PredradnjeNadmetanjaAPI"];
SD.LicitacijaAPIBase = builder.Configuration["ServiceUrls:LicitacijaAPI"];
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

builder.Services.AddHttpClient<IAdresaService, AdresaService>();
builder.Services.AddScoped<IAdresaService, AdresaService>();

builder.Services.AddHttpClient<IDrzavaService, DrzavaService>();
builder.Services.AddScoped<IDrzavaService, DrzavaService>();

builder.Services.AddHttpClient<IKursService, KursService>();
builder.Services.AddScoped<IKursService, KursService>();

builder.Services.AddHttpClient<IUplataService, UplataService>();
builder.Services.AddScoped<IUplataService, UplataService>();

builder.Services.AddHttpClient<IPredradnjaNadmetanja, PredradnjaNadmetanjaService>();
builder.Services.AddScoped<IPredradnjaNadmetanja, PredradnjaNadmetanjaService>();

builder.Services.AddHttpClient<ILicitacijaService, LicitacijaService>();
builder.Services.AddScoped<ILicitacijaService, LicitacijaService>();


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
