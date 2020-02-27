﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Facade.Quantity;
using VL1.Domain.Quantity;
using VL1.Pages.Quantity;

namespace VL1.Soft.Areas.Quantity.Pages.Measures
{
    public class IndexModel : MeasuresPage
    {
        public string SearchString;
        public IndexModel(IMeasuresRepository r) : base(r) { }

        public async Task OnGetAsync(string sortOrder, string searchString) 
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            db.SortOrder = sortOrder;
            SearchString = searchString;
            db.SearchString = SearchString;
            var l = await db.Get();
            Items = new List<MeasureView>();
            foreach (var e in l)  Items.Add(MeasureViewFactory.Create(e));
        }
        public string DateSort { get; set; }
        public string NameSort { get; set; }
    }
}
