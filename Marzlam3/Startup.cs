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
    .FromAssemblyOf<Startup>() //表示加载Startup这个类所在的程序集
        //.AddClasses() //注册所有类
        .AddClasses(classes => classes.Where(t => t.Name.EndsWith("test", StringComparison.OrdinalIgnoreCase))) //过滤一下注册的类
        .UsingRegistrationStrategy(RegistrationStrategy.Skip) //策略  比如程序集注册重复的就跳过
         //.AsMatchingInterface()  //命名规则是 ITest/Test
         .AsImplementedInterfaces()//命名规则不要求  可以是ITest/TestImpl
        .WithTransientLifetime() //生命周期
    );

        }

        //public void ConfigureContainer(ContainerBuilder builder)
        //{
        //    //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()) //注册当前程序集
        //    //    .As(t => t.GetInterfaces()[0]) //所有的接口类暴露出第一个 也就是 为什么我们规范 一个接口 对应一个实现就是为了好找
        //    //    .InstancePerLifetimeScope(); //生命周期设置一下 scope作用域

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
