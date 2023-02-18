using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Licitacija.Services.KomisijaAPI.DbConexts;
using System.Reflection;
using Licitacija.Services.KomisijaAPI.Repositories.Interfaces;
using Licitacija.Services.KomisijaAPI.Repositories.Repos;
using Licitacija.Services.TipKomisijeAPI.Repositories.Interfaces;
using Licitacija.Services.LicnostAPI.Repositories.Interfaces;
using Licitacija.Services.KomisijaAPI.Configuration;
using Licitacija.Services.KomisijaAPI.ServiceCalls;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
    .AddXmlDataContractSerializerFormatters()
    .ConfigureApiBehaviorOptions(setupAction =>
    {
        setupAction.InvalidModelStateResponseFactory = context =>
        {
            ProblemDetailsFactory problemDetailsFactory = context.HttpContext.RequestServices
                .GetRequiredService<ProblemDetailsFactory>();

            ValidationProblemDetails problemDetails = problemDetailsFactory.CreateValidationProblemDetails(
                context.HttpContext,
                context.ModelState);

            problemDetails.Detail = "Pogledajte polje errors za detalje.";
            problemDetails.Instance = context.HttpContext.Request.Path;

            var actionExecutiongContext = context as ActionExecutingContext;

            if ((context.ModelState.ErrorCount > 0) &&
                (actionExecutiongContext?.ActionArguments.Count == context.ActionDescriptor.Parameters.Count))
            {
                problemDetails.Status = StatusCodes.Status422UnprocessableEntity;
                problemDetails.Title = "Došlo je do greške prilikom validacije.";

                return new UnprocessableEntityObjectResult(problemDetails)
                {
                    ContentTypes = { "application/problem+json" }
                };
            }

            problemDetails.Status = StatusCodes.Status400BadRequest;
            problemDetails.Title = "Došlo je do greške prilikom parsiranja poslatog sadržaja.";
            return new BadRequestObjectResult(problemDetails)
            {
                ContentTypes = { "application/problem+json" }
            };
        };
    });// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAutoMapper(typeof(Mapper));
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(
        builder.Configuration
            .GetConnectionString("KomisijaDB")));
builder.Services.AddScoped<IKomisijaRepository, KomisijaRepository>();
builder.Services.AddScoped<ITipKomisijeRepository, TipKomisijeRepository>();
builder.Services.AddScoped<ILicnostRepository, LicnostRepository>();
builder.Services.AddScoped<ILicnostKomisijaRepository, LicnostKomisijaRepository>();
builder.Services.AddScoped<IKreiranjeProgramaService, KreiranjeProgramaService>();
builder.Services.AddScoped<IPredradnjaNadmetanjaService, PredradnjaNadmetanjaService>();



builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(setupAction =>
{
    setupAction.SwaggerDoc("KomisijaMicroserviceOpenApiSpecification",
    new Microsoft.OpenApi.Models.OpenApiInfo()
    {
        Title = "Licitacija.Services.KomisijaAPI",
        Version = "1",
        Description = "Pomoću ovog API-ja može se vršiti dodavanje komisija, modifikacija komisija, kao i pregled kreiranih komisija.",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Nebojša Zoraja",
            Email = "nebojsa.zoki@gmail.com",
        },
        License = new Microsoft.OpenApi.Models.OpenApiLicense
        {
            Name = "FTN licence",
            Url = new Uri("https://www.ftn.uns.ac.rs/")
        },
    });

    setupAction.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());


    var xmlComments = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlCommentsPath = Path.Combine(AppContext.BaseDirectory, xmlComments);
    setupAction.IncludeXmlComments(xmlCommentsPath);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/KomisijaMicroserviceOpenApiSpecification/swagger.json", "Licitacija.Services.KomisijaAPI");
        c.RoutePrefix = String.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
