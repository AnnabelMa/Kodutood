using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using VL1.Facade.Common;

namespace VL1.Facade.Quantity
{
    public sealed class UnitView: DefinedView
    {
        [Required]
        [DisplayName("Measure")]
        public string MeasureId { get; set; }
    }
}
