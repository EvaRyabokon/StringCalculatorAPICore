using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;


namespace StringCalculator.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get(string input)
        {
            var calculator = new Calculator();
            var result = calculator.CalculateString(input.Trim().Replace(" ", "+"));
            return new string[] { result.ToString() };
        }

    }
}
