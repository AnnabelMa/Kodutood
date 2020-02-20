using System.Collections.Generic;
using System.Threading.Tasks;
using VL1.Domain.Common;
using VL1.Domain.Quantity;

namespace VL1.Infra.Quantity
{
    public class MeasuresRepository : IMeasuresRepository
    {
        private readonly QuantityDbContext db;

        public MeasuresRepository(QuantityDbContext c)
        {
            db = c;
        }

        public Task <List<Measure>> Get()
        {
            throw new System.NotImplementedException();
        }
        public Task<List<Measure>> Get(string id)
        {
            throw new System.NotImplementedException();
        }
        public Task<List<Measure>> Delete(string id)
        {
            throw new System.NotImplementedException();
        }
        public Task<List<Measure>> Add(Measure obj)
        {
            throw new System.NotImplementedException();
        }
        public Task<List<Measure>> Update(Measure obj)
        {
            throw new System.NotImplementedException();
        }

        Task<Measure> IRepository<Measure>.Get(string id)
        {
            throw new System.NotImplementedException();
        }

        Task IRepository<Measure>.Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        Task IRepository<Measure>.Add(Measure obj)
        {
            throw new System.NotImplementedException();
        }

        Task IRepository<Measure>.Update(Measure obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
