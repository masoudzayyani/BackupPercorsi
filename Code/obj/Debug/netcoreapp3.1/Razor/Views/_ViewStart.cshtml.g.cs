#pragma checksum "C:\Users\zayya\OneDrive\Documents\GitHub\percorsitreno\Code\Views\_ViewStart.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b6911c41e0b186fa4e64a4d4c5fc8203146ae02f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views__ViewStart), @"mvc.1.0.view", @"/Views/_ViewStart.cshtml")]
namespace AspNetCore
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
#line 1 "C:\Users\zayya\OneDrive\Documents\GitHub\percorsitreno\Code\Views\_ViewImports.cshtml"
using PathApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\zayya\OneDrive\Documents\GitHub\percorsitreno\Code\Views\_ViewImports.cshtml"
using PathApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b6911c41e0b186fa4e64a4d4c5fc8203146ae02f", @"/Views/_ViewStart.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"026a68a55078dc97a6889550fe2a78bd9de3a046", @"/Views/_ViewImports.cshtml")]
    public class Views__ViewStart : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\zayya\OneDrive\Documents\GitHub\percorsitreno\Code\Views\_ViewStart.cshtml"
  
    var CurrentControllerName = this.ViewContext.RouteData.Values["controller"].ToString();
    string clayout = "~/Views/Shared/_SearchLayout.cshtml";
    switch (CurrentControllerName)
    {
        case "Path":
            clayout = "~/Views/Shared/_PathLayout.cshtml";
            break;
        case "Station":
            clayout = "~/Views/Shared/_StationLayout.cshtml";
            break;
        case "Search":
            clayout = "~/Views/Shared/_SearchLayout.cshtml";
            break;
        default:
            clayout = "~/Views/Shared/_SearchLayout.cshtml";
            break;
    }
    Layout = clayout;

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
