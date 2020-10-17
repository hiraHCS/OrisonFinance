using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OrisonFinance.Server.Data;
using OrisonFinance.Contracts;
using OrisonFinance.Concrete;
using DevExpress.Blazor;
using OrisonFinance.Shared.DataModel;
using OrisonFinance.Shared.Contract.Inventory;
using OrisonFinance.Server.Concrete.Inventory;
using OrisonFinance.Shared.Contract;
using OrisonFinance.Server.Concrete;
using Blazored.SessionStorage;
using Blazored.LocalStorage;

namespace OrisonFinance.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            var sqlConnectionConfiguration = new SqlConnectionConfiguration(Configuration.GetConnectionString("DefaultConnection"));
            services.AddSingleton(sqlConnectionConfiguration);

            //Database service 
            services.AddDbContext<SqlDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //services.AddSingleton<SalesOrderTempService>();
            //Voucher master service
            services.AddTransient<IVoucherMasterManager, VoucherMasterManager>();
            //Accounts service  
            services.AddTransient<IInvAccounts, InvAccounts>();
            //Items service  
            services.AddTransient<IInvItemsManager, InvItemsManager>();
            //Transaction service
            services.AddTransient<IInvTransactionsManager, InvTransactionsManager>();
            //VoucherAdditional service  
            services.AddTransient<IInvVoucherAdditionalsManager, InvVoucherAdditionalsManager>();
            //VoucherEntry service  
            services.AddTransient<IInvVoucherEntryManager, InvVoucherEntryManager>();
            //Voucher service  
            services.AddTransient<IInvVoucherManager, InvVoucherManager>();
            //Register dapper in scope  
            services.AddTransient<IDapperManager, DapperManager>();
            //Devexpress service 
            services.AddTransient<IDBOperation, DBOperation>();
            services.AddDevExpressBlazor();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddMvc();
            services.AddBlazoredSessionStorage();
            services.AddControllersWithViews();
            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { "application/octet-stream" });
            });
            services.Configure<IISOptions>(options =>
            {
                options.ForwardClientCertificate = false;
            });
            services.Configure<IISServerOptions>(options =>
            {
                options.AutomaticAuthentication = false;
            });

            services.AddBlazoredLocalStorage(config =>
        config.JsonSerializerOptions.WriteIndented = true);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
