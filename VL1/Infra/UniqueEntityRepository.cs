using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VL1.Data.Common;
using VL1.Domain.Common;

namespace VL1.Infra
{
    public abstract class UniqueEntityRepository<TDomain, TData>: PaginatedRepository<TDomain, TData>
    where TData: UniqueEntityData, new()
    where TDomain: Entity<TData>, new()
    {
        protected UniqueEntityRepository(DbContext c, DbSet<TData> s) : base(c, s) { }

        protected override async Task<TData> getData(string id)
            => await dbSet.FirstOrDefaultAsync(m => m.Id == id);
    }
}
