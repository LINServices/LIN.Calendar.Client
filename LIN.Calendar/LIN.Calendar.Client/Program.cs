global using LIN.Types.Responses;
global using LIN.Types.Cloud.Identity.Enumerations;
global using LIN.Types.Cloud.Identity.Models;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

LIN.Access.Auth.Build.Init();
LIN.Access.Calendar.Build.Init();

await builder.Build().RunAsync();
