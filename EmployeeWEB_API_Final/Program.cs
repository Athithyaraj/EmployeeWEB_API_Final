using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using EmployeeWEB_API_Final.Models;
using EmployeeWEB_API_Final;
using Microsoft.AspNetCore.OData.Batch;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddOData(options =>
        options.EnableQueryFeatures());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EmpContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("ContactsDbConnectionStrings")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseODataBatching();
//var builder = new ODataConventionModelBuilder();
//builder.EntitySet<Supplier>("Suppliers");
////builder.EntitySet<Category>("Categories");
////builder.EntitySet<Product>("Products");
//config.MapODataServiceRoute(routeName: "odata", routePrefix: "odata", model: builder.GetEdmModel());
//public static IHostBuilder CreateHostBuilder(string[] args) =>
//            Host.CreateDefaultBuilder(args)
//                .ConfigureWebHostDefaults(webBuilder =>
//                {
//                    webBuilder.UseStartup<Startup>();
//                });
app.UseODataBatching();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//    endpoints.Select().Filter().Expand().OrderBy();
//    endpoints.MapODataRoute(
//        routeName: "api",
//        routePrefix: "api",
//        model: GetEdmModel(),
//        batchHandler: new DefaultODataBatchHandler());
//});