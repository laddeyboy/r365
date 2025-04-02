using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StringCalculatorHandlers.Handlers;

namespace StringCalculator.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class StringCalculatorApi : ControllerBase
    {
        readonly IStringCalculatorHandler _calcHandler;
        
        public StringCalculatorApi(IStringCalculatorHandler calcHandler)
        {
            _calcHandler = calcHandler;
        }

        [HttpPost("calculate")]
        public async Task<IActionResult> Calculate([FromBody] StringCalculatorRequest request)
        {
            try
            {
                var result = await _calcHandler.Calculate(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
    }
}
