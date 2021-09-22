using Microsoft.AspNetCore.Mvc;
using Rush.Order.Models;
using Rush.Order.Models.Base_Classes;
using Rush.Order.Services.Interfaces;
using Rush.Order.Validators;
using System.Linq;
using System.Threading.Tasks;

namespace Rush.Order.Controllers
{    
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [Route("getOrderByOrderNumber/V1")]
        public async Task<ActionResult<Models.Order>> 
            GetOrderByOrderNumber([FromBody] OrderByNumberRequest orderByNumberRequest )

        {
            var order = await _orderService.GetOrderByOrderNumber(orderByNumberRequest.OrderNumber);
            if(order != null)
            {
                return Ok(order);
            }
            return NoContent();
        }

        [HttpPost]
        [Route("getOrderListByCustomerIdAndDate/V1")]
        public async Task<ActionResult<Models.Order>>
            GetOrderListByCustomerIdAndDate([FromBody] OrderListRequest orderListRequest)

        {
            var orderList = await _orderService.GetOrdersByCustomerIdAndDate(orderListRequest);
            if (orderList != null && orderList.Any())
            {
                return Ok(orderList);
            }
            return NoContent();
        }

        [HttpPost]
        [Route("addOrder/V1")]
        public async Task<ActionResult<Models.Order>> AddOrder([FromBody] CustomerIdRequest customerIdRequest)

        {
            var newOrder = await _orderService.AddOrder(customerIdRequest.CustomerId);
            if (newOrder != null)
            {
                return Ok(newOrder);
            }
            return new StatusCodeResult(500);
        }

        [HttpPost]
        [Route("updateOrder/V1")]
        [ServiceFilter(typeof(StatusValidatorAttribute))]
        [ServiceFilter(typeof(OrderExistsAttribute))]
        public async Task<ActionResult<Models.Order>> UpdateOrder([FromBody] UpdateOrderRequest updateOrderRequest)

        {
            var updatedOrder = await _orderService.UpdateOrder(updateOrderRequest);
            if (updatedOrder != null)
            {
                return Ok(updatedOrder);
            }
            return new StatusCodeResult(500);
        }
    }
}
