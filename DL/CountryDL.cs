using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DL
{
	public class CountryDL : ICountryDL
	{
		private readonly PruebaAPIDBContext _context;
		public CountryDL(PruebaAPIDBContext context)
		{
			_context = context;
		}
		public async Task<List<Country>> SelectCountries()
		{
			return await _context.Countries.ToListAsync();
		}
		public async Task<Country> SelectCountry(string code)
		{
			return await _context.Countries.FindAsync(code);
		}
		public async Task<Country> InsertCountry(Country item)
		{
			_context.Countries.Add(item);
			await _context.SaveChangesAsync();
			return item;
		}
		public async Task<Country> UpdateCountry(Country item)
		{
			_context.Entry(item).State = EntityState.Modified;
			await _context.SaveChangesAsync();
			return item;
		}
		public async Task<bool> DeleteCountry(string code)
		{
			Country item = await SelectCountry(code);
			_context.Countries.Remove(item);
			await _context.SaveChangesAsync();
			return true;
		}
		public async Task<Dictionary<string, bool>> ValidateKeys(Country country)
		{
			Dictionary<string, bool> item = new();
			Country countryCode = await _context.Countries.Where(x => x.Code == country.Code).FirstOrDefaultAsync();
			Country countryAlphaCodeThree = await _context.Countries.Where(x => x.AlphaCodeThree == country.AlphaCodeThree).FirstOrDefaultAsync();
			Country countryNumericCode = await _context.Countries.Where(x => x.NumericCode == country.NumericCode).FirstOrDefaultAsync();
			item.Add("IsCodeValid", countryCode == null);
			item.Add("IsAlphaCodeThreeValid", countryAlphaCodeThree == null);
			item.Add("IsNumericCodeValid", countryNumericCode == null);
			return item;
		}
	}
}
