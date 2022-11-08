
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using TribalWarsCloneDomain.Models;
using TribalWarsCloneServer;
using TribalWarsCloneServer.Socket;
using TribalWarsCloneServer.Socket.Messages;


public class Program
{
    static void Main()
    {
        SocketManager socketManager = new SocketManager();
        CreateHostBuilder().Build().Run();
        
    }
    public static IHostBuilder CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder().ConfigureWebHostDefaults(webHost => {
            webHost.UseStartup<Startup>();
        });
    }
}



