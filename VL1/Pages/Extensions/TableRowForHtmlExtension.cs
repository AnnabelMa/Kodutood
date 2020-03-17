using System.Collections.Generic;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VL1.Pages.Extensions {
    public static class TableRowForHtmlExtension {
        public static IHtmlContent TableRowFor(
            this IHtmlHelper htmlHelper, string page, object index,
            params IHtmlContent[] values) {
            var htmlStrings = new List<object>();
            foreach (var value in values) addValue(htmlStrings, value);
            htmlStrings.Add(new HtmlString("<td>"));
            htmlStrings.Add(new HtmlString($" < a href =\"{page}/Edit?id={index}\">{Constants.EditLinkTitle}</a>"));
            htmlStrings.Add(new HtmlString(" | "));
            htmlStrings.Add(new HtmlString($"<a href=\"{page}/Details?id={index}\">{Constants.DetailsLinkTitle}</a>"));
            htmlStrings.Add(new HtmlString(" |"));
            htmlStrings.Add(new HtmlString($" < a href =\"{page}/Delete?id={index}\">{Constants.DeleteLinkTitle}</a>"));
            htmlStrings.Add(new HtmlString("</td>"));
            return new HtmlContentBuilder(htmlStrings);
        }

        private static List<object> htmlStrings(string page, object index, IHtmlContent[] values) {
            var list = new List<object>();
            foreach (var value in values) addValue(list, value);
            list.Add(new HtmlString("<td>"));
            list.Add(new HtmlString($"<a href=\"{page}/Edit?id={index}\">{Constants.EditLinkTitle}</a>"));
            list.Add(" | ");
            list.Add(new HtmlString($"<a href=\"{page}/Details?id={index}\">{Constants.DetailsLinkTitle}</a>"));
            list.Add(" | ");
            list.Add(new HtmlString($"<a href=\"{page}/Delete?id={index}\">{Constants.DeleteLinkTitle}</a>"));
            list.Add(new HtmlString("</td>"));

            return list;
        }

        public static IHtmlContent TableRowFor(
            this IHtmlHelper htmlHelper, string page, object index, 
            string fixedFilter, string fixedValue,

            params IHtmlContent[] values) {
            var htmlStrings = new List<object>();
            foreach (var value in values) addValue(htmlStrings, value);
            htmlStrings.Add(new HtmlString("<td>"));
            htmlStrings.Add(new HtmlString($" < a href =\"{page}/Edit?id={index}&fixedFilter={fixedFilter}&fixedValue={fixedValue}\">{Constants.EditLinkTitle}</a>"));
            htmlStrings.Add(new HtmlString(" | "));
            htmlStrings.Add(new HtmlString($"<a href=\"{page}/Details?id={index}&fixedFilter={fixedFilter}&fixedValue={fixedValue}\">{Constants.DetailsLinkTitle}</a>"));
            htmlStrings.Add(new HtmlString(" |"));
            htmlStrings.Add(new HtmlString($" < a href =\"{page}/Delete?id={index}&fixedFilter={fixedFilter}&fixedValue={fixedValue}\">{Constants.DeleteLinkTitle}</a>"));
            htmlStrings.Add(new HtmlString("</td>"));
            return new HtmlContentBuilder(htmlStrings);
        }

        private static List<object> htmlStrings(string page, object index, string fixedFilter, string fixedValue, IHtmlContent[] values) {
            var list = new List<object>();
            foreach (var value in values) addValue(list, value);
            list.Add(new HtmlString("<td>"));
            list.Add(new HtmlString($"<a href=\"{page}/Edit?id={index}&FixedFilter={fixedFilter}&FixedValue={fixedValue}\">{Constants.EditLinkTitle}</a>"));
            list.Add(" | ");
            list.Add(new HtmlString($"<a href=\"{page}/Details?id={index}&FixedFilter={fixedFilter}&FixedValue={fixedValue}\">{Constants.DetailsLinkTitle}</a>"));
            list.Add(" | ");
            list.Add(new HtmlString($"<a href=\"{page}/Delete?id={index}&FixedFilter={fixedFilter}&FixedValue={fixedValue}\">{Constants.DeleteLinkTitle}</a>"));
            list.Add(new HtmlString("</td>"));

            return list;
        }

        public static IHtmlContent TableRowWithSelectFor(
            this IHtmlHelper htmlHelper, string page, object index,
            string sortOrder, string searchString, int pageIndex, string fixedFilter, string fixedValue,

            params IHtmlContent[] values)
        {
            var s = htmlStringsWithSelect(page, index, sortOrder, searchString, pageIndex, fixedFilter, fixedValue, values);
            return new HtmlContentBuilder(s);
        }

        private static List<object> htmlStringsWithSelect(string page, object id, string sortOrder, string searchString, int pageIndex, string fixedFilter, string fixedValue, IHtmlContent[] values)
        {
            var list = new List<object>();
            foreach (var value in values) addValue(list, value);
            var s = $"?id={id}";
            s += $"&FixedFilter={fixedFilter}";
            s += $"&FixedValue={fixedValue}";
            s += $"&sortOrder={sortOrder}";
            s += $"&searchString={searchString}";
            s += $"&pageIndex={pageIndex}";

            list.Add(new HtmlString("<td>"));
            list.Add(new HtmlString($"<a href=\"{page}/Index{s}\">{Constants.SelectLinkTitle}</a>"));
            list.Add(" | ");
            list.Add(new HtmlString($"<a href=\"{page}/Edit{s}\">{Constants.EditLinkTitle}</a>"));
            list.Add(" | ");
            list.Add(new HtmlString($"<a href=\"{page}/Details{s}\">{Constants.DetailsLinkTitle}</a>"));
            list.Add(" | ");
            list.Add(new HtmlString($"<a href=\"{page}/Delete{s}\">{Constants.DeleteLinkTitle}</a>"));
            list.Add(new HtmlString("</td>"));

            return list;
        }

        public static IHtmlContent TableRowWithSelectFor(
            this IHtmlHelper htmlHelper, string page, object index,
            string fixedFilter, string fixedValue,

            params IHtmlContent[] values)
        {
            var s = htmlStringsWithSelect(page, index, fixedFilter, fixedValue, values);
            return new HtmlContentBuilder(s);
        }

        private static List<object> htmlStringsWithSelect(string page, object index, string fixedFilter, string fixedValue, IHtmlContent[] values)
        {
            var list = new List<object>();
            foreach (var value in values) addValue(list, value);
            list.Add(new HtmlString("<td>"));
            list.Add(new HtmlString($"<a href=\"{page}/Select?id={index}&FixedFilter={fixedFilter}&FixedValue={fixedValue}\">{Constants.SelectLinkTitle}</a>"));
            list.Add(" | ");
            list.Add(new HtmlString($"<a href=\"{page}/Edit?id={index}&FixedFilter={fixedFilter}&FixedValue={fixedValue}\">{Constants.EditLinkTitle}</a>"));
            list.Add(" | ");
            list.Add(new HtmlString($"<a href=\"{page}/Details?id={index}&FixedFilter={fixedFilter}&FixedValue={fixedValue}\">{Constants.DetailsLinkTitle}</a>"));
            list.Add(" | ");
            list.Add(new HtmlString($"<a href=\"{page}/Delete?id={index}&FixedFilter={fixedFilter}&FixedValue={fixedValue}\">{Constants.DeleteLinkTitle}</a>"));
            list.Add(new HtmlString("</td>"));

            return list;
        }

        internal static void addValue(List<object> htmlStrings, IHtmlContent value) {
            if (htmlStrings is null) return;
            if (value is null) return;
            htmlStrings.Add(new HtmlString("<td>"));
            htmlStrings.Add(value);
            htmlStrings.Add(new HtmlString("</td>"));
        }
    }
}
