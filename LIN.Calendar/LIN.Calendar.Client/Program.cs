global using LIN.Types.Responses;
global using LIN.Types.Cloud.Identity.Enumerations;
global using LIN.Types.Cloud.Identity.Models;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using LIN.Access.Auth;
using LIN.Access.Calendar;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthenticationService();
builder.Services.AddCalendarService();

await builder.Build().RunAsync();