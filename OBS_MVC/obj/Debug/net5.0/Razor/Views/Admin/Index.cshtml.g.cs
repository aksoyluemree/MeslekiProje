#pragma checksum "C:\Users\TR\Desktop\OBS_MVC\Views\Admin\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a95b974bdaab8be347f38fd646e1b14ae681d0b7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Index), @"mvc.1.0.view", @"/Views/Admin/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a95b974bdaab8be347f38fd646e1b14ae681d0b7", @"/Views/Admin/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6e1f1474d3ca06dcf6e06394b3c256b28e7c7ca9", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Admin_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OBS_MVC.Models.ObsKullanici>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"container bootstrap snippets bootdey\">\n    <div class=\"panel-body inf-content\">\n        <div class=\"row\">\n");
            WriteLiteral("            <div class=\"col-md-3\">\n                <img");
            BeginWriteAttribute("alt", " alt=\"", 2588, "\"", 2594, 0);
            EndWriteAttribute();
            WriteLiteral(" style=\"width:500px;\"");
            BeginWriteAttribute("title", " title=\"", 2616, "\"", 2624, 0);
            EndWriteAttribute();
            WriteLiteral(@" class=""img-circle img-thumbnail isTooltip""
                     src=""https://pickaface.net/gallery/avatar/unr_admin_171016_2225_zewhi.png""
                     data-original-title=""Usuario"">
            </div>
            <div class=""col-md-9"">
                <strong>Yönetici Bilgileri</strong><br>
                <div class=""table-responsive"">
                    <table class=""table table-user-information"">
                        <tbody>
                            <tr>
                                <td>
                                    <strong>
                                        <span class=""fa fa-asterisk text-primary""></span>
                                        TC Kimlik Numarası
                                    </strong>
                                </td>
                                <td class=""text-primary"">
                                    ");
#nullable restore
#line 54 "C:\Users\TR\Desktop\OBS_MVC\Views\Admin\Index.cshtml"
                               Write(Model.KimlikNo);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <strong>
                                        <span class=""fa fa-user  text-primary""></span>
                                        Kullanıcı Id
                                    </strong>
                                </td>
                                <td class=""text-primary"">
                                    ");
#nullable restore
#line 65 "C:\Users\TR\Desktop\OBS_MVC\Views\Admin\Index.cshtml"
                               Write(Model.KullaniciId);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <strong>
                                        <span class=""fa fa-cloud text-primary""></span>
                                        KullanıcıAdı
                                    </strong>
                                </td>
                                <td class=""text-primary"">
                                    ");
#nullable restore
#line 76 "C:\Users\TR\Desktop\OBS_MVC\Views\Admin\Index.cshtml"
                               Write(Model.KullaniciAdi);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <strong>
                                        <span class=""fa fa-eye text-primary""></span>
                                        Role
                                    </strong>
                                </td>
                                <td class=""text-primary"">
                                    ");
#nullable restore
#line 87 "C:\Users\TR\Desktop\OBS_MVC\Views\Admin\Index.cshtml"
                               Write(Model.Turu);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <strong>
                                        <span class=""fa fa-envelope text-primary""></span>
                                        E-Posta
                                    </strong>
                                </td>
                                <td class=""text-primary"">
                                    admin@admin.com
                                </td>
                            </tr>

                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OBS_MVC.Models.ObsKullanici> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
