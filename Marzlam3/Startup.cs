using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Scrutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TestServiceImpl;

namespace Marzlam3
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            //services.AddScoped<ITest, TestImpl>();

            services.Scan(scan => scan
    .FromAssemblyOf<Startup>() //��ʾ����Startup��������ڵĳ���
        //.AddClasses() //ע��������
        .AddClasses(classes => classes.Where(t => t.Name.EndsWith("test", StringComparison.OrdinalIgnoreCase))) //����һ��ע�����
        .UsingRegistrationStrategy(RegistrationStrategy.Skip) //����  �������ע���ظ��ľ�����
         //.AsMatchingInterface()  //���������� ITest/Test
         .AsImplementedInterfaces()//��������Ҫ��  ������ITest/TestImpl
        .WithTransientLifetime() //��������
    );

        }

        //public void ConfigureContainer(ContainerBuilder builder)
        //{
        //    //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()) //ע�ᵱǰ����
        //    //    .As(t => t.GetInterfaces()[0]) //���еĽӿ��౩¶����һ�� Ҳ���� Ϊʲô���ǹ淶 һ���ӿ� ��Ӧһ��ʵ�־���Ϊ�˺���
        //    //    .InstancePerLifetimeScope(); //������������һ�� scope������

        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           
            app.UseRouting();
           

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
                endpoints.MapControllers();
            });
        }
    }
}
