#pragma checksum "C:\Users\Yunus\source\repos\FacebookApp\FacebookApp.Web\Views\Shared\CommentPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "24ca4837fe6477182c245f66104d9f9781824eab"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_CommentPartial), @"mvc.1.0.view", @"/Views/Shared/CommentPartial.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/CommentPartial.cshtml", typeof(AspNetCore.Views_Shared_CommentPartial))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24ca4837fe6477182c245f66104d9f9781824eab", @"/Views/Shared/CommentPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"48f6c7e00e9ba04bf799eef6fd2e534b3df3c273", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_CommentPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FacebookApp.Common.Dtos.CommentDto>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Yunus\source\repos\FacebookApp\FacebookApp.Web\Views\Shared\CommentPartial.cshtml"
  
    Layout = null;

#line default
#line hidden
            BeginContext(70, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 6 "C:\Users\Yunus\source\repos\FacebookApp\FacebookApp.Web\Views\Shared\CommentPartial.cshtml"
 foreach (var item in Model.commentList)
{

#line default
#line hidden
            BeginContext(117, 136, true);
            WriteLiteral("            <li class=\"media\">\r\n                <a class=\"pull-left\" href=\"javascript:;\">\r\n                    <img class=\"todo-userpic\"");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 253, "\"", 286, 2);
            WriteAttributeValue("", 259, "/", 259, 1, true);
#line 10 "C:\Users\Yunus\source\repos\FacebookApp\FacebookApp.Web\Views\Shared\CommentPartial.cshtml"
WriteAttributeValue("", 260, item.CommentUserDto.Photo, 260, 26, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(287, 220, true);
            WriteLiteral(" width=\"27px\" height=\"27px\">\r\n                </a>\r\n                <div class=\"media-body todo-comment\">\r\n\r\n                    <p class=\"todo-comment-head\">\r\n                        <span class=\"todo-comment-username\">");
            EndContext();
            BeginContext(508, 24, false);
#line 15 "C:\Users\Yunus\source\repos\FacebookApp\FacebookApp.Web\Views\Shared\CommentPartial.cshtml"
                                                       Write(item.CommentUserDto.Name);

#line default
#line hidden
            EndContext();
            BeginContext(532, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(534, 28, false);
#line 15 "C:\Users\Yunus\source\repos\FacebookApp\FacebookApp.Web\Views\Shared\CommentPartial.cshtml"
                                                                                 Write(item.CommentUserDto.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(562, 140, true);
            WriteLiteral("</span> &nbsp;\r\n                        \r\n                    </p>\r\n                    <p class=\"todo-text-color\">\r\n                       ");
            EndContext();
            BeginContext(703, 16, false);
#line 19 "C:\Users\Yunus\source\repos\FacebookApp\FacebookApp.Web\Views\Shared\CommentPartial.cshtml"
                  Write(item.CommentText);

#line default
#line hidden
            EndContext();
            BeginContext(719, 101, true);
            WriteLiteral("\r\n                        <br>\r\n                    </p>\r\n                </div>\r\n            </li>\r\n");
            EndContext();
#line 24 "C:\Users\Yunus\source\repos\FacebookApp\FacebookApp.Web\Views\Shared\CommentPartial.cshtml"
       
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FacebookApp.Common.Dtos.CommentDto> Html { get; private set; }
    }
}
#pragma warning restore 1591