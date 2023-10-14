using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Suyaa;
using System.Diagnostics;
namespace Jues.Infrastructure.Host
{
    /// <summary>
    /// 创建器
    /// </summary>
    public static class Builder
    {
        // 获取基目录
        private static string GetBasePath()
        {
            //using var processModule = Process.GetCurrentProcess().MainModule;
            //return Path.GetDirectoryName(processModule?.FileName) ?? string.Empty;
            //return sy.Assembly.ExecutionDirectory;
            return "D:\\Project.Github\\Jue-Yun\\Jue.S\\Jues.Host\\bin\\Debug\\net6.0";
        }
        /// <summary>
        /// 创建配置
        /// </summary>
        /// <param name="args"></param>
        /// <param name="actionConfigurationBuilder"></param>
        /// <returns></returns>
        public static IConfigurationRoot CreateConfiguration(string[]? args, Action<IConfigurationBuilder>? actionConfigurationBuilder = null)
        {
            string key = "ASPNETCORE_ENVIRONMENT";
            string env = Environment.GetEnvironmentVariable(key) ?? "Prod";
            if (env == "Development") env = "Dev";
            if (Environment.GetEnvironmentVariable(key).IsNullOrWhiteSpace()) Environment.SetEnvironmentVariable(key, env);
            var builder = new ConfigurationBuilder()
                           //.SetBasePath(Directory.GetCurrentDirectory())
                           .SetBasePath(GetBasePath())
                           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                           .AddJsonFile($"appsettings.{env}.json", optional: false, reloadOnChange: true)
                           .AddEnvironmentVariables(prefix: "ASPNETCORE_")
                           .AddCommandLine(args);
            if (actionConfigurationBuilder != null) actionConfigurationBuilder(builder);
            return builder.Build();
        }
    }

    /// <summary>
    /// 构建器
    /// </summary>
    public class Builder<T>
        where T : StartupBase
    {
        // 入参
        private readonly string[]? _args;
        private readonly IConfigurationRoot _configuration;

        /// <summary>
        /// 构建器
        /// </summary>
        /// <param name="args"></param>
        public Builder(string[]? args, Action<IConfigurationBuilder>? actionConfigurationBuilder = null)
        {
            _args = args;
            // 注册日志
            sy.Logger.GetCurrentLogger()
                .Use((message) =>
                {
                    Debug.WriteLine(message);
                });
            _configuration = Builder.CreateConfiguration(_args, actionConfigurationBuilder);
        }
        /// <summary>
        /// 运行
        /// </summary>
        public void Run()
        {
            sy.Hosting.CreateHost<T>(webBuilder =>
            {
                webBuilder.UseConfiguration(_configuration);
            }, _args).Run();
        }

        /// <summary>
        /// 运行
        /// </summary>
        public void Run(Action<IWebHostBuilder> actionBuilder)
        {
            sy.Hosting.CreateHost<T>(webBuilder =>
            {
                webBuilder.UseConfiguration(_configuration);
                actionBuilder(webBuilder);
            }, _args).Run();
        }

        /// <summary>
        /// 运行
        /// </summary>
        public void Run(Action<IWebHostBuilder> actionBuilder, Action<IHostBuilder> actionHostBuilder)
        {
            sy.Hosting.CreateHost<T>(webBuilder =>
            {
                webBuilder.UseConfiguration(_configuration);
                if (actionBuilder != null) actionBuilder(webBuilder);
            }, actionHostBuilder, _args).Run();
        }
    }
}
