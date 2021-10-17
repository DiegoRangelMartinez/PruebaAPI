using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
	}
}
