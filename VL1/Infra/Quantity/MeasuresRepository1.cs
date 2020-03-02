using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VL1.Domain.Quantity;
using System.Linq;
using VL1.Data.Quantity;

namespace VL1.Infra.Quantity
{
    public class MeasuresRepository : UniqueEntityRepository<Measure, MeasureData>, IMeasuresRepository
    {
        public MeasuresRepository(QuantityDbContext c) : base(c, c.Measures) {}

        public override async Task<List<Measure>> Get()
        {
            var list = await createPaged(createFiltered(CreateSorted()));//SELECT lause paneb kirja
            HasNextPage = list.HasNextPage;
            HasPreviousPage = list.HasPreviousPage;

            //valib kõik, teeb ära teisenduse, lisab listi.
            //Filtered teeb select lausesse "väär" osa
            return list.Select(e => new Measure(e)).ToList(); //foreach tsükkel algupäraselt
        }
        private async Task<PaginatedList<MeasureData>>createPaged(IQueryable<MeasureData> dataSet)
        {
             return await PaginatedList<MeasureData>.CreateAsync(
                dataSet, PageIndex, PageSize);
        }
        private IQueryable<MeasureData> createFiltered(IQueryable<MeasureData> set)
        {
            if (string.IsNullOrEmpty(SearchString)) return set;
            return set.Where(s => s.Name.Contains(SearchString) 
                                    || s.Code.Contains(SearchString)
                                    || s.Id.Contains(SearchString)
                                    || s.Definition.Contains(SearchString)
                                    || s.ValidFrom.ToString().Contains(SearchString)
                                    || s.ValidTo.ToString().Contains(SearchString));
        }
        private IQueryable<MeasureData> CreateSorted()//meetod teeb päringu andmebaasi, sorteerib
        {
            IQueryable<MeasureData> measures = from s in dbSet select s;
            measures = setSorting(measures);
            return measures.AsNoTracking();
        }
    }
}
