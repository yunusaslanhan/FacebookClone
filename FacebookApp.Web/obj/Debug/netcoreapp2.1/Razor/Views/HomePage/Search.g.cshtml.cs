#pragma checksum "C:\Users\Yunus\source\repos\FacebookApp\FacebookApp.Web\Views\HomePage\Search.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fcded2f844fb3a667b67bcc25c164277a4ffc4bd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_HomePage_Search), @"mvc.1.0.view", @"/Views/HomePage/Search.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/HomePage/Search.cshtml", typeof(AspNetCore.Views_HomePage_Search))]
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
#line 1 "C:\Users\Yunus\source\repos\FacebookApp\FacebookApp.Web\Views\_ViewImports.cshtml"
using FacebookApp.Web;

#line default
#line hidden
#line 2 "C:\Users\Yunus\source\repos\FacebookApp\FacebookApp.Web\Views\_ViewImports.cshtml"
using FacebookApp.Web.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fcded2f844fb3a667b67bcc25c164277a4ffc4bd", @"/Views/HomePage/Search.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"48f6c7e00e9ba04bf799eef6fd2e534b3df3c273", @"/Views/_ViewImports.cshtml")]
    public class Views_HomePage_Search : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<FacebookApp.Common.Dtos.UserDto>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Yunus\source\repos\FacebookApp\FacebookApp.Web\Views\HomePage\Search.cshtml"
  
    ViewData["Title"] = "Search";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(135, 789, true);
            WriteLiteral(@"
<br />
<br />
<br />
<br />

<div class=""container"">

    <div class=""col-lg-3"" style=""margin-top:50px;"">

    </div>
    <div class=""col-lg-6"" style=""margin-top:50px;"">


        <div class=""portlet box blue"">
            <div class=""portlet-title"">
                <div class=""caption"">
                    <i class=""fa fa-comments""></i><font style=""vertical-align: inherit;""><font style=""vertical-align: inherit;"">Kişiler </font></font>
                </div>
            </div>
            <div class=""portlet-body"">
                <div class=""table-scrollable"">
                    <table class=""table table-bordered table-hover"">
                        <thead>
                          
                        </thead>
                        <tbody>
");
            EndContext();
#line 33 "C:\Users\Yunus\source\repos\FacebookApp\FacebookApp.Web\Views\HomePage\Search.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
            BeginContext(1013, 96, true);
            WriteLiteral("                                <tr class=\"warning\">\r\n                                    <td><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1109, "\"", 1140, 2);
            WriteAttributeValue("", 1116, "/Profile?Id=", 1116, 12, true);
#line 36 "C:\Users\Yunus\source\repos\FacebookApp\FacebookApp.Web\Views\HomePage\Search.cshtml"
WriteAttributeValue("", 1128, item.UserId, 1128, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1141, 5, true);
            WriteLiteral("><img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 1146, "\"", 1164, 2);
            WriteAttributeValue("", 1152, "/", 1152, 1, true);
#line 36 "C:\Users\Yunus\source\repos\FacebookApp\FacebookApp.Web\Views\HomePage\Search.cshtml"
WriteAttributeValue("", 1153, item.Photo, 1153, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1165, 86, true);
            WriteLiteral(" style=\"width:25px;height:25px\"/></a></td>\r\n                                    <td><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1251, "\"", 1282, 2);
            WriteAttributeValue("", 1258, "/Profile?Id=", 1258, 12, true);
#line 37 "C:\Users\Yunus\source\repos\FacebookApp\FacebookApp.Web\Views\HomePage\Search.cshtml"
WriteAttributeValue("", 1270, item.UserId, 1270, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1283, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1285, 9, false);
#line 37 "C:\Users\Yunus\source\repos\FacebookApp\FacebookApp.Web\Views\HomePage\Search.cshtml"
                                                                      Write(item.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1294, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(1296, 13, false);
#line 37 "C:\Users\Yunus\source\repos\FacebookApp\FacebookApp.Web\Views\HomePage\Search.cshtml"
                                                                                 Write(item.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(1309, 50, true);
            WriteLiteral("</a></td>\r\n                                </tr>\r\n");
            EndContext();
#line 39 "C:\Users\Yunus\source\repos\FacebookApp\FacebookApp.Web\Views\HomePage\Search.cshtml"
                            }

#line default
#line hidden
            BeginContext(1390, 251, true);
            WriteLiteral("                            </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n       \r\n\r\n\r\n    </div>\r\n\r\n    <div class=\"col-lg-3\" style=\"margin-top:50px;\">\r\n\r\n    </div>\r\n</div><!-- centerl meta -->\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<FacebookApp.Common.Dtos.UserDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591
