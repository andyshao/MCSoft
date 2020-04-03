using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BasicAspNetCoreApplication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Volo.Abp;

namespace MCSoft
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
                    {

                        //��¼·�������ǵ��û���ͼ������Դ��δ���������֤ʱ�����򽫻Ὣ�����ض���������·��
                        o.LoginPath = new PathString("/Account/Index");
                        o.Cookie.Name = "McWebCookie_";
                        //��ֹ����·�������û���ͼ������Դʱ����δͨ������Դ���κ���Ȩ���ԣ����󽫱��ض���������·����
                        //o.AccessDeniedPath = new PathString("/Home/Privacy");
                    });
            services.AddDataProtection()
                    .PersistKeysToFileSystem(new DirectoryInfo(Directory.GetCurrentDirectory()));


            services.AddApplication<AppModule>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           

            app.InitializeApplication();
        }
    }
}
