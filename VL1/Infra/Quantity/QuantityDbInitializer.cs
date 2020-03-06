using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Internal;

namespace VL1.Infra.Quantity
{
    public static class QuantityDbInitializer
    {
        public static void Initialize(QuantityDbContext db)
        {
            if (db.Measures.Any()) return;
            db.Measures.AddRange(measures);
            db.SaveChanges();
        }
    }
}
 