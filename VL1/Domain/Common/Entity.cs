using VL1.Data.Common;

namespace VL1.Domain.Common
{
    public abstract class Entity<T> where T: PeriodData
    {
        public T Data { get; }

        protected Entity(T data)
        {
            Data = data;
        }
    }
}