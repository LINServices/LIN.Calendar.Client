global using LIN.Types.Responses;
global using LIN.Types.Cloud.Identity.Enumerations;
global using LIN.Types.Cloud.Identity.Models;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using LIN.Access.Auth;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthenticationService();
LIN.Access.Calendar.Build.Init();

await builder.Build().RunAsync();