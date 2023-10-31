// 运行宿主
using Jues.Infrastructure.Host;
using Jues.Kernel;
using System.Diagnostics;

//Hosting.CreateBuilder<Jues.Kernel.KernelStartup>(args).Run();

// 注册日志
sy.Logger.Factory.UseStringAction(message => Debug.WriteLine(message));
sy.Logger.Create();
// 运行主机服务
sy.Hosting.CreateWebApplication<KernelApplicationProvider>(args).Run();
