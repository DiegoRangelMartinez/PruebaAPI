using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IDepartmentDL
    {
		Task<List<Department>> SelectDepartmentsByCountryCode(string countryCode);
		Task<Department> SelectDepartment(string code);
		Task<Department> InsertDepartment(Department item);
		Task<Department> UpdateDepartment(Department item);
		Task<bool> DeleteDepartment(string code);
		Task<Dictionary<string, bool>> ValidateKeys(Department item);
	}
}
