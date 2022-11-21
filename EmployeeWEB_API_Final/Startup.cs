////using System.Linq;
////using EmployeeWEB_API_Final;
////using EmployeeWEB_API_Final.Models;
//////using Microsoft.AspNetCore.OData.Builder;
////using Microsoft.AspNetCore.OData.Extensions;
////using Microsoft.AspNetCore.Builder;
////using Microsoft.AspNetCore.Hosting;
////using Microsoft.Extensions.Configuration;
////using Microsoft.Extensions.DependencyInjection;
////using Microsoft.Extensions.Hosting;
////using Microsoft.OData.Edm;
////using Microsoft.OData.ModelBuilder;
////using Microsoft.AspNetCore.OData;
////using Microsoft.AspNetCore.OData.NewtonsoftJson;

////namespace EmployeeWEB_API_Final

////{
////    public class Startup
////    {
////        public Startup(IConfiguration configuration)
////        {
////            Configuration = configuration;
////        }

////        public IConfiguration Configuration { get; }

////        public void ConfigureServices(IServiceCollection services)
////        {
////            services.AddControllers()
////                .AddOData(opt => opt.Select().Filter().Count().SetMaxTop(10).AddRouteComponents("odata", GetEdmModel()))
////                .AddODataNewtonsoftJson()
////            //services
////        }

////        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
////        {
////            if (env.IsDevelopment())
////            {
////                app.UseDeveloperExceptionPage();
////            }

////            app.UseODataRouteDebug();

////            app.UseRouting();

////            app.UseAuthorization();

////            app.UseEndpoints(endpoints =>
////            {
////                endpoints.MapControllers();
////            });
////        }

////        private IEdmModel GetEdmModel()
////        {
////            var odataBuilder = new ODataConventionModelBuilder();
////            odataBuilder.EntitySet<Employee>("Employees");

////            return odataBuilder.GetEdmModel();
////        }
////    }
////}
//using AspNetCore3xODataSample.Web.Models;
//using Microsoft.AspNetCore.OData.Extensions;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using Microsoft.OData.Edm;

//namespace EmployeeWEB_API_Final
//{
//    public class Startup
//    {
//        public Startup(IConfiguration configuration)
//        {
//            Configuration = configuration;
//        }

//        public IConfiguration Configuration { get; }

//        // This method gets called by the runtime. Use this method to add services to the container.
//        public void ConfigureServices(IServiceCollection services)
//        {
//            //services.AddControllers().AddNewtonsoftJson();

//            string connectionString = Configuration.GetConnectionString("ContactsDbConnectionStrings");
//            services.AddDbContext<EmpContext>(options => options.UseNpgsql(connectionString));
//            //services.AddTransient<IStorageBroker, StorageBroker>();
//            //services.AddTransient<IStudentService, StudentService>();
//            //services.AddTransient<ILogger, Logger<LoggingBroker>>();
//            //services.AddTransient<ILoggingBroker, LoggingBroker>();
//            services.AddOData();
//        }

//        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//        {
//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//            }

//            app.UseODataBatching();
//            app.UseHttpsRedirection();
//            app.UseRouting();
//            app.UseAuthorization();

//            app.UseEndpoints(endpoints =>
//            {
//                app.UseEndpoints(endpoints =>
//                {
//                    var defaultBatchHandler = new DefaultODataBatchHandler();
//                    defaultBatchHandler.MessageQuotas.MaxNestingDepth = 2;
//                    defaultBatchHandler.MessageQuotas.MaxOperationsPerChangeset = 10;
//                    defaultBatchHandler.MessageQuotas.MaxReceivedMessageSize = 100;
//                    endpoints.MapControllers();
//                    endpoints.Select().Filter().Expand().OrderBy();
//                    endpoints.MapODataRoute(
//                        routeName: "api",
//                        routePrefix: "api",
//                        model: GetEdmModel(),
//                        batchHandler: new DefaultODataBatchHandler());
//                });
//            });
//        }

//        private IEdmModel GetEdmModel()
//        {
//            var builder = new ODataConventionModelBuilder();
//            builder.EntitySet<Employee>("Employee");
//            return builder.GetEdmModel();
//        }
//    }
//}
