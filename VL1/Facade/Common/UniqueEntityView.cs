using System.ComponentModel.DataAnnotations;

namespace VL1.Facade.Common
{
    public abstract class UniqueEntityView : PeriodView
    {
        [Required]
        public string Id { get; set; }
    }
}