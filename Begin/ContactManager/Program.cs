var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add Swagger services (must be done before calling builder.Build())
builder.Services.AddEndpointsApiExplorer(); // Necessary for API endpoint discovery
builder.Services.AddSwaggerGen(); // Adds Swagger generation services

var app = builder.Build(); // Build the application

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Enable Swagger middleware to serve the generated Swagger as a JSON endpoint
app.UseSwagger();

// Enable the Swagger UI middleware (the interactive UI for Swagger docs)
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty; // Makes the Swagger UI available at the root (optional)
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();