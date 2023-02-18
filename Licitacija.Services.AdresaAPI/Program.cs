using Licitacija.Services.AdresaAPI.Configurations;
using Licitacija.Services.AdresaAPI.DbContexts;
using Licitacija.Services.AdresaAPI.Repositories.ConcreteClasses;
using Licitacija.Services.AdresaAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
//using Microsoft.IdentityModel.Tokens;
//using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//DbContext
builder.Services.AddDbContext<DataContext>(options => 
    options.UseSqlServer(
        builder.Configuration
            .GetConnectionString("DefaultConnection")));

//AutoMapper
builder.Services.AddAutoMapper(typeof(MapperInitializer));

//Transient - svaki put kada se koristi zahtev iz kontrolera, kreirace se nova instanca iuof
//UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//AdresaRepository
builder.Services.AddScoped<IAdresaRepository, AdresaRepository>();

//DrzavaReposiory
builder.Services.AddScoped<IDrzavaRepository, DrzavaRepository>();

//Controllers i ValidationContext
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

builder.Services.AddEndpointsApiExplorer();

//Autentifikacija i autorizacija
/*builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
{
    options.Authority = "https://localhost:7004/";
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = true
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ApiScope", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "licitacija");
    });
});*/

//Swagger
builder.Services.AddSwaggerGen(setupAction =>
    {
        setupAction.SwaggerDoc("AdresaMicroserviceOpenApiSpecification",
            new Microsoft.OpenApi.Models.OpenApiInfo()
            {
                Title = "Licitacija.Services.AdresaAPI",
                Version = "1",
                Description = "Pomoću ovog API-ja može se vršiti dodavanje adresa i država, modifikacija adresa i država, kao i pregled kreiranih adresa i država.",
                Contact = new Microsoft.OpenApi.Models.OpenApiContact
                {
                    Name = "Maja Jukić",
                    Email = "mjukic2000@gmail.com",
                    Url = new Uri("https://github.com/majajukic")
                },
                License = new Microsoft.OpenApi.Models.OpenApiLicense
                {
                    Name = "FTN licence",
                    Url = new Uri("https://www.ftn.uns.ac.rs/")
                },
            });

        /*setupAction.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = @"Eneter 'Bearer' [space] and your token",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });

        setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header
                },
                new List<string>()
            }
        });*/

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

//HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/AdresaMicroserviceOpenApiSpecification/swagger.json", "Licitacija.Services.AdresaAPI");
        c.RoutePrefix = String.Empty;
    });
}

app.UseHttpsRedirection();

//app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
