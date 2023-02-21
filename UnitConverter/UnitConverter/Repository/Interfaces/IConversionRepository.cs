using UnitConverter.Api.Entities;


namespace UnitConverter.Api.Repository.Interfaces
{
    public interface IConversionRepository
    {
        Task<ConversionRate> GetConversionByName(string name);
        Task<List<ConversionRate>> GetAllConversions();
    }
}
