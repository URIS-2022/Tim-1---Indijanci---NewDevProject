using Licitacija.Services.ZalbaAPI.DbContexts;
using Licitacija.Services.ZalbaAPI.Repositories.ConcreteClasses;
using Licitacija.Services.ZalbaAPI.Repositories.Interfaces;
using Licitacija.Services.ZalbaAPI.ServiceCalls;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

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
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IZalbaRepository, ZalbaRepository>();
builder.Services.AddScoped<ITipZalbeRepository, TipZalbeRepository>();
builder.Services.AddScoped<IRadnjaNaOsnovuZalbeRepository, RadnjaNaOsnovuZalbeRepository>();
builder.Services.AddScoped<IStatusZalbeRepository, StatusZalbeRepository>();
builder.Services.AddScoped<IKupacService, KupacService>();
builder.Services.AddScoped<IFazaLicitacijeService, FazaLicitacijeService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setupAction =>
{
    setupAction.SwaggerDoc("LicitacijaMicroserviceOpenApiSpecification",
    new Microsoft.OpenApi.Models.OpenApiInfo()
    {
        Title = "Licitacija.Services.ZalbaAPI",
        Version = "1",
        Description = "Pomoću ovog API-ja može se vršiti dodavanje zalbi, tipova zalbi, statusa zalbi i radnja na osnovu zalbe," +
        " modifikacija zalbi, tipova zalbi, statusa zalbi i radnja na osnovu zalbe, kao i pregled kreiranih zalbi, tipova zalbi, statusa zalbi i radnja na osnovu zalbe.",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Maša Šaranović",
            Email = "masasaranovic@gmail.com"
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

/*using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<DataContext>();
    context.Database.Migrate();
}*/

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/LicitacijaMicroserviceOpenApiSpecification/swagger.json", "Licitacija.Services.ZalbaAPI");
        c.RoutePrefix = String.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();