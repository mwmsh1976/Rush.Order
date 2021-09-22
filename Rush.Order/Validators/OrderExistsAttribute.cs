using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Rush.Order.Models;
using Rush.Order.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rush.Order.Validators
{
    public class OrderExistsAttribute : IAsyncActionFilter
    {
        private readonly IOrderService _orderService;

        public OrderExistsAttribute(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.ActionArguments.Count > 0 &&
                context.ActionArguments.ContainsKey("updateOrderRequest"))
            {
                UpdateOrderRequest request = context.ActionArguments["updateOrderRequest"] as UpdateOrderRequest;
                if (request != null)
                {
                    if (await _orderService.GetOrderByOrderId(request.Id) == null)
                    {
                        //With more time I would normally create a nicer return object than this
                        context.Result = new BadRequestObjectResult("There is no order with an Id of " + 
                            request.Id.ToString());
                        return;
                    }
                }
            }
            await next();
        }

    }
}
