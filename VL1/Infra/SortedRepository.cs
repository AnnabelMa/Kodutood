using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using VL1.Data.Common;
using VL1.Domain.Common;

namespace VL1.Infra
{
    public abstract class SortedRepository<TDomain, TData> : BaseRepository<TDomain, TData>, ISorting
        where TData : PeriodData, new()
        where TDomain : Entity<TData>, new()
    {
        public string SortOrder { get; set; }
        public string DescendingString => "_desc";
        protected SortedRepository(DbContext c, DbSet<TData> s) : base(c, s) { }

        protected internal override IQueryable<TData> createSqlQuery()
        {
            var query =  base.createSqlQuery();
            query = addSorting(query);
            return query;
        }
        //kirjutab lause, milles on SQL sorteerimine sees:
        protected internal IQueryable<TData> addSorting(IQueryable<TData> query)
        {
            var expression = createExpression();
            
            var r = expression is null ? query : addOrderBy(query, expression);
            return r;
        }

        internal Expression<Func<TData, object>> createExpression()
        {
            var property = findProperty();
            return property is null ? null : lambdaExpression(property);
        }

        internal Expression<Func<TData, object>> lambdaExpression(PropertyInfo p)
        {
            //1)kõigepealt tuleb öelda ära, millisest tüübist hakkad lambdaExpressionit tegema
            //2)peab ütlema, et property on parameetrist selle property info peale
            //3)property on selline, aga konventeeri property tüübiks
            //ja body on see mida hakkan kasutama
            //4) kogu body pane käituma nagu lambdaExpression
            var param = Expression.Parameter(typeof(TData), "x");
            var property = Expression.Property(param, p);
            var body = Expression.Convert(property, typeof(object));
            return Expression.Lambda<Func<TData, object>>(body, param);
        }
        internal PropertyInfo findProperty()
        {
            var name = getName();
            return typeof(TData).GetProperty(name);
        }
        internal string getName() //sortOrderist võtab pealt kõik characterid, mis on DescendingStringis
        {
            if (string.IsNullOrEmpty(SortOrder)) return string.Empty;
            var idx = SortOrder.IndexOf(DescendingString, StringComparison.Ordinal);
            return idx > 0 ? SortOrder.Remove(idx) : SortOrder;
        }
        //kui on DescendingString, tuleb sorteerida õigetpidi, kui pole, siis teistpidi.

        internal IQueryable<TData> addOrderBy(IQueryable<TData> query, Expression<Func<TData, object>> e)
        {
            if (query is null) return null;
            if (e is null) return query;
            try { return isDescending() ? query.OrderByDescending(e) : query.OrderBy(e); }
            catch { return query;}
        }
        internal bool isDescending() => !string.IsNullOrEmpty(SortOrder) && SortOrder.EndsWith(DescendingString);
    }
}