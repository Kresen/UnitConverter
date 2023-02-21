using UnitConverter.Api.Dto;
using UnitConverter.Api.Repository.Interfaces;
using UnitConverter.Api.Services.interfaces;

namespace UnitConverter.Api.Services
{
    public class ConversionService : IConversionService
    {
        private readonly IConversionRepository _conversionRepository;
        public ConversionService(IConversionRepository conversionRepository)
        {
            _conversionRepository = conversionRepository;
        }

        public async Task<ConversionResultDTO> Convert(decimal value, string fromUnit, string toUnit)
        {
            var conversion = await _conversionRepository.GetConversionByName(fromUnit);
           
            if (conversion == null)
            {
                throw new ArgumentException($"No conversion rate found from {fromUnit} to {toUnit}.");
            }

            decimal result = value * conversion.Rate;

            return new ConversionResultDTO
            {
                Value = Math.Round(result, 2),
                Unit = toUnit
            };
        }


        public async Task<List<ConversionDTO>> GetAllConversions()
        {

            var conversions = await _conversionRepository.GetAllConversions();
            var conversionsList = conversions.Select(x => new ConversionDTO { FromUnit = x.UnitFrom, ToUnit = x.UnitTo,Id = x.Id, Rate = x.Rate }).ToList() ?? new List<ConversionDTO>(); 
            return conversionsList;
        }
    }
}
