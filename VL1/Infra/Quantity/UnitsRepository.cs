using VL1.Data.Quantity;
using VL1.Domain.Quantity;

namespace VL1.Infra.Quantity
{
    public class UnitsRepository : UniqueEntityRepository<Unit, UnitData>, IUnitsRepository
    {
        public UnitsRepository(QuantityDbContext c) : base(c, c.Units) { }

        protected internal override Unit toDomainObject(UnitData d) => new Unit(d);
    }
}
