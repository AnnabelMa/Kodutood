﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VL1.Domain.Quantity;
using System.Linq;
using VL1.Data.Quantity;
using System;

namespace VL1.Infra.Quantity
{
    public class MeasuresRepository : IMeasuresRepository
    {
        protected internal QuantityDbContext db;
        public string SortOrder { get; set; }
        public string SearchString { get; set; }

        public MeasuresRepository(QuantityDbContext c)
        {
            db = c;
        }
        public async Task<List<Measure>> Get()
        {
            var list = await createFiltered(CreateSorted()).ToListAsync();//SELECT lause paneb kirja
            //valib kõik, teeb ära teisenduse, lisab listi.
            //Filtered teeb select lausesse "väär" osa
            return list.Select(e => new Measure(e)).ToList(); //foreach tsükkel algupäraselt
        }

        private IQueryable<MeasureData> createFiltered(IQueryable<MeasureData> set)
        {
            if (string.IsNullOrEmpty(SearchString)) return set;
            return set.Where(s => s.Name.Contains(SearchString) 
                                    || s.Code.Contains(SearchString)
                                    || s.Id.Contains(SearchString)
                                    || s.Definition.Contains(SearchString)
                                    || s.Validfrom.ToString().Contains(SearchString)
                                    || s.ValidTo.ToString().Contains(SearchString));
        }

        private IQueryable<MeasureData> CreateSorted()
        {
            IQueryable<MeasureData> measures = from s in db.Measures select s;
            switch (SortOrder)
            {
                case "name_desc":
                    measures = measures.OrderByDescending(s => s.Name);
                    break;
                case "Date":
                    measures = measures.OrderBy(s => s.Validfrom);
                    break;
                case "date_desc":
                    measures = measures.OrderByDescending(s => s.Validfrom);
                    break;
                default:
                    measures = measures.OrderBy(s => s.Name);
                    break;
            }
            return measures.AsNoTracking();//teeb päringu
        }
        public async Task<Measure> Get(string id)
        {
            var d = await db.Measures.FirstOrDefaultAsync(m => m.Id == id);//paneb SELECT lause kirja SQLis
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
            }
        }
    }
}
