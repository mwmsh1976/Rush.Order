using Microsoft.AspNetCore.Mvc;

namespace Rush.Order.Models
{
    public class LogResult
    {
        public string LogResultText { get; set; }
        public IActionResult HttpResult { get; set; }
    }
}
