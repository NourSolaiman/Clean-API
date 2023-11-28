using Application;
using Infrastructure;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>

{

    options.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });


    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme

    {

        Description = "JWT Authorization header using the Bearer scheme",

        Name = "Authorization",

        In = ParameterLocation.Header,

        Type = SecuritySchemeType.Http,

        Scheme = "bearer",
        BearerFormat = "JWT"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement

    {

        {

            new OpenApiSecurityScheme

            {

                Reference = new OpenApiReference

                {

                    Type = ReferenceType.SecurityScheme,

                    Id = "Bearer"

                }

            },

            Array.Empty<string>()

        }

    });

});

builder.Services.AddApplication().AddInfrastructure();

// Configure JWT Authentication

builder.Services.AddAuthentication(options =>

{

}).AddJwtBearer("Bearer", options =>

{

    options.TokenValidationParameters = new TokenValidationParameters

    {

        ValidateIssuerSigningKey = true,

        ValidateIssuer = false,

        ValidateAudience = false,

        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(

            builder.Configuration["JWTToken:Token"]!)),

    };

});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
