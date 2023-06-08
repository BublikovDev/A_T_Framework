using Allure.Commons;
using Newtonsoft.Json;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TestProject1.Models;

namespace TestProject1
{
    [TestFixture]
    [AllureNUnit]
    public class ApiTests
    {
        private HttpClient _httpClient;

        [SetUp]
        public void Setup()
        {
            _httpClient = new HttpClient();
            AllureLifecycle.Instance.CleanupResultDirectory();
        }

        [TearDown]
        public void Teardown()
        {
            _httpClient.Dispose();
        }

        [Test]
        [AllureTag("Login")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureSubSuite("Authentication")]
        public async Task SuccessSignIn()
        {

            SignInRequest request = new SignInRequest() { LoginOrEmail = "DeveloperCreators", Password = "123456TESTss" };

            var response = await _httpClient.PostAsJsonAsync("https://localhost:7231/api/auth/signin", request);

            //response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        [AllureTag("Login")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureSubSuite("Authentication")]
        public async Task UnSuccessSignIn()
        {
            SignInRequest request = new SignInRequest() { LoginOrEmail = "DeveloperCreators", Password = "123456TESTss" };

            var response = await _httpClient.PostAsJsonAsync("https://localhost:7231/api/auth/signin", request);


            var responseBody = await response.Content.ReadAsStringAsync();

            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }


        [Test]
        [AllureTag("Logout")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureSubSuite("Authentication")]
        public async Task SuccessLogout()
        {

            SignInRequest request = new SignInRequest() { LoginOrEmail = "DeveloperCreator", Password = "123456TESTss" };

            var response = await _httpClient.PostAsJsonAsync("https://localhost:7231/api/auth/signin", request);

            response.EnsureSuccessStatusCode();

            var responseDelete = await _httpClient.DeleteAsync("https://localhost:7231/api/auth/logout");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
