using Licitacija.Services.PredradnjeNadmetanjaAPI.ServiceCalls;
using Licitacija.Services.ProgramLicitacijeAPI.Configurations;
using Licitacija.Services.ProgramLicitacijeAPI.DbConexts;
using Licitacija.Services.ProgramLicitacijeAPI.Repositories.Interface;
using Licitacija.Services.ProgramLicitacijeAPI.Repositories.Repos;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(
        builder.Configuration
            .GetConnectionString("ProgramLicitacijeDb")));
builder.Services.AddAutoMapper(typeof(Mapper));
builder.Services.AddScoped<IKreiranjeProgramaLicitacijeRepository, KreiranjeProgramaLicitacijeRepository>();
builder.Services.AddScoped<ILicitacijaService, LicitacijaService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setupAction =>
{
    setupAction.SwaggerDoc("ProgramLicitacijeMicroserviceOpenApiSpecification",
    new Microsoft.OpenApi.Models.OpenApiInfo()
    {
        Title = "Licitacija.Services.ProgramLicitacijeAPI",
        Version = "1",
        Description = "Pomoću ovog API-ja može se vršiti dodavanje programa licitacije, modifikacija programa licitacije, kao i pregled programa licitacije.",
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
        c.SwaggerEndpoint("/swagger/ProgramLicitacijeMicroserviceOpenApiSpecification/swagger.json", "Licitacija.Services.ProgramLicitacijeAPI");
        c.RoutePrefix = String.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
