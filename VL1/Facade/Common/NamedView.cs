using System.ComponentModel.DataAnnotations;

namespace VL1.Facade.Common
{
    public abstract class NamedView: UniqueEntityView
    {
        [Required]
        public string Name { get; set; }
        public string Code { get; set; }
    }
}