using UnitConverter.Api.Dto;

namespace UnitConverter.Api.Services.interfaces
{
    public interface IConversionService
    {
        Task<ConversionResultDTO> Convert(decimal value, string fromUnit, string toUnit);
        Task<List<ConversionDTO>> GetAllConversions();
    }
}
