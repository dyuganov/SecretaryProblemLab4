using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SecretaryProblem4.model;
using SecretaryProblem4.model.interfaces;

namespace SecretaryProblem4;
internal static class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
            {
                services.AddHostedService<PrincessService>();

                services.AddScoped<IHall, Hall>();

                services.AddScoped<IFriend, Friend>();

                services.AddScoped<IContenderGenerator, ContenderGenerator>();

                services.AddScoped<IPrincess, Princess>();

                services.AddScoped<IContender, Contender>();
            });
    }
}