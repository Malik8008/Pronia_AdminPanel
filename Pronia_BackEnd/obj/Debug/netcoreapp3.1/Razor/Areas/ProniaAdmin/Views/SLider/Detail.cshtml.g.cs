#pragma checksum "C:\Users\Admin\OneDrive\Desktop\Pronia_BackEnd\Pronia_BackEnd\Areas\ProniaAdmin\Views\SLider\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "979e31a9d49501e72bd7ab546a258fcf31543cf0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_ProniaAdmin_Views_SLider_Detail), @"mvc.1.0.view", @"/Areas/ProniaAdmin/Views/SLider/Detail.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"979e31a9d49501e72bd7ab546a258fcf31543cf0", @"/Areas/ProniaAdmin/Views/SLider/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"764748dea96e8f946c98777b323ba0a17c1be75e", @"/Areas/ProniaAdmin/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_ProniaAdmin_Views_SLider_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Slider>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Admin\OneDrive\Desktop\Pronia_BackEnd\Pronia_BackEnd\Areas\ProniaAdmin\Views\SLider\Detail.cshtml"
  
    ViewData["Title"] = "Detail";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div>\r\n    <div>\r\n        <h4>\r\n            Id\r\n        </h4>\r\n        <p>\r\n            ");
#nullable restore
#line 12 "C:\Users\Admin\OneDrive\Desktop\Pronia_BackEnd\Pronia_BackEnd\Areas\ProniaAdmin\Views\SLider\Detail.cshtml"
       Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </p>\r\n    </div>\r\n    <div>\r\n        <h4>\r\n            Title\r\n        </h4>\r\n        <p>\r\n            ");
#nullable restore
#line 20 "C:\Users\Admin\OneDrive\Desktop\Pronia_BackEnd\Pronia_BackEnd\Areas\ProniaAdmin\Views\SLider\Detail.cshtml"
       Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </p>\r\n    </div>\r\n    <div>\r\n        <h4>\r\n            Subtitle\r\n        </h4>\r\n        <p>\r\n            ");
#nullable restore
#line 28 "C:\Users\Admin\OneDrive\Desktop\Pronia_BackEnd\Pronia_BackEnd\Areas\ProniaAdmin\Views\SLider\Detail.cshtml"
       Write(Model.Subtitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </p>\r\n    </div>\r\n    <div>\r\n        <h4>\r\n            Discount\r\n        </h4>\r\n        <p>\r\n            ");
#nullable restore
#line 36 "C:\Users\Admin\OneDrive\Desktop\Pronia_BackEnd\Pronia_BackEnd\Areas\ProniaAdmin\Views\SLider\Detail.cshtml"
       Write(Model.Discount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </p>\r\n    </div>\r\n    <div>\r\n        <h4>\r\n            Image\r\n        </h4>\r\n        <p>\r\n            ");
#nullable restore
#line 44 "C:\Users\Admin\OneDrive\Desktop\Pronia_BackEnd\Pronia_BackEnd\Areas\ProniaAdmin\Views\SLider\Detail.cshtml"
       Write(Model.Image);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </p>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Slider> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
