#pragma checksum "C:\MuSeV6\MuSe.Web\Views\Monitors\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3d0f1cfdbf8ee4e69def54213f4b84bd09c0df8c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Monitors_Index), @"mvc.1.0.view", @"/Views/Monitors/Index.cshtml")]
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
#line 1 "C:\MuSeV6\MuSe.Web\Views\_ViewImports.cshtml"
using MuSe.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\MuSeV6\MuSe.Web\Views\_ViewImports.cshtml"
using MuSe.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3d0f1cfdbf8ee4e69def54213f4b84bd09c0df8c", @"/Views/Monitors/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2d17f904db8e95d3fa5efe9de5d28d68b22d0be8", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Monitors_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MuSe.Web.Data.Entities.Monitor>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\MuSeV6\MuSe.Web\Views\Monitors\Index.cshtml"
  
    ViewData["Title"] = "Monitores";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Monitores</h1>\r\n\r\n<table class=\"table table-dark\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 13 "C:\MuSeV6\MuSe.Web\Views\Monitors\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.User.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "C:\MuSeV6\MuSe.Web\Views\Monitors\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.User.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "C:\MuSeV6\MuSe.Web\Views\Monitors\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.User.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "C:\MuSeV6\MuSe.Web\Views\Monitors\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.User.BirhtDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n            <th>\r\n                    ");
#nullable restore
#line 26 "C:\MuSeV6\MuSe.Web\Views\Monitors\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.ImageUrl));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 32 "C:\MuSeV6\MuSe.Web\Views\Monitors\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 36 "C:\MuSeV6\MuSe.Web\Views\Monitors\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.User.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 39 "C:\MuSeV6\MuSe.Web\Views\Monitors\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.User.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 42 "C:\MuSeV6\MuSe.Web\Views\Monitors\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.User.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <th>\r\n                    ");
#nullable restore
#line 45 "C:\MuSeV6\MuSe.Web\Views\Monitors\Index.cshtml"
               Write(Html.DisplayFor(model => item.User.BirhtDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <td>\r\n");
#nullable restore
#line 48 "C:\MuSeV6\MuSe.Web\Views\Monitors\Index.cshtml"
                     if (!string.IsNullOrEmpty(item.ImageUrl))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <img");
            BeginWriteAttribute("src", " src=\"", 1457, "\"", 1490, 1);
#nullable restore
#line 50 "C:\MuSeV6\MuSe.Web\Views\Monitors\Index.cshtml"
WriteAttributeValue("", 1463, Url.Content(item.ImageUrl), 1463, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width:100px;height:80px\" />\r\n");
#nullable restore
#line 51 "C:\MuSeV6\MuSe.Web\Views\Monitors\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n            </tr>\r\n");
#nullable restore
#line 54 "C:\MuSeV6\MuSe.Web\Views\Monitors\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MuSe.Web.Data.Entities.Monitor>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
