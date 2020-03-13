using VL1.Domain.Quantity;
using VL1.Data.Quantity;

namespace VL1.Infra.Quantity
{
    public class MeasuresRepository : UniqueEntityRepository<Measure, MeasureData>, IMeasuresRepository
    {
        public MeasuresRepository(QuantityDbContext c) : base(c, c.Measures) {}

        protected internal override Measure toDomainObject(MeasureData d) => new Measure(d);
    }
}
