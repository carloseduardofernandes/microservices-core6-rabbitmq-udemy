using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace RestWithASPNETUdemy.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{
    private readonly ILogger<CalculatorController> _logger;

    public CalculatorController(ILogger<CalculatorController> logger)
    {
        _logger = logger;
    }

    [HttpGet("sum/{firstNumber}/{secondNumber}")]
    public IActionResult Get(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertoToDecimal(firstNumber) + ConvertoToDecimal(secondNumber);
            return Ok(sum);
        }

        return BadRequest("Invalid input");
    }
    private bool IsNumeric(string strNumber)
    {
        bool isNumber = double.TryParse(strNumber, NumberStyles.Any,
            NumberFormatInfo.InvariantInfo, out _);

        return isNumber;
    }
    private decimal ConvertoToDecimal(string strNumber)
    {
        decimal decimalValue;

        if(decimal.TryParse(strNumber, out decimalValue))
        {
            return decimalValue;
        }

        return 0;
    }


}
