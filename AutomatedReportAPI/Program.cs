using AutomatedReportAPI.AppData.Context;
using AutomatedReportAPI.Services;
using AutomatedReportAPI.Services.WhatsAppSetting;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//string path = Environment.CurrentDirectory;
//Console.WriteLine(path);
//string[] appPath = path.Split(new string[] { "bin" }, StringSplitOptions.None);
//Console.WriteLine(appPath[0]);
//var path = @"C:\Users\adela\OneDrive\Desktop\AutomatedReport\DB";
//AppDomain.CurrentDomain.SetData("DataDirectory", path);
var ConnectionString = builder.Configuration.GetConnectionString("DbConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
          options.UseSqlServer(ConnectionString));
builder.Services.AddHangfire(option =>
{
    option.UseSqlServerStorage(ConnectionString);
});
builder.Services.AddHangfireServer();
//using var scope = builder.Services.BuildServiceProvider().CreateScope();
//var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
//dbContext.Database.EnsureCreated(); // Creates the database if not exists
//dbContext.Database.Migrate(); // Applies pending migrations

builder.Services.AddControllers();
// configuring Swagger/OpenAPI
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
    options.ApiVersionReader = new HeaderApiVersionReader("x-api-version");
});
builder.Services.AddSwaggerGen(options =>
{
    // Configure Swagger documents for v1 and v2 and v3
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Admin Windows Dashboard", Version = "1.0" });
    options.SwaggerDoc("v2", new OpenApiInfo { Title = "Advertisment Web Page", Version = "2.0" });
    options.SwaggerDoc("v3", new OpenApiInfo { Title = "Client Android App", Version = "3.0" });
}).AddMvc();

//builder.Services.AddSingleton<WhatsAppService>();
builder.Services.AddRepositories();
builder.Services.AddBackgourndJob();
builder.Services.AddServices();

var app = builder.Build();
//app.UseMiddleware<WhatsAppMiddleware>();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Admin Windows Dashboard");
        c.SwaggerEndpoint("/swagger/v2/swagger.json", "Advertisment Web Page");
        c.SwaggerEndpoint("/swagger/v3/swagger.json", "Client Android App");
    });
    //app.Run(async context =>
    //{
    //    // Set the content type to text/html
    //    context.Response.ContentType = "text/html";

    //    // Your custom HTML string
    //    string htmlString = "<h1>API is running now</h1>";

    //    // Write the HTML string to the response
    //    await context.Response.WriteAsync(htmlString);
    //});
//}

app.UseHangfireDashboard();
app.UseAuthorization();
app.MapControllers();

app.Run();
