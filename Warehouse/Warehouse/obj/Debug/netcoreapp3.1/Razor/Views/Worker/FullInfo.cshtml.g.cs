#pragma checksum "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Worker\FullInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0972269c83793ee02045843b7dfb980db157eac9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Worker_FullInfo), @"mvc.1.0.view", @"/Views/Worker/FullInfo.cshtml")]
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
#line 1 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\_ViewImports.cshtml"
using Warehouse;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\_ViewImports.cshtml"
using Warehouse.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0972269c83793ee02045843b7dfb980db157eac9", @"/Views/Worker/FullInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc02168007f24d38038bd969e052ce5b5b2dcc80", @"/Views/_ViewImports.cshtml")]
    public class Views_Worker_FullInfo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Warehouse.Models.Worker>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Worker", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Worker\FullInfo.cshtml"
  
    ViewData["Title"] = "Полная информация о сотруднике";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<style type=""text/css"">
    TABLE {
        border: 1px solid black;
    }

    TR {
        padding: 3px; 
        border: 1px solid black; 
    }
</style>
<div class=""text-center"">
    <h1 class=""col-md-12"">Полная информация о сотруднике №");
#nullable restore
#line 18 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Worker\FullInfo.cshtml"
                                                     Write(Model.Number);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h1>
</div>
<div class=""text-left"">
    <table style=""width:100%;"" class=""col-md-12"">
        <tr align=""center"">
            <td>ФИО</td>
            <td>Номер телефона</td>
            <td>Дата рождения</td>
            <td>Опыт работы</td>
            <td>Зарплата</td>
            <td>Табельный номер</td>
            <td>Должность</td>
            <td>Серия паспорта</td>
            <td>Номер паспорта</td>
            <td>Кем выдан паспорт</td>
            <td>Когда выдан паспорт</td>
            <td></td>
            <td></td>
        </tr>
        <tr align=""center"">
            <td>");
#nullable restore
#line 38 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Worker\FullInfo.cshtml"
           Write(Model.FIO);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 39 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Worker\FullInfo.cshtml"
           Write(Model.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 40 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Worker\FullInfo.cshtml"
           Write(Model.Birthday.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 41 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Worker\FullInfo.cshtml"
           Write(Model.Experience);

#line default
#line hidden
#nullable disable
            WriteLiteral(" год/лет</td>\r\n            <td>");
#nullable restore
#line 42 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Worker\FullInfo.cshtml"
           Write(Model.Salary);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 43 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Worker\FullInfo.cshtml"
           Write(Model.Number);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 44 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Worker\FullInfo.cshtml"
           Write(Model.Position.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 45 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Worker\FullInfo.cshtml"
           Write(Model.Passport.Series);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 46 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Worker\FullInfo.cshtml"
           Write(Model.Passport.Number);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 47 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Worker\FullInfo.cshtml"
           Write(Model.Passport.IssuedAt);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 48 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Worker\FullInfo.cshtml"
           Write(Model.Passport.IssuedWas.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 49 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Worker\FullInfo.cshtml"
           Write(Html.ActionLink("Изменить", "Edit", "Worker", new { workerId = Model.ID }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0972269c83793ee02045843b7dfb980db157eac98851", async() => {
                WriteLiteral("\r\n                    <input type=\"hidden\"");
                BeginWriteAttribute("value", " value=\"", 1691, "\"", 1708, 1);
#nullable restore
#line 52 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Worker\FullInfo.cshtml"
WriteAttributeValue("", 1699, Model.ID, 1699, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"id\" />\r\n                    <input type=\"submit\" value=\"Удалить\"");
                BeginWriteAttribute("onclick", " onclick=\"", 1780, "\"", 1858, 9);
                WriteAttributeValue("", 1790, "return", 1790, 6, true);
                WriteAttributeValue(" ", 1796, "confirm(\'Вы", 1797, 12, true);
                WriteAttributeValue(" ", 1808, "точно", 1809, 6, true);
                WriteAttributeValue(" ", 1814, "хотите", 1815, 7, true);
                WriteAttributeValue(" ", 1821, "удалить", 1822, 8, true);
                WriteAttributeValue(" ", 1829, "работника", 1830, 10, true);
                WriteAttributeValue(" ", 1839, "№", 1840, 2, true);
#nullable restore
#line 53 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Worker\FullInfo.cshtml"
WriteAttributeValue("", 1841, Model.Number, 1841, 13, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1854, "?\');", 1854, 4, true);
                EndWriteAttribute();
                WriteLiteral(" />\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n    </table>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Warehouse.Models.Worker> Html { get; private set; }
    }
}
#pragma warning restore 1591
