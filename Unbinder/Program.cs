using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Unbinder.DB;
using Unbinder.Repositories;
using Unbinder.Services;

var builder = WebApplication.CreateBuilder(args);

// pull in environment variables from secrets
EnvironmentLoader.Load(builder);

// Add services to the container.
//builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
//    .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"));

//builder.Services.AddAuthorization(options =>
//    // By default, all incoming requests will be authorized according to the default policy.
//    options.FallbackPolicy = options.DefaultPolicy);


// configure database
SqlConnectionStringBuilder connBuilder = new()
{
    ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection"),
    Password = builder.Configuration["SA_PASSWORD"],
};

builder.Services.AddDbContext<UnbinderDbContext>(options =>
{
    options.UseSqlServer(connBuilder.ConnectionString);
});

// configure MVC
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();

// include aws service
builder.Services.AddTransient<S3Service>();

// configure front end features
builder.Services.AddHttpContextAccessor();
builder.Services.AddServerSideBlazor();

// build app
var app = builder.Build();

// apply most recent migration to db
using (IServiceScope scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<UnbinderDbContext>();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();

//app.UseAuthentication();
//app.UseAuthorization();

app.MapDefaultControllerRoute();

Initializer.Seed(app);

app.Run();
