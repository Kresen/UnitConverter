using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitConverter.Api.Dto;
using UnitConverter.Api.Services.interfaces;

namespace UnitConverter.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConversionController : ControllerBase
    {
        private readonly IConversionService _conversionService;

        public ConversionController(IConversionService conversionService)
        {
            _conversionService = conversionService;
        }

        [HttpGet("{fromUnit}/{toUnit}/{value}")]
        public async Task<ActionResult<ConversionResultDTO>> Convert(string fromUnit, string toUnit, decimal value)
        {
            try
            {
                var result = await _conversionService.Convert(value, fromUnit, toUnit);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Conversions")]
        public async Task<ActionResult<ConversionResultDTO>> GetAllConversion()
        {
            try
            {
                var result = await _conversionService.GetAllConversions();
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
