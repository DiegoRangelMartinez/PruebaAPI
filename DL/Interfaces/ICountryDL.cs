using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface ICountryDL
    {
        Task<List<Country>> SelectCountries();
		Task<Country> SelectCountry(string code);
		Task<Country> InsertCountry(Country item);
		Task<Country> UpdateCountry(Country item);
		Task<bool> DeleteCountry(string code);
	}
}
