using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
//using VL1.Domain.Common;
using VL1.Domain.Quantity;
using System.Linq;

namespace VL1.Infra.Quantity
{
    public class MeasuresRepository : IMeasuresRepository
    {
        private readonly QuantityDbContext db;

        public MeasuresRepository(QuantityDbContext c)
        {
            db = c;
        }

        public async Task<List<Measure>> Get()
        {
            var l = await db.Measures.ToListAsync();

            //valib kõik, teeb ära teisenduse, lisab listi.
            return l.Select(e => new Measure(e)).ToList(); //foreach tsükkel algupäraselt
            
        }
        public async Task<Measure> Get(string id)
        {
            var d = await db.Measures.FirstOrDefaultAsync(m => m.Id == id);
            return new Measure(d);
        }
        public async Task Delete(string id)
        {
            var d = await db.Measures.FindAsync(id);

                if (d is null) return;
            
                db.Measures.Remove(d);
                await db.SaveChangesAsync();
        }
        public async Task Add(Measure obj)
        {
            db.Measures.Add(obj.Data);

            await db.SaveChangesAsync();
        }
        public async  Task Update(Measure obj)
        {
            var d = await db.Measures.FirstOrDefaultAsync(x => x.Id == obj.Data.Id);
            d.Code = obj.Data.Code;
            d.Name = obj.Data.Name;
            d.Definition = obj.Data.Definition;
            d.Validfrom = obj.Data.Validfrom;
            d.ValidTo = obj.Data.ValidTo;
            db.Measures.Update(d);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!MeasureViewExists(db.Id))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
            }
        }

        //Task<Measure> IRepository<Measure>.Get(string id)
        //{
        //    throw new System.NotImplementedException();
        //}

        //Task IRepository<Measure>.Delete(string id)
        //{
        //    throw new System.NotImplementedException();
        //}

        //Task IRepository<Measure>.Add(Measure obj)
        //{
        //    throw new System.NotImplementedException();
        //}

        //Task IRepository<Measure>.Update(Measure obj)
        //{
        //    throw new System.NotImplementedException();
        //}
        
    }
}
