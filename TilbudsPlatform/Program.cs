using Microsoft.EntityFrameworkCore;
using TilbudsPlatform.core.Components;
using TilbudsPlatform.core.Services;
using TilbudsPlatform.Data;
using TilbudsPlatform.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TilbudsPlatformContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TilbudsPlatformContext") ?? throw new InvalidOperationException("Connection string 'TilbudsPlatformContext' not found.")));

builder.Services.AddScoped<ICustomerInterface, CustomerService>();
builder.Services.AddScoped<IProjectInterface, ProjectService>();
builder.Services.AddScoped<IEstimateInterface, EstimateService>();
builder.Services.AddScoped<IUserInterface, UserService>();
builder.Services.AddScoped<IWorklogInterface, WorklogService>();
builder.Services.AddScoped<IWorkTaskInterface, WorkTaskService>();


builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
