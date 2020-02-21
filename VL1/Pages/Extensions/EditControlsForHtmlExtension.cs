using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VL1.Pages.Extensions
{
    public static class EditControlsForHtmlExtension
    {
        //EditControl
        public static IHtmlContent EditControlsFor<TClasType, TPropertyType>(
            this IHtmlHelper<TClasType> htmlHelper, Expression<Func<TClasType, TPropertyType>> expression)
        {
            var s = htmlString(htmlHelper, expression);
            return new HtmlContentBuilder(s);
        }
        //teeb stringid valmis:
        internal static List<object> htmlString<TClasType, TPropertyType>(IHtmlHelper<TClasType> htmlHelper, Expression<Func<TClasType, TPropertyType>> expression)
        {
            return new List<object>
            {
                new List<object>()
                {
                    new HtmlString("<dt class=\"col-sm-2\">"),
                    htmlHelper.DisplayNameFor(expression),
                    new HtmlString("</dt>"),
                    new HtmlString("dd class= \"col-sm-10\">"),
                    htmlHelper.DisplayNameFor(expression),
                    new HtmlString("</dd>")
                }
            };
        }
    }
}
