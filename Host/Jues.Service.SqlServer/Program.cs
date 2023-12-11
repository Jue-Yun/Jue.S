using Jues.Kernel;
using Microsoft.Extensions.Hosting.WindowsServices;
using System.Diagnostics;

// 以服务方式运行宿主
//Jues.Infrastructure.Hosting.CreateBuilder<Jues.Kernel.KernelStartup>(args).Run(builder => { }, builder => builder.UseWindowsService());

// 注册日志
sy.Logger.Factory.UseStringAction(message => Debug.WriteLine(message));
sy.Logger.Create();

// 服务模式处理当前目录
if (WindowsServiceHelpers.IsWindowsService())
{
    Environment.CurrentDirectory = sy.Assembly.ExecutionDirectory;
    Directory.SetCurrentDirectory(Environment.CurrentDirectory);
}

var options = new WebApplicationOptions
{
    Args = args,
    ContentRootPath = sy.Assembly.ExecutionDirectory,
    //WebRootPath =sy.IO.CombinePath( Environment.CurrentDirectory)
};

//// 启动器
//KernelStartup startup = new KernelStartup(Builder.CreateConfiguration(args));
//// 创建器
//var builder = WebApplication.CreateBuilder(options);
//// 服务配置
//startup.ConfigureServices(builder.Services);
//// 添加后台服务
//builder.Services.AddHostedService<HostBackgroundService>();
//// 使用Windows服务
//builder.Host.UseWindowsService();
//// 应用启动
//var app = builder.Build();
//var env = app.Services.GetRequiredService<IWebHostEnvironment>();
//startup.Configure(app, env);
////app.UseStaticFiles();
////app.UseRouting();
////app.MapRazorPages();
//await app.RunAsync();

// 以服务方式运行
await sy.Hosting.CreateWebApplication<ServiceStartup>(options).RunAsync();
