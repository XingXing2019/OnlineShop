#pragma checksum "F:\C#\Projects\OnlineShop\Shop\Shop.UI\Pages\Components\Cart\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "408af547e8ea8d9a5b36c3735e0f8a02403bef63"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Shop.UI.Pages.Components.Cart.Pages_Components_Cart_Default), @"mvc.1.0.view", @"/Pages/Components/Cart/Default.cshtml")]
namespace Shop.UI.Pages.Components.Cart
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"408af547e8ea8d9a5b36c3735e0f8a02403bef63", @"/Pages/Components/Cart/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"65ab2ef2d163a6251af152bfc9b3c7e0d527a978", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Components_Cart_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Shop.Domain.ViewModel.CartProductViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<div>\r\n    <h2>Big Cart Component</h2>\r\n");
#nullable restore
#line 9 "F:\C#\Projects\OnlineShop\Shop\Shop.UI\Pages\Components\Cart\Default.cshtml"
     foreach (var c in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p>");
#nullable restore
#line 11 "F:\C#\Projects\OnlineShop\Shop\Shop.UI\Pages\Components\Cart\Default.cshtml"
      Write(c.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p>");
#nullable restore
#line 12 "F:\C#\Projects\OnlineShop\Shop\Shop.UI\Pages\Components\Cart\Default.cshtml"
      Write(c.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p>");
#nullable restore
#line 13 "F:\C#\Projects\OnlineShop\Shop\Shop.UI\Pages\Components\Cart\Default.cshtml"
      Write(c.Qty);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p>");
#nullable restore
#line 14 "F:\C#\Projects\OnlineShop\Shop\Shop.UI\Pages\Components\Cart\Default.cshtml"
      Write(c.StockId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <hr/>\r\n");
#nullable restore
#line 16 "F:\C#\Projects\OnlineShop\Shop\Shop.UI\Pages\Components\Cart\Default.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Shop.Domain.ViewModel.CartProductViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
