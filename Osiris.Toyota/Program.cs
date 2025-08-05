using Osiris.Toyota.Infrastructure.Extensions;
using System.Xml.Linq;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var services = builder.Services;

services.InstallToyotaServices();
services.InstallTOneConnector();

app.UseHttpsRedirection();
app.UseStaticFiles(); 
app.MapFallbackToFile("index.html"); 
app.Run();