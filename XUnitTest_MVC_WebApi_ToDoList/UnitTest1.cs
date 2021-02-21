using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Moq;
using MVC_WebApi_ToDoList.Controllers;
using MVC_WebApi_ToDoList.DAL;
using MVC_WebApi_ToDoList.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTest_MVC_WebApi_ToDoList
{
    [Collection("Base collection")]
    public class UnitTest1 : IClassFixture<ControllerFixture<TestStartup>>
    {
        private readonly string BaseEndpoint = "http://localhost:44337";
        protected TestServer Server { get; }
        protected HttpClient Client { get; }

        public UnitTest1(ControllerFixture<TestStartup> fixture)
        {
            Server = fixture.Server;
            Client = fixture.Client;
        }

        // GET
        [Fact]
        public async Task GetReturnsListWithoutParams()
        {
            // Act
            var response = await Client.GetAsync(BaseEndpoint);
            dynamic obj = JArray.Parse(await response.Content.ReadAsStringAsync());

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(obj.Count >= 0);
        }

        // GET ByTrue
        [Fact]
        public async Task GetByIdReturnsResultWithExistingId()
        {
            // Arrange
            var IsChecked = true;

            // Act
            var response = await Client.GetAsync(BaseEndpoint + "/" + IsChecked);
            dynamic obj = JObject.Parse(await response.Content.ReadAsStringAsync());

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(IsChecked, obj.IsChecked);
        }

        // POST
        [Fact]
        public async Task PostReturnsACreatedAtRouteResultWithCorrectInputs()
        {
            // Arrange
            var content = new StringContent(JsonConvert.SerializeObject(new ToDoList
            {
                Title = "dsadas",
                Description = "dsasad",
                IsCompleted = true
            }), Encoding.UTF8, "application/json") ;

            // Act
            var response = await Client.PostAsync("api/ToDoLists", content);
            dynamic obj = JObject.Parse(await response.Content.ReadAsStringAsync());

            // Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
           /Assert.NotEqual(0, (int)obj.id);
        }
    }
}

