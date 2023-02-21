namespace UnitConverter.Api.Dto
{
    public class ConversionDTO
    {
        public int Id { get; set; }
        public string FromUnit { get; set; }
        public string ToUnit { get; set; }
        public decimal Rate { get; set; }
    }
}
