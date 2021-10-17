using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using DL;
using Microsoft.AspNetCore.Http;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryDL _iDL;
        public CountryController(ICountryDL iDL)
        {
            _iDL = iDL;
        }
        [HttpGet("SelectCountries")]
        public async Task<IActionResult> SelectCountries()
        {
            try
            {
                var items = await _iDL.SelectCountries();
                return Ok(items);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
