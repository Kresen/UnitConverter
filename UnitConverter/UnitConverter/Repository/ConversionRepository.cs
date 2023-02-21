using Microsoft.EntityFrameworkCore;
using UnitConverter.Api.Data;
using UnitConverter.Api.Entities;
using UnitConverter.Api.Repository.Interfaces;

namespace UnitConverter.Api.Repository
{
    public class ConversionRepository : IConversionRepository
    {
        private readonly ConversionRateDbContext _context;

        public ConversionRepository(ConversionRateDbContext context)
        {
            _context = context;
        }

        public async Task<ConversionRate> GetConversionByName(string unitFrom)
        {
            return await _context.ConversionRates.FirstOrDefaultAsync(c => c.UnitFrom == unitFrom);
        }

        public async Task<List<ConversionRate>> GetAllConversions()
        {
            return await _context.ConversionRates.ToListAsync();
        }
    }
}
