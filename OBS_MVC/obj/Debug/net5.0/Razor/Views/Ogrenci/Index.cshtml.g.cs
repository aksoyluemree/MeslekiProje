#pragma checksum "C:\Users\TR\Desktop\OBS_MVC\Views\Ogrenci\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "071a34170f43784723d3cd79e2f5c1e283c86cc8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Ogrenci_Index), @"mvc.1.0.view", @"/Views/Ogrenci/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"071a34170f43784723d3cd79e2f5c1e283c86cc8", @"/Views/Ogrenci/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6e1f1474d3ca06dcf6e06394b3c256b28e7c7ca9", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Ogrenci_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OBS_MVC.Models.ObsOgrenci>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"container bootstrap snippets bootdey\">\n    <div class=\"panel-body inf-content\">\n        <div class=\"row\">\n            <div class=\"col-md-3\">\n                <img");
            BeginWriteAttribute("alt", " alt=\"", 206, "\"", 212, 0);
            EndWriteAttribute();
            WriteLiteral(" style=\"width:500px;\"");
            BeginWriteAttribute("title", " title=\"", 234, "\"", 242, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"img-circle img-thumbnail isTooltip\"");
            BeginWriteAttribute("src", "\n                     src=\"", 286, "\"", 334, 1);
#nullable restore
#line 7 "C:\Users\TR\Desktop\OBS_MVC\Views\Ogrenci\Index.cshtml"
WriteAttributeValue("", 313, ViewBag.ImageDataUrl, 313, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" data-original-title=""Usuario"">
            </div>
            <div class=""col-md-9"">
                <strong>Öğrenci Bilgileri</strong><br>
                <div class=""table-responsive"">
                    <table class=""table table-user-information"">
                        <tbody>
                            <tr>
                                <td>
                                    <strong>
                                        <span class=""fa fa-asterisk text-primary""></span>
                                        Öğrenci Numarası
                                    </strong>
                                </td>
                                <td class=""text-primary"">
                                    ");
#nullable restore
#line 22 "C:\Users\TR\Desktop\OBS_MVC\Views\Ogrenci\Index.cshtml"
                               Write(Model.OgrenciId);

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
                                        Adı
                                    </strong>
                                </td>
                                <td class=""text-primary"">
                                    ");
#nullable restore
#line 33 "C:\Users\TR\Desktop\OBS_MVC\Views\Ogrenci\Index.cshtml"
                               Write(Model.Ad);

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
                                        Soyadı
                                    </strong>
                                </td>
                                <td class=""text-primary"">
                                    ");
#nullable restore
#line 44 "C:\Users\TR\Desktop\OBS_MVC\Views\Ogrenci\Index.cshtml"
                               Write(Model.Soyad);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <strong>
                                        <span class=""fa fa-bookmark text-primary""></span>
                                        Tc Kimlik Numarası
                                    </strong>
                                </td>
                                <td class=""text-primary"">
                                    ");
#nullable restore
#line 56 "C:\Users\TR\Desktop\OBS_MVC\Views\Ogrenci\Index.cshtml"
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
                                        <span class=""fa fa-eye text-primary""></span>
                                        Bölüm
                                    </strong>
                                </td>
                                <td class=""text-primary"">
                                    ");
#nullable restore
#line 68 "C:\Users\TR\Desktop\OBS_MVC\Views\Ogrenci\Index.cshtml"
                               Write(Model.Bolum.Ad);

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
                                    ");
#nullable restore
#line 79 "C:\Users\TR\Desktop\OBS_MVC\Views\Ogrenci\Index.cshtml"
                               Write(Model.Eposta);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <strong>
                                        <span class=""fa fa-calendar text-primary""></span>
                                        Doğum Tarihi
                                    </strong>
                                </td>
                                <td class=""text-primary"">
                                    ");
#nullable restore
#line 90 "C:\Users\TR\Desktop\OBS_MVC\Views\Ogrenci\Index.cshtml"
                               Write(Model.DogumTarih);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <strong>
                                        <span class=""fa fa-calendar text-primary""></span>
                                        Giriş Tairihi
                                    </strong>
                                </td>
                                <td class=""text-primary"">
                                    ");
#nullable restore
#line 101 "C:\Users\TR\Desktop\OBS_MVC\Views\Ogrenci\Index.cshtml"
                               Write(Model.GirisTarih);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </td>\n                            </tr>\n                        </tbody>\n                    </table>\n                </div>\n            </div>\n        </div>\n    </div>\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OBS_MVC.Models.ObsOgrenci> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
