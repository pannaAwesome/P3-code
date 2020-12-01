using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Moq;
using HAVI_app.Services.Classes;
using Moq.Protected;
using System.Net;
using System.Net.Http;
using System.Threading;

namespace HAVI_appTests
{
    [TestClass]
    class SupplierServiceTests
    {
        [TestMethod]
        public async void ShouldReturnGet()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(@"[{ ""Id"": 1, ""ProfileId"": 1, ""CompanyName"": ""Mac Donalds"",
                                            ""CompanyLocation"": ""Denmark"", ""PalletExchange"": 1, ""FreightResponsibility"": 1 }]"),
            };

            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "GetFromJsonAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);
            var httpClient = new HttpClient(handlerMock.Object);
            var posts = new SupplierService(httpClient);

            var retrievedPosts = await posts.GetSupplier(1);

            Assert.IsNotNull(retrievedPosts);
            handlerMock.Protected().Verify(
                "GetFromJsonAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get),
                ItExpr.IsAny<CancellationToken>());
        }
    }
}
