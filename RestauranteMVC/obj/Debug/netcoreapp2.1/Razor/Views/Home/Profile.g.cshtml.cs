#pragma checksum "C:\Users\SIQUEIROS\source\repos\CURSO\RestauranteMVC\Views\Home\Profile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "aec342714293e026ea3d177f5df4c0befc3d67f2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Profile), @"mvc.1.0.view", @"/Views/Home/Profile.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Profile.cshtml", typeof(AspNetCore.Views_Home_Profile))]
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
#line 1 "C:\Users\SIQUEIROS\source\repos\CURSO\RestauranteMVC\Views\_ViewImports.cshtml"
using RestauranteMVC;

#line default
#line hidden
#line 2 "C:\Users\SIQUEIROS\source\repos\CURSO\RestauranteMVC\Views\_ViewImports.cshtml"
using RestauranteMVC.Models;

#line default
#line hidden
#line 3 "C:\Users\SIQUEIROS\source\repos\CURSO\RestauranteMVC\Views\_ViewImports.cshtml"
using Restaurante.Core.Entities;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aec342714293e026ea3d177f5df4c0befc3d67f2", @"/Views/Home/Profile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3021e54aff9ad800a8f73fda0d422276f9de9a1f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Profile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Restaurante>
    {
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(20, 278, true);
            WriteLiteral(@"<h1>Restaurante Profile</h1>
<div class=""container"" style=""padding:5px;border:1px white;border-radius: 5px;box-shadow: 0 2px 4px 0 rgba(0,0,0,0.16),0 2px 10px 0 rgba(0,0,0,0.12)"">
    <div class=""row"">
        <div class=""col-sm-4"">
            <img height=""200"" width=""200""");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 298, "\"", 315, 1);
#line 6 "C:\Users\SIQUEIROS\source\repos\CURSO\RestauranteMVC\Views\Home\Profile.cshtml"
WriteAttributeValue("", 304, Model.Logo, 304, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(316, 180, true);
            WriteLiteral(" />\r\n        </div>\r\n        <div class=\"col-sm-8\">\r\n            <p>Columna 2</p>\r\n        </div>\r\n    </div>\r\n    <div class=\"row\">\r\n        <div class=\"col-sm-4\">\r\n            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 496, "\"", 519, 1);
#line 14 "C:\Users\SIQUEIROS\source\repos\CURSO\RestauranteMVC\Views\Home\Profile.cshtml"
WriteAttributeValue("", 503, Model.PaginaWeb, 503, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(520, 124, true);
            WriteLiteral(">Restaurante Web site</a>\r\n\r\n        </div>\r\n    </div>\r\n    <div class=\"row\">\r\n        <div class=\"col-sm-4\">\r\n            ");
            EndContext();
            BeginContext(644, 35, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7db5534936dd4e66b2fd3ae335362e05", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#line 20 "C:\Users\SIQUEIROS\source\repos\CURSO\RestauranteMVC\Views\Home\Profile.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Domicilio);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(679, 100, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div class=\"row\">\r\n        <div class=\"col-sm-4\">\r\n            <p>");
            EndContext();
            BeginContext(780, 15, false);
#line 25 "C:\Users\SIQUEIROS\source\repos\CURSO\RestauranteMVC\Views\Home\Profile.cshtml"
          Write(Model.Domicilio);

#line default
#line hidden
            EndContext();
            BeginContext(795, 101, true);
            WriteLiteral("</p>\r\n        </div>\r\n    </div>\r\n    <div class=\"row\">\r\n        <div class=\"col-sm-4\">\r\n            ");
            EndContext();
            BeginContext(896, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9ce59dfcfd914418bd9cba36ecbcfe7e", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#line 30 "C:\Users\SIQUEIROS\source\repos\CURSO\RestauranteMVC\Views\Home\Profile.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.HoraDeCierre);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(934, 100, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div class=\"row\">\r\n        <div class=\"col-sm-4\">\r\n            <p>");
            EndContext();
            BeginContext(1035, 18, false);
#line 35 "C:\Users\SIQUEIROS\source\repos\CURSO\RestauranteMVC\Views\Home\Profile.cshtml"
          Write(Model.HoraDeCierre);

#line default
#line hidden
            EndContext();
            BeginContext(1053, 168, true);
            WriteLiteral("</p>\r\n        </div>\r\n    </div>\r\n    <div class=\"row\">\r\n        <label></label>\r\n    </div>\r\n    <div class=\"row\">\r\n        <p>\r\n\r\n        </p>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Restaurante> Html { get; private set; }
    }
}
#pragma warning restore 1591
