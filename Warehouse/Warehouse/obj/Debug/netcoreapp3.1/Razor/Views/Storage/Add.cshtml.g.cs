#pragma checksum "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Storage\Add.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6bd79b1d7b0dec8e20c5bd83d0f1ef6278ddd005"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Storage_Add), @"mvc.1.0.view", @"/Views/Storage/Add.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6bd79b1d7b0dec8e20c5bd83d0f1ef6278ddd005", @"/Views/Storage/Add.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc02168007f24d38038bd969e052ce5b5b2dcc80", @"/Views/_ViewImports.cshtml")]
    public class Views_Storage_Add : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Warehouse.Models.Storage>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Storage\Add.cshtml"
  
    ViewData["Title"] = "Добавление склада";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h3>Форма добавления склада</h3>\r\n");
#nullable restore
#line 7 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Storage\Add.cshtml"
 using (Html.BeginForm("Add", "Storage", FormMethod.Post))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>\r\n        ");
#nullable restore
#line 10 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Storage\Add.cshtml"
   Write(Html.LabelFor(m => m.Name, "Наименование склада"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 11 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Storage\Add.cshtml"
   Write(Html.TextBoxFor(m => m.Name, new { @required = "required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </p>\r\n    <p>\r\n        ");
#nullable restore
#line 14 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Storage\Add.cshtml"
   Write(Html.LabelFor(m => m.Territory, "Территория склада"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 15 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Storage\Add.cshtml"
   Write(Html.TextBoxFor(m => m.Territory, new { @required = "required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </p>\r\n    <p>\r\n        ");
#nullable restore
#line 18 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Storage\Add.cshtml"
   Write(Html.LabelFor(m => m.City, "Город"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 19 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Storage\Add.cshtml"
   Write(Html.TextBoxFor(m => m.City, new { @required = "required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </p>\r\n    <p><input type=\"submit\" value=\"Добавить\" /></p>\r\n");
#nullable restore
#line 22 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Storage\Add.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Warehouse.Models.Storage> Html { get; private set; }
    }
}
#pragma warning restore 1591
