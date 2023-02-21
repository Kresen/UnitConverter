using System.ComponentModel.DataAnnotations.Schema;

namespace UnitConverter.Api.Entities
{
    public class ConversionRate
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UnitFrom { get; set; }
        public string UnitTo { get; set; }
        public decimal Rate { get; set; }
    }
}
