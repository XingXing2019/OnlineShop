#pragma checksum "F:\C#\Projects\OnlineShop\Shop\Shop.UI\Pages\Cart.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "163231e896802f5e182542fd2d3e62dbf9b97ff6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Shop.UI.Pages.Pages_Cart), @"mvc.1.0.razor-page", @"/Pages/Cart.cshtml")]
namespace Shop.UI.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "F:\C#\Projects\OnlineShop\Shop\Shop.UI\Pages\_ViewImports.cshtml"
using Shop.UI;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"163231e896802f5e182542fd2d3e62dbf9b97ff6", @"/Pages/Cart.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc89f9d87ee47402434e9d6268c16a4c581ff966", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Cart : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div>\r\n    <p>");
#nullable restore
#line 7 "F:\C#\Projects\OnlineShop\Shop\Shop.UI\Pages\Cart.cshtml"
  Write(Model.CartProduct.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <p>");
#nullable restore
#line 8 "F:\C#\Projects\OnlineShop\Shop\Shop.UI\Pages\Cart.cshtml"
  Write(Model.CartProduct.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <p>");
#nullable restore
#line 9 "F:\C#\Projects\OnlineShop\Shop\Shop.UI\Pages\Cart.cshtml"
  Write(Model.CartProduct.Qty);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <p>");
#nullable restore
#line 10 "F:\C#\Projects\OnlineShop\Shop\Shop.UI\Pages\Cart.cshtml"
  Write(Model.CartProduct.StockId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Shop.UI.Pages.CartModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Shop.UI.Pages.CartModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Shop.UI.Pages.CartModel>)PageContext?.ViewData;
        public Shop.UI.Pages.CartModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
