using Microsoft.AspNetCore.Mvc;
using Moq;
using Rush.Order.Controllers;
using Rush.Order.Services.Interfaces;
using Rush.Order.Tests.Classes;
using Xunit;

namespace Rush.Order.Tests.Tests.Controllers.OrderControllerTests
{
    public class GetOrderByOrderNumberTests
    {
        private readonly DummyData _dummyData;

        public GetOrderByOrderNumberTests()
        {
            _dummyData = DummyData.Instance;
        }

        [Fact]
        public async void GetOrderByOrderNumber_Should_Pass()
        {
            //Arrange
            var mockedOrderService = new Mock<IOrderService>();
            mockedOrderService.Setup(s => s.GetOrderByOrderNumber(It.IsAny<string>()))
                .ReturnsAsync(_dummyData.OrderModel);
            var orderController = new OrderController(mockedOrderService.Object);

            //Act
            var callResult = await orderController.GetOrderByOrderNumber(_dummyData.ModelOrderByNumberRequest);
            var okObjectResult = callResult.Result as OkObjectResult;
            var order = okObjectResult.Value as Models.Order;

            //Assert
            Assert.NotNull(okObjectResult.Value);
            Assert.Equal(order.OrderNumber, _dummyData.OrderNumber);
        }

        [Fact]
        public async void GetOrderByOrderNumber_NoContent_Should_Fail()
        {
            //Arrange
            var mockedOrderService = new Mock<IOrderService>();
            mockedOrderService.Setup(s => s.GetOrderByOrderNumber(It.IsAny<string>()))
                .ReturnsAsync(_dummyData.OrderNullModel);
            var orderController = new OrderController(mockedOrderService.Object);

            //Act
            var callResult = await orderController.GetOrderByOrderNumber(_dummyData.ModelOrderByNumberRequest);
            var noContentResult = callResult.Result as NoContentResult;

            //Assert
            Assert.NotNull(noContentResult);
            Assert.Equal(204, noContentResult.StatusCode);
        }
        
    }
}
