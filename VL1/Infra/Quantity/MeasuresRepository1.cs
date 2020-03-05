using System.Threading.Tasks;
using VL1.Domain.Quantity;
using System.Linq;
using VL1.Data.Quantity;

namespace VL1.Infra.Quantity
{
    public class MeasuresRepository : UniqueEntityRepository<Measure, MeasureData>, IMeasuresRepository
    {
        public MeasuresRepository(QuantityDbContext c) : base(c, c.Measures) {}

        protected internal override Measure toDomainObject(MeasureData d) => new Measure(d);
        protected internal override  IQueryable<MeasureData> addFiltering(IQueryable<MeasureData> set)
        {
            if (string.IsNullOrEmpty(SearchString)) return set;
            return set.Where(s => s.Name.Contains(SearchString) 
                                    || s.Code.Contains(SearchString)
                                    || s.Id.Contains(SearchString)
                                    || s.Definition.Contains(SearchString)
                                    || s.ValidFrom.ToString().Contains(SearchString)
                                    || s.ValidTo.ToString().Contains(SearchString));
        }
    }
}
