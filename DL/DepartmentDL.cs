using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DL
{
	public class DepartmentDL : IDepartmentDL
	{
		private readonly PruebaAPIDBContext _context;
		public DepartmentDL(PruebaAPIDBContext context)
		{
			_context = context;
		}
		public async Task<List<Department>> SelectDepartmentsByCountryCode(string countryCode)
		{
			return await _context.Departments.Where(x => x.CountryCode == countryCode).ToListAsync();
		}
		public async Task<Department> SelectDepartment(string code)
		{
			return await _context.Departments.FindAsync(code);
		}
		public async Task<Department> InsertDepartment(Department item)
		{
			_context.Departments.Add(item);
			await _context.SaveChangesAsync();
			return item;
		}
		public async Task<Department> UpdateDepartment(Department item)
		{
			_context.Entry(item).State = EntityState.Modified;
			await _context.SaveChangesAsync();
			return item;
		}
		public async Task<bool> DeleteDepartment(string code)
		{
			Department item = await SelectDepartment(code);
			_context.Departments.Remove(item);
			await _context.SaveChangesAsync();
			return true;
		}
		public async Task<Dictionary<string, bool>> ValidateKeys(Department department)
		{
			Dictionary<string, bool> item = new();
			Department departmentCode = await _context.Departments.Where(x => x.Code == department.Code).FirstOrDefaultAsync();
			item.Add("IsCodeValid", departmentCode == null);
			return item;
		}
	}
}
