using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VL1.Data.Common;
using VL1.Domain.Common;

namespace VL1.Infra
{
    public abstract class BaseRepository<TDomain, TData> : ICrudMethods<TDomain> 
        where TData: PeriodData, new()
        where TDomain : Entity<TData>, new()
    {
        protected internal DbContext db;
        protected internal DbSet<TData> dbSet;

        protected BaseRepository(DbContext c, DbSet<TData> s)
        {
            db = c;
            dbSet = s;
        }
        public virtual async Task<List<TDomain>> Get()
        {
            var query = createSqlQuery();//teen Sql query
            var set = await runSqlQueryAsync(query);//küsin andmebaasist andmeid vastavalt queryle, mis tegin

            return toDomainObjectsList(set);//andmebaasists saadud listi teisendan vajalikuks listiks
        }

        internal List<TDomain> toDomainObjectsList(List<TData> set) => set.Select(toDomainObject).ToList();

        protected internal abstract TDomain toDomainObject(TData periodData);

        internal async Task<List<TData>> runSqlQueryAsync(IQueryable<TData> query) =>
            await query.AsNoTracking().ToListAsync();
      
        protected internal virtual IQueryable<TData> createSqlQuery()
        {
            var query = from s in dbSet select s;
            return query;
        }
        public async Task<TDomain> Get(string id)
        {
            if (id is null) return new TDomain();

            var d = await getData(id);
            var obj = new TDomain { Data = d };

            return obj;
        }

        protected abstract Task<TData> getData(string id);
        public async Task Delete(string id)
        {
            if (id is null) return;

            var v = await dbSet.FindAsync(id);

            if (v is null) return;

            dbSet.Remove(v);
            await db.SaveChangesAsync();
        }
        public async Task Add(TDomain obj)
        {
            if (obj? .Data is null) return;

            dbSet.Add(obj.Data);

            await db.SaveChangesAsync();
        }
        public async Task Update(TDomain obj)
        {
            db.Attach(obj.Data).State = EntityState.Modified;

            try{ await db.SaveChangesAsync();}
            catch (DbUpdateConcurrencyException) { }
        }
    }
}