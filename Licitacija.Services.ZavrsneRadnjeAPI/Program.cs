using Licitacija.Services.ZavrsneRadnjeAPI.DbContexts;
using Licitacija.Services.ZavrsneRadnjeAPI.Repositories.ConcreteClasses;
using Licitacija.Services.ZavrsneRadnjeAPI.Repositories.ConcreteClasses.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Licitacija.Services.ZavrsneRadnjeAPI.ServiceCalls;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IZavrsneRadnje, ZavrsneRadnjeRepository>();
builder.Services.AddScoped<IFazaLicitacijeService, FazaLicitacijeService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add services to the container.



builder.Services.AddControllers(setup =>
{
    setup.ReturnHttpNotAcceptable = true;
}
).AddXmlDataContractSerializerFormatters()
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
                        problemDetails.Type = "https://google.com";
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



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(setupAction =>
{
    setupAction.SwaggerDoc("LicitacijaMicroserviceOpenApiSpecification",
    new Microsoft.OpenApi.Models.OpenApiInfo()
    {
        Title = "Licitacija.Services.ZavrsneRadnjeAPI",
        Version = "1",
        Description = "Pomoću ovog API-ja može se vršiti dodavanje zavrsne radnje," +
        " modifikacija zavrsne radnje, kao i pregled kreiranih zavrsnih radnji.",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Kristina Tadic",
            Email = "kristinatadic01@gmail.com"
        },
        License = new Microsoft.OpenApi.Models.OpenApiLicense
        {
            Name = "FTN licence",
            Url = new Uri("http://www.ftn.uns.ac.rs/")
        },
    });
    setupAction.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());


    var xmlComments = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlCommentsPath = Path.Combine(AppContext.BaseDirectory, xmlComments);
    setupAction.IncludeXmlComments(xmlCommentsPath);
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<DataContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/LicitacijaMicroserviceOpenApiSpecification/swagger.json", "Licitacija.Services.ZavrsneRadnjeAPI");
        c.RoutePrefix = String.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();









