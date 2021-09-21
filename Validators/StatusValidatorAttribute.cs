using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Rush.Api.Core.Client.Interfaces;
using Rush.Order.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Rush.Order.Validators
{
    public class StatusValidatorAttribute : IAsyncActionFilter
    {
        private IServiceClient _serviceClient;

        public StatusValidatorAttribute(IServiceClient serviceClient)
        {
            _serviceClient = serviceClient;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.ActionArguments.Count > 0 &&
                context.ActionArguments.ContainsKey("updateOrderRequest"))
            {
                var request = context.ActionArguments["updateOrderRequest"] as UpdateOrderRequest;
                if(request != null)
                {
                    Models.Enums.Status statusValue;
                    if (!Enum.TryParse(Convert.ToString(request.Status), out statusValue))
                    {
                        var modelState = new ModelStateDictionary(){;
                        modelState.AddModelError("Status", "The provided status is invalid.");
                        context.Result = new BadRequestObjectResult(modelState);
                        return;
                    }
                    
                }                
            }
            await next();
        }

        public async Task OnActionExecutedAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //This would be where we would log to the message queue
            var resultObject = context.Result as Models.Order;
            if (resultObject != null )
            {
                if (resultObject.Status.ToLower() == "billed" ||
                   resultObject.Status.ToLower() == "shipped" ||
                   resultObject.Status.ToLower() == "delivered")
                {
                    var loggingContent = new StringContent(JsonConvert.SerializeObject("This is the log message"),
                    Encoding.UTF8, "application/json");
                    var logIt = await _serviceClient.PostAsync<LogResult>("https://api.rush.logging.com/logentry/", loggingContent);
                }
            }                        
        }
    }
}