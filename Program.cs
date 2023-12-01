
public class Program
{
    public static void Main(string[] args) {
        DotNetEnv.Env.Load();
        Console.WriteLine($"USER: {Environment.GetEnvironmentVariable("User")}");
        // var host = new WebHostBuilder()
        //     .UseKestrel()
        //     .UseContentRoot(Directory.GetCurrentDirectory())
        //     .UseIISIntegration()
        //     .UseStartup<Startup>()
        //     .UseUrls($"http://localhost:{Environment.GetEnvironmentVariable("PORT")}/")
        //     .Build();

        // CreateHostBuilder(args).Build().Run();
    }

    // public static IHostBuilder CreateHostBuilder(string[] args) =>
    //     Host.CreateDefaultBuilder(args)
    //         .ConfigureWebHostDefaults(webBuilder =>
    //         {
    //             webBuilder.UseStartup<Startup>();
    //         });
}
