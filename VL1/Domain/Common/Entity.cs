using VL1.Data.Common;

namespace VL1.Domain.Common
{
    public abstract class Entity<TData> where TData: PeriodData, new()
    {
        protected internal Entity(TData d = null) => Data = d ?? new TData();
        public TData Data { get; internal set; }
    }
}