#pragma checksum "C:\Users\Admin\OneDrive\Desktop\Pronia_BackEnd\Pronia_BackEnd\Areas\ProniaAdmin\Views\Plant\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "41a40b945c400a0d10506c5e7bb9355fdf8231a0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_ProniaAdmin_Views_Plant_Detail), @"mvc.1.0.view", @"/Areas/ProniaAdmin/Views/Plant/Detail.cshtml")]
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
#line 1 "C:\Users\Admin\OneDrive\Desktop\Pronia_BackEnd\Pronia_BackEnd\Areas\ProniaAdmin\Views\_ViewImports.cshtml"
using Pronia_BackEnd.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"41a40b945c400a0d10506c5e7bb9355fdf8231a0", @"/Areas/ProniaAdmin/Views/Plant/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"764748dea96e8f946c98777b323ba0a17c1be75e", @"/Areas/ProniaAdmin/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_ProniaAdmin_Views_Plant_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Plant>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width: 150px; height:90px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Admin\OneDrive\Desktop\Pronia_BackEnd\Pronia_BackEnd\Areas\ProniaAdmin\Views\Plant\Detail.cshtml"
  
    ViewData["Title"] = "Detail";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div>\r\n    <div>\r\n        <h4>\r\n            Id\r\n        </h4>\r\n        <p>\r\n            ");
#nullable restore
#line 13 "C:\Users\Admin\OneDrive\Desktop\Pronia_BackEnd\Pronia_BackEnd\Areas\ProniaAdmin\Views\Plant\Detail.cshtml"
       Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </p>\r\n    </div>\r\n    <div>\r\n        <h4>\r\n            Name\r\n        </h4>\r\n        <p>\r\n            ");
#nullable restore
#line 21 "C:\Users\Admin\OneDrive\Desktop\Pronia_BackEnd\Pronia_BackEnd\Areas\ProniaAdmin\Views\Plant\Detail.cshtml"
       Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </p>\r\n    </div>\r\n    <div>\r\n        <h4>\r\n            Price\r\n        </h4>\r\n        <p>\r\n            ");
#nullable restore
#line 29 "C:\Users\Admin\OneDrive\Desktop\Pronia_BackEnd\Pronia_BackEnd\Areas\ProniaAdmin\Views\Plant\Detail.cshtml"
       Write(Model.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </p>\r\n    </div>\r\n    <div>\r\n        <h4>\r\n            Description\r\n        </h4>\r\n        <p>\r\n            ");
#nullable restore
#line 37 "C:\Users\Admin\OneDrive\Desktop\Pronia_BackEnd\Pronia_BackEnd\Areas\ProniaAdmin\Views\Plant\Detail.cshtml"
       Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </p>\r\n    </div>\r\n    <div>\r\n        <h4>\r\n            SkuCode\r\n        </h4>\r\n        <p>\r\n            ");
#nullable restore
#line 45 "C:\Users\Admin\OneDrive\Desktop\Pronia_BackEnd\Pronia_BackEnd\Areas\ProniaAdmin\Views\Plant\Detail.cshtml"
       Write(Model.SKUCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </p>\r\n    </div>\r\n     <div>\r\n        <h4>\r\n            Shipping\r\n        </h4>\r\n        <p>\r\n            ");
#nullable restore
#line 53 "C:\Users\Admin\OneDrive\Desktop\Pronia_BackEnd\Pronia_BackEnd\Areas\ProniaAdmin\Views\Plant\Detail.cshtml"
       Write(Model.Shipping);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </p>\r\n    </div>\r\n     <div>\r\n        <h4>\r\n            MainImage\r\n        </h4>\r\n        <p>\r\n         ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "41a40b945c400a0d10506c5e7bb9355fdf8231a06097", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 957, "~/assets/images/website-images/", 957, 31, true);
#nullable restore
#line 61 "C:\Users\Admin\OneDrive\Desktop\Pronia_BackEnd\Pronia_BackEnd\Areas\ProniaAdmin\Views\Plant\Detail.cshtml"
AddHtmlAttributeValue("", 988, Model.PlantImages.FirstOrDefault(p=>p.IsMain == true).ImagePath, 988, 64, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </p>\r\n    </div>\r\n     <div>\r\n        <h4>\r\n            AnotherImages\r\n        </h4>\r\n        <p>\r\n            <div class=\"d-flex\">\r\n");
#nullable restore
#line 70 "C:\Users\Admin\OneDrive\Desktop\Pronia_BackEnd\Pronia_BackEnd\Areas\ProniaAdmin\Views\Plant\Detail.cshtml"
             foreach (var item in Model.PlantImages.Where(a=>a.IsMain==false))
           {

#line default
#line hidden
#nullable disable
            WriteLiteral("               <div class=\"col-lg-2\">\n                   ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "41a40b945c400a0d10506c5e7bb9355fdf8231a08287", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1390, "~/assets/images/website-images/", 1390, 31, true);
#nullable restore
#line 73 "C:\Users\Admin\OneDrive\Desktop\Pronia_BackEnd\Pronia_BackEnd\Areas\ProniaAdmin\Views\Plant\Detail.cshtml"
AddHtmlAttributeValue("", 1421, item.ImagePath, 1421, 15, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n               </div>\n");
#nullable restore
#line 75 "C:\Users\Admin\OneDrive\Desktop\Pronia_BackEnd\Pronia_BackEnd\Areas\ProniaAdmin\Views\Plant\Detail.cshtml"
           }

#line default
#line hidden
#nullable disable
            WriteLiteral("           </div>\r\n        </p>\r\n    </div>\r\n</div>\r\n\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Plant> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
