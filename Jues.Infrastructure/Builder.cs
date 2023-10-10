using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Suyaa;
using System.Diagnostics;
namespace Jues.Infrastructure
{
    /// <summary>
    /// 构建器
    /// </summary>
    public class Builder<T>
        where T : StartupBase
    {
        // 入参
        private readonly string[]? _args;
        /// <summary>
        /// 构建器
        /// </summary>
        /// <param name="args"></param>
        public Builder(string[]? args)
        {
            _args = args;
        }
        /// <summary>
        /// 运行
        /// </summary>
        public void Run()
        {
            // 注册日志
            sy.Logger.GetCurrentLogger()
                .Use((string message) =>
                {
                    Debug.WriteLine(message);
                });
            string key = "ASPNETCORE_ENVIRONMENT";
            if (Environment.GetEnvironmentVariable(key).IsNullOrWhiteSpace()) Environment.SetEnvironmentVariable(key, "Prod");
            var builder = new ConfigurationBuilder()
                           .SetBasePath(Directory.GetCurrentDirectory())
                           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                           .AddEnvironmentVariables(prefix: "ASPNETCORE_")
                           .AddCommandLine(_args);
            var config = builder.Build();
            sy.Hosting.CreateHost<T>(webBuilder => webBuilder.UseConfiguration(config), _args).Run();
        }
    }
}
