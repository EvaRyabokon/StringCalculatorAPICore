using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;


namespace StringCalculator.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        Calculator calculator = new Calculator();
        ExpressionValidator validator = new ExpressionValidator();

        [HttpGet]
        public JsonResult Get(string input)
        {
            var validationResult = validator.Validate(input);
            if (!validationResult.IsSuccessful)
            {
                return new JsonResult(new Dictionary<string, string>() { { "error", validationResult.Error } })
                { 
                    StatusCode = 400
                };
            }

            var result = calculator.CalculateString(input);
            return new JsonResult(new Dictionary<string, string>() { { "result", result.ToString() } });
        }
    }
}
