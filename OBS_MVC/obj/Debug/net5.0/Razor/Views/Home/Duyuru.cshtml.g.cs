#pragma checksum "C:\Users\TR\Desktop\OBS_MVC\Views\Home\Duyuru.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d2796816cac6ccd24d16f7dd4e66c0f66ce4b6de"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Duyuru), @"mvc.1.0.view", @"/Views/Home/Duyuru.cshtml")]
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
#line 1 "C:\Users\TR\Desktop\OBS_MVC\Views\_ViewImports.cshtml"
using OBS_MVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\TR\Desktop\OBS_MVC\Views\_ViewImports.cshtml"
using OBS_MVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d2796816cac6ccd24d16f7dd4e66c0f66ce4b6de", @"/Views/Home/Duyuru.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6e1f1474d3ca06dcf6e06394b3c256b28e7c7ca9", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Duyuru : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<OBS_MVC.Models.ObsDuyuru>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"text-center\" style=\"margin-top: 10%;\">\n    <h2>Duyurular</h2>\n</div>\n\n\n");
#nullable restore
#line 7 "C:\Users\TR\Desktop\OBS_MVC\Views\Home\Duyuru.cshtml"
 foreach (var item in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div>\n        <h1>\n            ");
#nullable restore
#line 11 "C:\Users\TR\Desktop\OBS_MVC\Views\Home\Duyuru.cshtml"
       Write(Html.DisplayFor(modelItem => item.BolumId));

#line default
#line hidden
#nullable disable
            WriteLiteral(" -  ");
#nullable restore
#line 11 "C:\Users\TR\Desktop\OBS_MVC\Views\Home\Duyuru.cshtml"
                                                      Write(Html.DisplayFor(modelItem => item.DuyuruId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </h1>\n        <h4> ");
#nullable restore
#line 13 "C:\Users\TR\Desktop\OBS_MVC\Views\Home\Duyuru.cshtml"
        Write(Html.DisplayFor(modelItem => item.Duyuru));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\n\n    </div>\n");
#nullable restore
#line 16 "C:\Users\TR\Desktop\OBS_MVC\Views\Home\Duyuru.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<OBS_MVC.Models.ObsDuyuru>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
