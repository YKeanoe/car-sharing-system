using System;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Rhino.Mocks;
using System.Web.Routing;
using System.Collections.Specialized;

namespace car_sharing_systemTests
{
    [TestClass]
    public class routeConfigUnitTests
    {
        private HttpContextBase rmContext;
        private HttpRequestBase rmRequest;
        private Mock<HttpContextBase> moqContext;
        private Mock<HttpRequestBase> moqRequest;

        [TestInitialize]
        public void SetupTests() // Setup the mocks needed to simulate http request
        {
            // Setup Rhino Mocks
            rmContext = Rhino.Mocks.MockRepository.GenerateMock<HttpContextBase>();
            rmRequest = Rhino.Mocks.MockRepository.GenerateMock<HttpRequestBase>();
            rmContext.Stub(x => x.Request).Return(rmRequest);
            // Setup Moq
            moqContext = new Mock<HttpContextBase>();
            moqRequest = new Mock<HttpRequestBase>();
            moqContext.Setup(x => x.Request).Returns(moqRequest.Object);
        }

        #region Routing Tests
        [TestMethod]
        public void HomePageRoutingTest() // Tests if the home page is using the valid root directory
        {
            // Arrange
            RouteCollection routes = new RouteCollection();
            car_sharing_system.RouteConfig.RegisterRoutes(routes);
            rmRequest.Stub(e => e.AppRelativeCurrentExecutionFilePath).Return("~/");
            // Act
            RouteData routeData = routes.GetRouteData(rmContext);
            // Assert
            Assert.IsNotNull(routeData);
        }
        [TestMethod] 
        public void LoginRoutingTest()  // Tests if the login page is routed correctly to *.com/dashboard/login
        {
            // Arrange
            RouteCollection routes = new RouteCollection();
            car_sharing_system.RouteConfig.RegisterRoutes(routes);
            moqRequest.Setup(e => e.AppRelativeCurrentExecutionFilePath).Returns("~/dashboard/login");
            // Act
            RouteData routeData = routes.GetRouteData(moqContext.Object);
            // Assert
            Assert.IsNotNull(routeData);
        }
        [TestMethod]
        public void ProfileRoutingTest() // Tests if the profile page is routed correctly to *.com/dashboard/profile
        {
            // Arrange
            RouteCollection routes = new RouteCollection(); 
            car_sharing_system.RouteConfig.RegisterRoutes(routes);
            moqRequest.Setup(e => e.AppRelativeCurrentExecutionFilePath).Returns("~/dashboard/profile");
            // Act
            RouteData routeData = routes.GetRouteData(moqContext.Object);
            // Assert
            Assert.IsNotNull(routeData);
        }
        [TestMethod]
        public void BookingRoutingTest() // Tests if the booking page is routed correctly to *.com/dashboard/booking
        {
            // Arrange
            RouteCollection routes = new RouteCollection(); 
            car_sharing_system.RouteConfig.RegisterRoutes(routes);
            moqRequest.Setup(e => e.AppRelativeCurrentExecutionFilePath).Returns("~/dashboard/booking");
            // Act
            RouteData routeData = routes.GetRouteData(moqContext.Object);
            // Assert
            Assert.IsNotNull(routeData);
        }
        [TestMethod]
        public void IssueRoutingTest() // Tests if the issue page is routed correctly to *.com/dashboard/issue
        {
            // Arrange
            RouteCollection routes = new RouteCollection(); 
            car_sharing_system.RouteConfig.RegisterRoutes(routes);
            moqRequest.Setup(e => e.AppRelativeCurrentExecutionFilePath).Returns("~/dashboard/issue");
            // Act
            RouteData routeData = routes.GetRouteData(moqContext.Object);
            // Assert
            Assert.IsNotNull(routeData);
        }
        [TestMethod]
        public void RegisterRoutingTest()
        {
            // Arrange
            RouteCollection routes = new RouteCollection();
            car_sharing_system.RouteConfig.RegisterRoutes(routes);
            moqRequest.Setup(e => e.AppRelativeCurrentExecutionFilePath).Returns("~/dashboard/register");
            // Act
            RouteData routeData = routes.GetRouteData(moqContext.Object);
            // Assert
            Assert.IsNotNull(routeData);
        }
        #endregion
    }
}