using NHL_Dashboards.Conventions;

#region Configure Services
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(options =>
{
    options.Conventions.Add(new CustomNamespaceRoutingConvention());
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApiDocument(document =>
    document.OperationProcessors.Add(new CustomOperationProcessor("NHL_Dashboards.Controllers.Api"))
);
builder.Services.AddHttpClient(
    "NhlApi",
    client => client.BaseAddress = new Uri("https://api-web.nhle.com/")
);
#endregion

#region Configure App
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseOpenApi();
app.UseSwaggerUi();
app.UseReDoc(options => options.Path = "/redoc");

app.UseStatusCodePages(async context =>
{
    if (context.HttpContext.Response.StatusCode == 404)
    {
        context.HttpContext.Response.Redirect("/NotFound");
    }
    await Task.CompletedTask;
});

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    // a default pattern is set but it is mostly overridden by Conventions.CustomNamespaceRoutingConvention
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();
#endregion

app.Run();
