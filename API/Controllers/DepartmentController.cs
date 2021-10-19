using DL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class DepartmentController : ControllerBase
	{
		private readonly IDepartmentDL _iDL;
		public DepartmentController(IDepartmentDL iDL)
		{
			_iDL = iDL;
		}
		[HttpGet("SelectDepartmentsByCountryCode/{countryCode}")]
		public async Task<IActionResult> SelectDepartmentsByCountryCode(string countryCode)
		{
			try
			{
				List<Department> items = await _iDL.SelectDepartmentsByCountryCode(countryCode);
				return Ok(items);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}
		[HttpGet("SelectDepartment/{code}")]
		public async Task<IActionResult> SelectDepartment(string code)
		{
			try
			{
				Department item = await _iDL.SelectDepartment(code);
				return Ok(item);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}
		[HttpPost("InsertDepartment")]
		public async Task<IActionResult> InsertDepartment([FromBody] Department item)
		{
			try
			{
				await _iDL.InsertDepartment(item);
				return Ok(item);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpPut("UpdateDepartment/{id}")]
		public async Task<IActionResult> UpdateDepartment([FromBody] Department item)
		{
			try
			{
				await _iDL.UpdateDepartment(item);
				return Ok(item);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}
		[HttpDelete("DeleteDepartment/{code}")]
		public async Task<IActionResult> DeleteDepartment(string code)
		{
			try
			{
				await _iDL.DeleteDepartment(code);
				return Ok();
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpPost("ValidateKeys")]
		public async Task<IActionResult> ValidateKeys([FromBody] Department department)
		{
			try
			{
				Dictionary<string, bool> item = await _iDL.ValidateKeys(department);
				return Ok(item);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}
	}
}

