#pragma checksum "C:\Users\zayya\OneDrive\Documents\GitHub\percorsitreno\Code\Views\Search\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c6f4d5184e697fdc18e9711e54600451172bbab6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Search_Index), @"mvc.1.0.razor-page", @"/Views/Search/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c6f4d5184e697fdc18e9711e54600451172bbab6", @"/Views/Search/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"026a68a55078dc97a6889550fe2a78bd9de3a046", @"/Views/_ViewImports.cshtml")]
    public class Views_Search_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"header-main\">\r\n    <h2>Search In Paths</h2>\r\n</div>\r\n\r\n<div class=\"body\">\r\n");
#nullable restore
#line 11 "C:\Users\zayya\OneDrive\Documents\GitHub\percorsitreno\Code\Views\Search\Index.cshtml"
     using (Html.BeginForm("SearchPath", "Search", FormMethod.Post, new { @id = "searchPath" }))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div class="" w-100 d-flex"">
            <div class=""w-50"">
                <div name=""drpOriginalStation"" class=""margin-bottom"">
                    <label class=""stations"" for=""drpOriginalStation"">List Of Original Stations:</label>
                    <div>
                        ");
#nullable restore
#line 18 "C:\Users\zayya\OneDrive\Documents\GitHub\percorsitreno\Code\Views\Search\Index.cshtml"
                   Write(Html.DropDownList("drpOriginalStation", (IEnumerable<SelectListItem>)ViewBag.originalStationsList, new { @class = "dropdown-stations", @id = "drpOriginalStation", onChange = "onSelectedIndexChanged()" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 21 "C:\Users\zayya\OneDrive\Documents\GitHub\percorsitreno\Code\Views\Search\Index.cshtml"
                  
                    if (ViewBag.PathList != null)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div name=\"drpVia1Station\" class=\"margin-bottom\">\r\n                            <label class=\"stations\" for=\"drpVia1Station\">List Of Via1 Stations:</label>\r\n                            <div>\r\n                                ");
#nullable restore
#line 27 "C:\Users\zayya\OneDrive\Documents\GitHub\percorsitreno\Code\Views\Search\Index.cshtml"
                           Write(Html.DropDownList("drpVia1Station", (IEnumerable<SelectListItem>)ViewBag.Via1StationsList, new { @class = "dropdown-stations", onChange = "onSelectedIndexChanged()" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n");
#nullable restore
#line 30 "C:\Users\zayya\OneDrive\Documents\GitHub\percorsitreno\Code\Views\Search\Index.cshtml"
                    }
                

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </div>
            <div class=""w-50"">
                <div name=""drpDestinationStation"" class=""margin-bottom"">
                    <label class=""stations"" for=""drpDestinationStation"">List Of Destination Stations:</label>
                    <div>
                        ");
#nullable restore
#line 38 "C:\Users\zayya\OneDrive\Documents\GitHub\percorsitreno\Code\Views\Search\Index.cshtml"
                   Write(Html.DropDownList("drpDestinationStation", (IEnumerable<SelectListItem>)ViewBag.destinationStationsList, new { @class = "dropdown-stations", @id = "drpDestinationStation", onChange = "onSelectedIndexChanged()" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 41 "C:\Users\zayya\OneDrive\Documents\GitHub\percorsitreno\Code\Views\Search\Index.cshtml"
                  
                    if (ViewBag.PathList != null)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div name=\"drpVia2Station\" class=\"margin-bottom\">\r\n                            <label class=\"stations\" for=\"drpVia2Station\">List Of Via2 Stations:</label>\r\n                            <div>\r\n                                ");
#nullable restore
#line 47 "C:\Users\zayya\OneDrive\Documents\GitHub\percorsitreno\Code\Views\Search\Index.cshtml"
                           Write(Html.DropDownList("drpVia2Station", (IEnumerable<SelectListItem>)ViewBag.Via2StationsList, new { @class = "dropdown-stations", onChange = "onSelectedIndexChanged()" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n");
#nullable restore
#line 50 "C:\Users\zayya\OneDrive\Documents\GitHub\percorsitreno\Code\Views\Search\Index.cshtml"
                    }
                

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n        <div class=\"validationsummary\">\r\n            ");
#nullable restore
#line 55 "C:\Users\zayya\OneDrive\Documents\GitHub\percorsitreno\Code\Views\Search\Index.cshtml"
       Write(Html.ValidationSummary());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n");
#nullable restore
#line 57 "C:\Users\zayya\OneDrive\Documents\GitHub\percorsitreno\Code\Views\Search\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 60 "C:\Users\zayya\OneDrive\Documents\GitHub\percorsitreno\Code\Views\Search\Index.cshtml"
      
        if (ViewBag.PathList != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div class=""header-table"">
                List Of Paths
            </div>
            <table id=""table-records"" class=""tbl-records"">
                <thead>
                    <tr class=""tr-title"">
                        <th>
                            <b>");
#nullable restore
#line 70 "C:\Users\zayya\OneDrive\Documents\GitHub\percorsitreno\Code\Views\Search\Index.cshtml"
                          Write(Html.DisplayNameFor(model => model.IdPercorso));

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>\r\n                        </th>\r\n                        <th>\r\n                            <b>");
#nullable restore
#line 73 "C:\Users\zayya\OneDrive\Documents\GitHub\percorsitreno\Code\Views\Search\Index.cshtml"
                          Write(Html.DisplayNameFor(model => model.StazioneOrigineName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>\r\n                        </th>\r\n                        <th>\r\n                            <b>");
#nullable restore
#line 76 "C:\Users\zayya\OneDrive\Documents\GitHub\percorsitreno\Code\Views\Search\Index.cshtml"
                          Write(Html.DisplayNameFor(model => model.StazioneDestinazioneName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>\r\n                        </th>\r\n                        <th>\r\n                            <b>");
#nullable restore
#line 79 "C:\Users\zayya\OneDrive\Documents\GitHub\percorsitreno\Code\Views\Search\Index.cshtml"
                          Write(Html.DisplayNameFor(model => model.Via1Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>\r\n                        </th>\r\n                        <th>\r\n                            <b>");
#nullable restore
#line 82 "C:\Users\zayya\OneDrive\Documents\GitHub\percorsitreno\Code\Views\Search\Index.cshtml"
                          Write(Html.DisplayNameFor(model => model.Via2Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>\r\n                        </th>\r\n                        <th>\r\n                            <b>");
#nullable restore
#line 85 "C:\Users\zayya\OneDrive\Documents\GitHub\percorsitreno\Code\Views\Search\Index.cshtml"
                          Write(Html.DisplayNameFor(model => model.Distanza));

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>\r\n                        </th>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n");
#nullable restore
#line 90 "C:\Users\zayya\OneDrive\Documents\GitHub\percorsitreno\Code\Views\Search\Index.cshtml"
                     foreach (NewPercorsiModel newPercorsiObj in ViewBag.PathList)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr class=\"tr-records\">\r\n                            <th>\r\n                                ");
#nullable restore
#line 94 "C:\Users\zayya\OneDrive\Documents\GitHub\percorsitreno\Code\Views\Search\Index.cshtml"
                           Write(Html.Label(newPercorsiObj.IdPercorso.ToString()));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 97 "C:\Users\zayya\OneDrive\Documents\GitHub\percorsitreno\Code\Views\Search\Index.cshtml"
                           Write(Html.Label(newPercorsiObj.StazioneOrigineName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 100 "C:\Users\zayya\OneDrive\Documents\GitHub\percorsitreno\Code\Views\Search\Index.cshtml"
                           Write(Html.Label(newPercorsiObj.StazioneDestinazioneName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 103 "C:\Users\zayya\OneDrive\Documents\GitHub\percorsitreno\Code\Views\Search\Index.cshtml"
                           Write(Html.Label(newPercorsiObj.Via1Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 106 "C:\Users\zayya\OneDrive\Documents\GitHub\percorsitreno\Code\Views\Search\Index.cshtml"
                           Write(Html.Label(newPercorsiObj.Via2Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 109 "C:\Users\zayya\OneDrive\Documents\GitHub\percorsitreno\Code\Views\Search\Index.cshtml"
                           Write(Html.Label(newPercorsiObj.Distanza.ToString()));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                        </tr>\r\n");
#nullable restore
#line 112 "C:\Users\zayya\OneDrive\Documents\GitHub\percorsitreno\Code\Views\Search\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n");
#nullable restore
#line 115 "C:\Users\zayya\OneDrive\Documents\GitHub\percorsitreno\Code\Views\Search\Index.cshtml"
        }
    

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c6f4d5184e697fdc18e9711e54600451172bbab614309", async() => {
                WriteLiteral("\r\n    <script type=\"text/javascript\">\r\n\r\n        function onSelectedIndexChanged() {\r\n            document.getElementById(\'searchPath\').submit();\r\n        }\r\n\r\n    </script>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PathApp.Models.NewPercorsiModel>> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IEnumerable<PathApp.Models.NewPercorsiModel>> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IEnumerable<PathApp.Models.NewPercorsiModel>>)PageContext?.ViewData;
        public IEnumerable<PathApp.Models.NewPercorsiModel> Model => ViewData.Model;
    }
}
#pragma warning restore 1591
