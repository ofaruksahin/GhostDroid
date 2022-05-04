using FluentValidation.AspNetCore;
using GhostDroid.API.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddControllers()
    .AddFluentValidation(fv =>
        fv.RegisterValidatorsFromAssembly(
            typeof(FluentValidatorLoader).Assembly))
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = c =>
        {
            var errors = string.Join('\n', c.ModelState.Values.Where(v => v.Errors.Count > 0)
            .SelectMany(v => v.Errors)
            .Select(v => v.ErrorMessage));

            return new BadRequestObjectResult(new
            {
                ErrorCode = "Your validation error code",
                Message = errors
            });
        };
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(MediatRLoader));
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddGhostDroidDbContext(builder.Configuration);
builder.Services.AddAutoMapper(typeof(AutoMapperLoader));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
