using Proyecto2Ferreteria.Components;
using Proyecto2Ferreteria.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Configurar los servicios
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var neo4jConfig = builder.Configuration.GetSection("Neo4j");
var uri = neo4jConfig["Uri"] ?? throw new ArgumentNullException("Uri", "La URI de Neo4j no puede ser nula.");
var user = neo4jConfig["Username"] ?? throw new ArgumentNullException("Username", "El nombre de usuario de Neo4j no puede ser nulo.");
var password = neo4jConfig["Password"] ?? throw new ArgumentNullException("Password", "La contraseña de Neo4j no puede ser nula.");

// Registrar la conexión de Neo4j
builder.Services.AddSingleton(new Neo4jConnection(uri, user, password));

builder.Services.AddServerSideBlazor();

var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
