namespace Tutkoo.mintyfusion.CenterPoint.StepsPanel
{
    #region namespace
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    #endregion namespace

    #region Class
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
    #endregion Class
}
