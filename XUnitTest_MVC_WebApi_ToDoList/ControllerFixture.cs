using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net.Http;

namespace XUnitTest_MVC_WebApi_ToDoList
{
    public class ControllerFixture<TStartup> : IDisposable where TStartup : class
    {
        public HttpClient Client { get; }
        public TestServer Server { get; }

        public ControllerFixture()
        {
            var builder = WebHost
                .CreateDefaultBuilder()
                .UseStartup<TStartup>()
                .UseDefaultServiceProvider(options => options.ValidateScopes = false);

            Server = new TestServer(builder);
            Client = Server.CreateClient();
        }

        public void Dispose()
        {
            Client.Dispose();
            Server.Dispose();
        }
	}
}
