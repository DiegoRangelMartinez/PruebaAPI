using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
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
			var item = await SelectCountry(code);
			_context.Countries.Remove(item);
			await _context.SaveChangesAsync();
			return true;
		}
	}
}
