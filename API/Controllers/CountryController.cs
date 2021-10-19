using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using DL;
using Microsoft.AspNetCore.Http;
using Models;
using System.Collections.Generic;

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
                List<Country> items = await _iDL.SelectCountries();
                return Ok(items);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("SelectCountry/{code}")]
        public async Task<IActionResult> SelectCountry(string code)
        {
            try
            {
                Country item = await _iDL.SelectCountry(code);
                return Ok(item);
            }
            catch (Exception ex)
            {
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}
		[HttpPost("ValidateKeys")]
		public async Task<IActionResult> ValidateKeys([FromBody] Country country)
		{
			try
			{
				Dictionary<string, bool> item = await _iDL.ValidateKeys(country);
				return Ok(item);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}
		[HttpPost("InsertCountry")]
		public async Task<IActionResult> InsertCountry([FromBody] Country item)
		{
			try
			{
				await _iDL.InsertCountry(item);
				return Ok(item);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpPut("UpdateCountry/{id}")]
		public async Task<IActionResult> UpdateCountry([FromBody] Country item)
		{
			try
			{
				await _iDL.UpdateCountry(item);
				return Ok(item);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}
		[HttpDelete("DeleteCountry/{id}")]
		public async Task<IActionResult> DeleteCountry(string code)
		{
			try
			{
				await _iDL.DeleteCountry(code);
				return Ok();
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}
	}
}
