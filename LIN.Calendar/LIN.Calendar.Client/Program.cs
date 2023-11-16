global using LIN.Types.Responses;
global using LIN.Types.Auth.Enumerations;
global using LIN.Types.Auth.Models;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

await builder.Build().RunAsync();
