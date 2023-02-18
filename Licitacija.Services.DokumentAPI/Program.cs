using Licitacija.Services.DokumentAPI.Configuration;
using Licitacija.Services.DokumentAPI.DbConexts;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Licitacija.Services.DokumentAPI.Repositories.Interfaces;
using Licitacija.Services.DokumentAPI.Repositories.Repos;
using Licitacija.Services.DokumentAPI.ServiceCalls;

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
    });

builder.Services.AddAutoMapper(typeof(Mapper));

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(
        builder.Configuration
            .GetConnectionString("DokumentDB")));
builder.Services.AddTransient<DataSeeder>();
builder.Services.AddScoped<IDokumentRepository, DokumentRepository>();
builder.Services.AddScoped<IEksterniDokumentRepository, EksterniDokumentRepository>();
builder.Services.AddScoped<IStatusDokumentaRepository, StatusDokumentaRepository>();
builder.Services.AddScoped<ITipGarancijeRepository, TipGarancijeRepository>();
builder.Services.AddScoped<IUgovorOZakupuRepository, UgovorOZakupuRepository>();
builder.Services.AddScoped<IKupacService, KupacService>();
builder.Services.AddScoped<ILicnostService, LicnostService>();
builder.Services.AddScoped<IUplataService, UplataSerice>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setupAction =>
{
    setupAction.SwaggerDoc("DokumentMicroserviceOpenApiSpecification",
    new Microsoft.OpenApi.Models.OpenApiInfo()
    {
        Title = "Licitacija.Services.DokumentAPI",
        Version = "1",
        Description = "Pomoću ovog API-ja može se vršiti dodavanje dokumenata, modifikacija dokumenata, kao i pregled kreiranih dokumenata.",
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


if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app);

static void SeedData(IHost app)
{
    IServiceScopeFactory? scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory?.CreateScope())
    {
        var service = scope?.ServiceProvider.GetService<DataSeeder>();
        service?.Seed();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/DokumentMicroserviceOpenApiSpecification/swagger.json", "Licitacija.Services.DokumentAPI");
        c.RoutePrefix = String.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
