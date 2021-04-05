using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SportsStore.Models.ViewModels;
using System.Collections.Generic;

namespace SportsStore.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;
        public PageLinkTagHelper(IUrlHelperFactory helperFactory)
        {
            urlHelperFactory = helperFactory;
        }
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext viewContext { get; set; }
        public PagingInfo PageModel { get; set; }
        public string PageAction { get; set; }

        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>();
        public string PageClass { get; set; }
        public bool PageClassesEnabled { get; set; } = false;
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(viewContext);
            TagBuilder tagBuilder = new TagBuilder("div");
            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                TagBuilder builder = new TagBuilder("a");
                PageUrlValues["productPage"] = i;
                builder.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);
                builder.Attributes["href"] = urlHelper.Action(PageAction, new { ProductPage = i });
                if (PageClassesEnabled)
                {
                    builder.AddCssClass(PageClass);
                    builder.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                }
                builder.InnerHtml.Append(i.ToString());
                tagBuilder.InnerHtml.AppendHtml(builder);
            }
            output.Content.AppendHtml(tagBuilder.InnerHtml);
        }
    }
}