using DatingApp.API.Data;
using DatingApp.API.Extensions;
using DatingApp.API.Interfaces;
using DatingApp.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplicationService(builder.Configuration);
builder.Services.AddIdentityService(builder.Configuration);

var app = builder.Build();

//Configure the HTTP request pipeline
app.UseCors(corsPolicybuilder => corsPolicybuilder.AllowAnyHeader().AllowAnyOrigin().WithOrigins("http://localhost:4200"));

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
